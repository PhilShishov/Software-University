class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }

    registerChild(name, grade, budget) {
        if (budget < this.budget) {
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`
        }

        if (this.kids.hasOwnProperty(grade)) {
            for (const kid of this.kids[grade]) {
                if (kid === `${name}-${budget}`) {
                    return `${name} is already in the list for this ${this.destination} vacation.`
                }
            }
            this.kids[grade].push(`${name}-${budget}`);
        } else {
            this.kids[grade] = [];
            this.kids[grade].push(`${name}-${budget}`);
        }

        return this.kids[grade];
    }

    removeChild(name, grade) {
        if (this.kids.hasOwnProperty(grade)) {
            for (const kid of this.kids[grade]) {
                let kidInfo = kid.split('-');
                let kidName = kidInfo[0];

                if (kidName === name) {
                    let index = this.kids[grade].indexOf(kid);
                    this.kids[grade].splice(index, 1);
                    return this.kids[grade];
                }
            }
        }
        return `We couldn't find ${name} in ${grade} grade.`
    }

    toString() {
        if (this.numberOfChildren === 0) {
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`
        } else {
            let result = `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;

            for (const grade in this.kids) {
                result += `Grade: ${grade}\n`;

                for (let i = 0; i < this.kids[grade].length; i++) {
                    result += `${i + 1}. ${this.kids[grade][i]}\n`;
                }
            }
            return result;
        }
    }

    get numberOfChildren() {
        this._numberOfChildren = 0;

        for (const grade in this.kids) {
            this._numberOfChildren += this.kids[grade].length;
        }

        return this._numberOfChildren;
    }

}

// ============================== 

// let vacation = new Vacation('Mr Pesho', 'San diego', 2000);
// console.log(vacation.registerChild('Gosho', 5, 2000));
// console.log(vacation.registerChild('Lilly', 6, 2100));
// console.log(vacation.registerChild('Pesho', 6, 2400));
// console.log(vacation.registerChild('Gosho', 5, 2000));
// console.log(vacation.registerChild('Tanya', 5, 6000));
// console.log(vacation.registerChild('Mitko', 10, 1590));

// [ 'Gosho-2000' ]
// [ 'Lilly-2100' ]
// [ 'Lilly-2100', 'Pesho-2400' ]
// Gosho is already in the list for this San diego vacation.
// [ 'Gosho-2000', 'Tanya-6000' ]
// Mitko's money is not enough to go on vacation to San diego.

// ============================== 

// let vacation = new Vacation('Mr Pesho', 'San diego', 2000);
// vacation.registerChild('Gosho', 5, 2000);
// vacation.registerChild('Lilly', 6, 2100);

// console.log(vacation.removeChild('Gosho', 9));

// vacation.registerChild('Pesho', 6, 2400);
// vacation.registerChild('Gosho', 5, 2000);

// console.log(vacation.removeChild('Lilly', 6));
// console.log(vacation.registerChild('Tanya', 5, 6000))

// We couldn't find Gosho in 9 grade.
// [ 'Pesho-2400' ]
// [ 'Gosho-2000', 'Tanya-6000' ]

// ============================== 

let vacation = new Vacation('Miss Elizabeth', 'Dubai', 2000);
vacation.registerChild('Gosho', 5, 3000);
vacation.registerChild('Lilly', 6, 1500);
vacation.registerChild('Pesho', 7, 4000);
vacation.registerChild('Tanya', 5, 5000);
vacation.registerChild('Mitko', 10, 5500)
console.log(vacation.toString());

// Miss Elizabeth will take 4 children on trip to Dubai
// Grade: 5
// 1. Gosho-3000
// 2. Tanya-5000

// Grade: 7
// 1. Pesho-4000

// Grade: 10
// 1. Mitko-5500