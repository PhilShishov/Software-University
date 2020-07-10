class Box<T>{
    public items: T[] = [];

    public add(item: T): void {
        this.items.push(item);
    }

    public remove(): void {
        this.items.pop();
    }

    public get count(): number {
        return this.items.length;;
    }
}

console.log("First box");

let numberBox = new Box<Number>();
numberBox.add(1);
numberBox.add(2);
numberBox.add(3);
console.log(numberBox.count);

console.log("Second box.");

let stringBox = new Box<String>();
stringBox.add("Pesho");
stringBox.add("Gosho");
console.log(stringBox.count);
stringBox.remove();
console.log(stringBox.count);