
function solve(arr) {

    let result = [];

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] >= 0) {
            result.push(arr[i]);
        } else {
            result.unshift(arr[i]);
        }

    }
    console.log(result.join("\n"));
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);