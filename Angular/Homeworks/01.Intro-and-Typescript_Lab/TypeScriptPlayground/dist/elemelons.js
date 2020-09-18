"use strict";
class Melon {
    constructor(weight, sort) {
        this.weight = weight;
        this.sort = sort;
        this.elementIndex = this.weight * this.sort.length;
    }
    toString() {
        let output = `Element: ${this.constructor.name.replace('melon', '')}\n`;
        output += `Sort: ${this.sort}\n`;
        output += `Element Index: ${this.elementIndex}`;
        return output;
    }
}
class Watermelon extends Melon {
    constructor(weight, sort) {
        super(weight, sort);
        this.weight = weight;
        this.sort = sort;
    }
}
class Firemelon extends Melon {
    constructor(weight, sort) {
        super(weight, sort);
        this.weight = weight;
        this.sort = sort;
    }
}
class Airmelon extends Melon {
    constructor(weight, sort) {
        super(weight, sort);
        this.weight = weight;
        this.sort = sort;
    }
}
class Earthmelon extends Melon {
    constructor(weight, sort) {
        super(weight, sort);
        this.weight = weight;
        this.sort = sort;
    }
}
class Melolemonmelon extends Airmelon {
    constructor(weight, sort) {
        super(weight, sort);
        this.counter = 0;
        this.elements = [Watermelon, Firemelon, Earthmelon, Airmelon];
    }
    morph() {
        this.counter++;
    }
    toString() {
        return new this.elements[this.counter % 4](this.weight, this.sort).toString();
    }
}
//classes usage
const watermelon = new Watermelon(12.5, "Kingsize");
const firemelon = new Firemelon(21, "SuperDuperSize");
const earthmelon = new Earthmelon(10, "Normalsize");
const airmelon = new Airmelon(5, "Smallsize");
const melolemonmelon = new Melolemonmelon(13, "Kingsize");
console.log(watermelon.toString());
console.log(firemelon.toString());
console.log(earthmelon.toString());
console.log(airmelon.toString());
console.log(melolemonmelon.toString());
melolemonmelon.morph();
console.log(melolemonmelon.toString());
melolemonmelon.morph();
console.log(melolemonmelon.toString());
melolemonmelon.morph();
console.log(melolemonmelon.toString());
//# sourceMappingURL=elemelons.js.map