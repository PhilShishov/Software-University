
function solve(arr) {

    let doubledNumbers = arr
        .filter((x, i) => {
            return i % 2 === 1
        })
        .map((x) => {
            return x * 2
        })
        .reverse()
        .join(" ");

    console.log(doubledNumbers);

}

solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7, 3]);