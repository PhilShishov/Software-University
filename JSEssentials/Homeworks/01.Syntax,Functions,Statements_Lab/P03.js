
function sameNumbers(number) {

    number = number.toString();
    let isSame = true;
    let firstNum = number[0];
    let sum = +firstNum;

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