function classHierarchy() {

    // Abstract class
    class Figure {
        constructor() {
            if (new.target === Figure) {
                throw new Error('Cannot be instantiated');
            }
        }

        toString() {
            const type = this.constructor.name;
            const props = Object.getOwnPropertyNames(this);
            return type + ' - ' + props.map(p => `${p}: ${this[p]}`).join(', ');
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();
            this.radius = radius;
        }

        get area() {
            return Math.PI * this.radius * this.radius;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height) {
            super();
            this.width = width;
            this.height = height;
        }

        get area() {
            return this.width * this.height;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}

const container = classHierarchy();
const Figure = container.Figure;
const Circle = container.Circle;
const Rectangle = container.Rectangle;

const c = new Circle(5);
console.log(c.area);        //78.53981633974483
console.log(c.toString());  //Circle - radius: 5
const r = new Rectangle(3, 4);
console.log(r.area);        //12
console.log(r.toString());  //Rectangle - width: 3, height: 4
// let f = new Figure();       //Error