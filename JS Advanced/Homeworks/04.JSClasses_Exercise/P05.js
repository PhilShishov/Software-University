let result = (function () {
    let id = 0;

    return class Extensible {
        constructor() {
            this.id = id++;
        }

        extend(template) {
            for (const property in template) {
                if (typeof template[property] === 'function') {
                    Extensible.prototype[property] = template[property];
                } else {
                    this[property] = template[property];
                }
            }
        }
    }
})();

const Extensible = result;

const obj1 = new Extensible();
const obj2 = new Extensible();
const obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);