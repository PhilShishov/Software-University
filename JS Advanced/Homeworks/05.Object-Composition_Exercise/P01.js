(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        return this.slice(n);
    };

    Array.prototype.take = function (n) {
        return this.slice(0, n);
    };

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b);
    };

    Array.prototype.average = function () {
        return this.sum() / this.length;
    };
})();

const myArr = [1, 2, 3];

console.log(myArr.last());
console.log(myArr.skip(1));
console.log(myArr.take(1));
console.log(myArr.sum());
console.log(myArr.average());