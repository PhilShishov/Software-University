function toStringExtension() {

    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
        toString() {
            const className = this.constructor.name;

            return `${className} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            const baseStr = super.toString().slice(0, -1);
            return baseStr + `, course: ${this.course})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            const baseStr = super.toString().slice(0, -1);
            return baseStr + `, subject: ${this.subject})`;
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}

const container = toStringExtension();
const Person = container.Person;
const Student = container.Student;
const Teacher = container.Teacher;
const p = new Person("Maria", "maria@gmail.com");
const s = new Student("Petar", "pet@yahoo.com", "JS");
const t = new Teacher("Ivan", "iv@yahoo.com", "PHP");

console.log(p.toString());
console.log('' + s);
console.log('' + t);

console.log(Object.getPrototypeOf(Teacher) == Person);
console.log(Teacher.__proto__ == Person);
console.log(Object.getPrototypeOf(Person) == Function.prototype);