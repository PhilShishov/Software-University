function solution(input) {
    let sum = arr.reduce((a,b) => a + b);
    console.log(`Sum = ${sum}`);

    let minNumber = arr.reduce((a,b) => Math.min(a,b));
    console.log(`Min = ${minNumber}`);

    let maxNumber = arr.reduce((a,b) => Math.max(a,b));
    console.log(`Max = ${maxNumber}`);

    let product = arr.reduce((a,b) => a * b);
    console.log(`Product = ${product}`);

    let string = arr.reduce((a,b) => '' + a + b);
    console.log(`Join = ${string}`);
}

solution([2, 3, 10, 5]);