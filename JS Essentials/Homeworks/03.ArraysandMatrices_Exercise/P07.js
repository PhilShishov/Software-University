
function solve(matrix) {
    let magicNumber = matrix[0].reduce((a, b) => a + b);
    let isMagic = true;

    for (let i = 1; i < matrix.length; i++) {
        let currentNumber = matrix[i].reduce((a, b) => a + b);

        if (currentNumber !== magicNumber) {
            isMagic = false;
            console.log(isMagic);
            return;
        }
    }

    for (let i = 0; i < matrix.length; i++) {
        let currentColNumber = 0;
        for (let j = 0; j < matrix.length; j++) {
            currentColNumber += matrix[j][i];
        }
        if (currentColNumber !== magicNumber) {
            isMagic = false;
            console.log(isMagic);
            return;
        }
    }
    console.log(isMagic);
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );