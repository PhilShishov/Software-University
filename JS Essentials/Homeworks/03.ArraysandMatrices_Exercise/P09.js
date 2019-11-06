function solve(matrix) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for (let i = 0; i < matrix.length; i++) {
        firstDiagonal += +matrix[i].split(" ")[i];
        secondDiagonal += +matrix[i].split(" ")[matrix.length - 1 - i];
    }
    if (firstDiagonal === secondDiagonal) {
        for (let i = 0; i < matrix.length; i++) {
            let currentString = matrix[i].split(" ");
            for (let j = 0; j < currentString.length; j++) {
                if (j !== i && j !== matrix.length - 1 - i) {
                    currentString[j] = firstDiagonal;
                }
            }
            matrix[i] = currentString.join(" ");
        }
        console.log(matrix.join("\n"));
    }
}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
)