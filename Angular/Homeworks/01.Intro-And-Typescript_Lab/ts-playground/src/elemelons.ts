abstract class Melon {
    readonly elementIndex: number = this.weight * this.sort.length;

    constructor(public weight: number, public sort: string) { }

    public toString(): string {
        let output: string = `Element: ${this.constructor.name.replace('melon', '')}\n`;
        output += `Sort: ${this.sort}\n`;
        output += `Element Index: ${this.elementIndex}`;

        return output;
    }
}

class Watermelon extends Melon {
    constructor(public weight: number, public sort: string) {
        super(weight, sort);
    }
}

class Firemelon extends Melon {
    constructor(public weight: number, public sort: string) {
        super(weight, sort);
    }
}

class Airmelon extends Melon {
    constructor(public weight: number, public sort: string) {
        super(weight, sort);
    }
}

class Earthmelon extends Melon {
    constructor(public weight: number, public sort: string) {
        super(weight, sort);
    }
}

class Melolemonmelon extends Airmelon {
    public counter: number;
    public elements: any;

    constructor(weight: number, sort: string) {
        super(weight, sort);
        this.counter = 0;
        this.elements = [Watermelon, Firemelon, Earthmelon, Airmelon];
    }

    public morph(): void {
        this.counter++;
    }

    public toString(): string {
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