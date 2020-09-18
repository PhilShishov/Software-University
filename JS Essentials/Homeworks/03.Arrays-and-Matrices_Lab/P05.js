function solve(n, k) {

    let result = [1];

    for (let i = 1; i < n; i++) {
        let firstIndex = result.length >= k ? result.length - k : 0;
        let sum = result.slice(firstIndex, result.length).reduce(function (a, b) {
            return a + b;
        }, 0);

        result[i] = sum;

    }
    console.log(result.join(" "));
}


solve(6, 3);
solve(8, 2);