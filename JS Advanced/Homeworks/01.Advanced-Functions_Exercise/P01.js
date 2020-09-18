function solve(arr, sortMethod) {
    let sortingStrategies = {
        asc: (a, b) => a - b,
        desc: (a,b) => b -a
    };

    return arr.sort(sortingStrategies[sortMethod]);
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));