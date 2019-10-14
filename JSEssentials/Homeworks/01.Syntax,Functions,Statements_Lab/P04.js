
function largestNumber(num1, num2, num3) {

    let maxNum = Math.max(+num1, +num2, +num3);

    console.log(`The largest number is ${maxNum}.`);
}

largestNumber(5, -3, 16);
largestNumber(-3, -5, -22.5);