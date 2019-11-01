function sameNumbers(number) {

    number = number.toString();
    let firstNum = number[0];
    let sum = +firstNum;

    let isSame = true;

    for (let i = 1; i <= number.length - 1; i++) {

        sum += +number[i];

        if (firstNum !== number[i]) {
            isSame = false;

        }
    }

    console.log(isSame);
    console.log(sum);
}

sameNumbers(2222222);