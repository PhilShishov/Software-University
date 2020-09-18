function solve() {

    let inputElements = document.querySelectorAll("tbody td input");
    let quickCheckButton = document.getElementsByTagName("button")[0];
    let clearButton = document.getElementsByTagName("button")[1];
    let tableElement = document.getElementsByTagName("table")[0];
    let checkElement = document.querySelector("#check p");

    quickCheckButton.addEventListener("click", checker);
    clearButton.addEventListener("click", clear);

    function checker() {
        let rowsAndCols = Math.sqrt(inputElements.length);

        for (let i = 0; i < inputElements.length; i += rowsAndCols) {
            let uniqueNumberRow = new Set();
            for (let j = 0; j < rowsAndCols; j++) {
                uniqueNumberRow.add(inputElements[i + j].value);
            }
            rowAndColChecker(uniqueNumberRow);
        }

        for (let j = 0; j < rowsAndCols; j++) {
            let uniqueNumberCol = new Set();
            for (let i = 0; i < inputElements.length; i += rowsAndCols) {
                uniqueNumberCol.add(inputElements[j + i].value);
            }
            rowAndColChecker(uniqueNumberCol);
        }

        function rowAndColChecker(numbers) {
            if (numbers.size !== rowsAndCols) {
                tableElement.style.border = "2px solid red";
                checkElement.style.color = "red";
                checkElement.textContent = "NOP! You are not done yet...";
            }
        }
        if (!checkElement.textContent) {
            tableElement.style.border = "2px solid green";
            checkElement.style.color = "green";
            checkElement.textContent = "You solve it! Congratulations!";
        }
    }

    function clear() {
        for (let i = 0; i < inputElements.length; i++) {
            inputElements[i].value = "";
        }
        tableElement.style.border = "";
        checkElement.style.color = "";
        checkElement.textContent = "";
    }
}