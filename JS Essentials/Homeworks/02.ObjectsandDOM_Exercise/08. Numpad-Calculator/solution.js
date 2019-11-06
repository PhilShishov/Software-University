function solve() {

    const expressionOutput = document.getElementById('expressionOutput');
    const resultOutput = document.getElementById('resultOutput');

    const keys = Array.from(document.getElementsByTagName('button'));

    for (const button of keys) {
        button.addEventListener('click', onclick)
    }

    function onclick() {
        if (this.value !== '=' && this.value !== 'Clear') {
            if (this.value === '/' || this.value === '*' || this.value === '-' || this.value === '+') {
                expressionOutput.textContent += ` ${this.value} `;;
            } else {
                expressionOutput.textContent += this.value;
            }

        } else if (this.value === 'Clear') {
            expressionOutput.textContent = '';
            resultOutput.textContent = '';
        } else {
            let resultString = expressionOutput.textContent;
            let numbers = resultString.match(/\d*\.*\d+/g);
            let operators = resultString.match(/[\+\*\-\/]/g);
            let result = Number(numbers[0]);
            if (operators) {
                for (let i = 0; i < operators.length; i++) {
                    let operator = operators[i];
                    let number = Number(numbers[i + 1]);
                    switch (operator) {
                        case "+":
                            result += number;
                            break;
                        case "-":
                            result -= number;
                            break;
                        case "*":
                            result *= number;
                            break;
                        case "/":
                            result /= number;
                            break;
                    }

                }
            }
            resultOutput.textContent = result;
        }
    }
}