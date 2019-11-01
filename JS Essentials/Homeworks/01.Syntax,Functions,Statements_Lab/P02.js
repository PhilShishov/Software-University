
function mathOperations(num1, num2, operator) {

    let result;

    switch (operator) {
        case '+': result = num1 + num2; break;
        case '-': result = num1 - num2; break;
        case '*': result = num1 * num2; break;
        case '/': result = num1 / num2; break;
        case '%': result = num1 % num2; break;
        case '**': result = num1 ** num2; break;
    }

    console.log(result)
}

mathOperations(5, 6, '+');
mathOperations(3, 5.5, '**');