abstract class Employee {
    public name: string;
    public age: number;
    public salary: number = 0;
    public tasks: Array<string>;


    constructor(name: string, age: number) {
        this.salary = 0;
        this.name = name;
        this.age = age;
        this.tasks = [];
    }

    public work(): void {
        if (!this.tasks.shift()) {
            throw new Error("Unexpected error: Missing task");
        }

        let currentTask: string = this.tasks.shift() as string;

        this.tasks.push(currentTask);
        console.log(this.name + currentTask);
    }

    public collectSalary(money: number) {
        console.log(`${this.name} received ${this.getSalary()} this month.`);
    }

    public getSalary(): number{
        return this.salary;
    }
}

class Junior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks = [`${this.name} is working on a simple task.`];
    }
}

class Senior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks = [
            `${this.name} is working on a complicated task.`,
            `${this.name} is taking time of work.`,
            `${this.name} is supervising junior workers.`
        ];
    }
}


class Manager extends Employee {
    public dividend: number = 0;

    constructor(name: string, age: number) {
        super(name, age);
        this.dividend = 0;
        this.tasks = [
            `${this.name} scheduled a meeting.`,
            `${this.name} is preparing a quarterly report.`
        ];
    }

    public getSalary(){
        return this.salary + this.dividend;
    }
}

export { Junior, Senior, Manager }