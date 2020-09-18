function solve(inputArray) {
    let rows = Number(inputArray[0]);
    let cols = Number(inputArray[1]);
    let rowIndex = Number(inputArray[2]);
    let colIndex = Number(inputArray[3]);

    let matrix = [];

    for (let i = 0; i < rows; i++) {
        matrix[i] = [];
        for (let j = 0; j < cols; j++) {
            matrix[i][j] = Math.max(Math.abs(i - rowIndex), Math.abs(j - colIndex)) + 1;
        }
    }
        console.log(matrix.map(x => x.join(" ")).join("\n"));
}

solve([4, 4, 0, 0]);