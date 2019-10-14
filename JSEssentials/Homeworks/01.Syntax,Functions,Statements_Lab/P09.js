function aggregateElements(arr) {

    let sumResult;
    let sumInverseResult;
    let concatResult;

    sumResult = arr.reduce((a, b) => a + b, 0);
    sumInverseResult = arr.reduce((a, b) => a + 1/b, 0)
    concatResult = arr.join('');

    console.log(sumResult);
    console.log(sumInverseResult);
    console.log(concatResult);
}

aggregateElements([1, 2, 3]);
aggregateElements([2, 4, 8, 16]);