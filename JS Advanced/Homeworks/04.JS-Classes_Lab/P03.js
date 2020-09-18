function getPersons() {
    class Person {
        constructor(firstName, lastName, age, email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }

        toString() {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
        }
    }

    const firstPperson = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    const secondPerson = new Person('SoftUni');
    const thirdPerson = new Person('Stephan', 'Johnson', 25);
    const fourthPerson = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');
    const people = [firstPperson, secondPerson, thirdPerson, fourthPerson];

    return people;
}

console.log(getPersons());