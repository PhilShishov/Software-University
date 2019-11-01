
function sumOfNumbers(n, m) {

    let sum = 0;
    let firstNum = Number(n);
    let secondNum = Number(m);

    for (let index = firstNum; index <= secondNum; index++) {
        sum += index;
    }

    console.log(sum);
}

sumOfNumbers('1', '5');
sumOfNumbers('-8', '20');