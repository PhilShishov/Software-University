"use strict";
class Box {
    constructor() {
        this.items = [];
    }
    add(item) {
        this.items.push(item);
    }
    remove() {
        this.items.pop();
    }
    get count() {
        return this.items.length;
        ;
    }
}
console.log("First box");
let numberBox = new Box();
numberBox.add(1);
numberBox.add(2);
numberBox.add(3);
console.log(numberBox.count);
console.log("Second box.");
let stringBox = new Box();
stringBox.add("Pesho");
stringBox.add("Gosho");
console.log(stringBox.count);
stringBox.remove();
console.log(stringBox.count);
//# sourceMappingURL=box.js.map