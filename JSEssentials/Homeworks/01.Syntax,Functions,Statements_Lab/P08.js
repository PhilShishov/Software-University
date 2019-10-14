function functionalCalculator(a, b, operator) {

    let calc = function (a, b, operator) { return operator(a, b) };

    let add = function (a, b) { return a + b };

    let subtract = function (a, b) { return a - b };

    let multiply = function (a, b) { return a * b };

    let divide = function (a, b) { return a / b };

    switch (operator) {

        case '+': return calc(a, b, add);

        case '-': return calc(a, b, subtract);

        case '*': return calc(a, b, multiply);

        case '/': return calc(a, b, divide);
    }
}

functionalCalculator(2, 4, '+');
functionalCalculator(3, 3, '/');
functionalCalculator(18, -1, '*');