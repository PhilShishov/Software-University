function personAndTeacher() {

    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
    }
    
    return {
        Person,
        Teacher
    }
}

const container = personAndTeacher();
const Person = container.Person;
const Teacher = container.Teacher;
const p = new Person("Maria", "maria@gmail.com");
const t = new Teacher("Ivan", "iv@yahoo.com", "PHP");

console.log(p);
console.log(t);