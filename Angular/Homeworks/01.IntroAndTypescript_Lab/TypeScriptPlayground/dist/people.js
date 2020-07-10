"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Manager = exports.Senior = exports.Junior = void 0;
class Employee {
    constructor(name, age) {
        this.salary = 0;
        this.salary = 0;
        this.name = name;
        this.age = age;
        this.tasks = [];
    }
    work() {
        if (!this.tasks.shift()) {
            throw new Error("Unexpected error: Missing task");
        }
        let currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(this.name + currentTask);
    }
    collectSalary(money) {
        console.log(`${this.name} received ${this.getSalary()} this month.`);
    }
    getSalary() {
        return this.salary;
    }
}
class Junior extends Employee {
    constructor(name, age) {
        super(name, age);
        this.tasks = [`${this.name} is working on a simple task.`];
    }
}
exports.Junior = Junior;
class Senior extends Employee {
    constructor(name, age) {
        super(name, age);
        this.tasks = [
            `${this.name} is working on a complicated task.`,
            `${this.name} is taking time of work.`,
            `${this.name} is supervising junior workers.`
        ];
    }
}
exports.Senior = Senior;
class Manager extends Employee {
    constructor(name, age) {
        super(name, age);
        this.dividend = 0;
        this.dividend = 0;
        this.tasks = [
            `${this.name} scheduled a meeting.`,
            `${this.name} is preparing a quarterly report.`
        ];
    }
    getSalary() {
        return this.salary + this.dividend;
    }
}
exports.Manager = Manager;
//# sourceMappingURL=people.js.map