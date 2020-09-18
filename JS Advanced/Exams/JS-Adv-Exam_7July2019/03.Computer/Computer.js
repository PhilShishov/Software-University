class Computer {
    constructor(ramMemory, cpuGHz, hddMemory) {
        this.ramMemory = +ramMemory;
        this.cpuGHz = +cpuGHz;
        this.hddMemory = +hddMemory;
        this.taskManager = [];
        this.installedPrograms = [];
        this.totalRamUsage = 0;
        this.totalCpuUsage = 0;
    }

    installAProgram(name, requiredSpace) {
        if (requiredSpace > this.hddMemory) {
            throw new Error('There is not enough space on the hard drive');
        }

        const program = {
            name,
            requiredSpace,
        };

        this.hddMemory -= requiredSpace;
        this.installedPrograms.push(program);

        return program;
    }

    uninstallAProgram(name) {
        const program = this.installedPrograms.find(p => p.name == name);

        if (!program) {
            throw new Error('Control panel is not responding');
        }

        this.hddMemory += program.requiredSpace;

        const index = this.installedPrograms.indexOf(program);
        this.installedPrograms.splice(index, 1);

        return this.installedPrograms;
    }

    openAProgram(name) {
        const program = this.installedPrograms.find(p => p.name == name);

        if (!program) {
            throw new Error(`The ${name} is not recognized`);
        }

        const programIndexInTaskManager = this.taskManager
            .findIndex(p => p.name === name);

        if (programIndexInTaskManager > -1) {
            throw new Error(`The ${name} is already open`);
        }

        const ramUsage = (program.requiredSpace / this.ramMemory) * 1.5;
        const cpuUsage = ((program.requiredSpace / this.cpuGHz) / 500) * 1.5;

        if (this.totalRamUsage + ramUsage >= 100) {
            throw new Error(`${name} caused out of memory exception`);
        }

        if (this.totalCpuUsage + cpuUsage >= 100) {
            throw new Error(`${name} caused out of cpu exception`);
        }

        const programToOpen = {
            name,
            ramUsage,
            cpuUsage,
        };

        this.totalRamUsage += programToOpen.ramUsage;
        this.totalCpuUsage += programToOpen.cpuUsage;

        this.taskManager.push(programToOpen);

        return programToOpen;
    }

    taskManagerView() {
        if (this.taskManager.length === 0) {
            return 'All running smooth so far';
        }

        let info = [];

        for (const program of this.taskManager) {
            info.push(`Name - ${program.name} | Usage - CPU: ${program.cpuUsage.toFixed(0)}%, RAM: ${program.ramUsage.toFixed(0)}%`);
        }

        return info.join('\n');
    }
}

// ============================================

// const computer = new Computer(4096, 7.5, 250000);

// computer.installAProgram('Word', 7300);
// computer.installAProgram('Excel', 10240);
// computer.installAProgram('PowerPoint', 12288);
// computer.uninstallAProgram('Word');
// computer.installAProgram('Solitare', 1500);

// computer.openAProgram('Excel');
// computer.openAProgram('Solitare');

// console.log(computer.installedPrograms);
// console.log(('-').repeat(50)) // Separator
// console.log(computer.taskManager);

// [ { name: 'Excel', requiredSpace: 10240 },
//   { name: 'PowerPoint', requiredSpace: 12288 },
//   { name: 'Solitare', requiredSpace: 1500 } ]
// --------------------------------------------------
// [ { name: 'Excel', ramUsage: 3.75, cpuUsage: 4.096 },
//   { name: 'Solitare',
//     ramUsage: 0.54931640625,
//     cpuUsage: 0.6000000000000001 } ]

// ============================================

const computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Word');
computer.openAProgram('Excel');
computer.openAProgram('PowerPoint');
computer.openAProgram('Solitare');

console.log(computer.taskManagerView());

// Name - Word | Usage - CPU: 3%, RAM: 3%
// Name - Excel | Usage - CPU: 4%, RAM: 4%
// Name - PowerPoint | Usage - CPU: 5%, RAM: 5%
// Name - Solitare | Usage - CPU: 1%, RAM: 1%