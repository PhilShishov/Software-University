function solve(numbers) {
    return Math.max.apply(null, numbers);
}

console.log(solve([10, 20, 5]));
console.log(solve([1, 44, 123, 33]));