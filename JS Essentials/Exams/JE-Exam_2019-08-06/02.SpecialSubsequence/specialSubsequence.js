function specialSubsequence(array) {

    let longestSequence = [array[0]];
    let currentSequence = [array[0]];

    for (let i = 1; i < array.length; i++) {
        // if (array[i] * array[i - 1] < 0) 
        if ((array[i - 1] < 0 && array[i] > 0) || (array[i - 1] > 0 && array[i] < 0)) {
            currentSequence.push(array[i]);
        } else {
            if (currentSequence.length > longestSequence.length) {
                longestSequence = currentSequence;
            }

            currentSequence = [array[i]];
        }
    }

    if (currentSequence.length > longestSequence.length) {
        longestSequence = currentSequence;
    }

    if (longestSequence.length === 1) {
        console.log(`In ${array.join(', ')} no special sequence is found`);
    } else {
        console.log(`The longest sequence is ${longestSequence.join(', ')}`);
    }
}

specialSubsequence([1, -2, 1, -1, 2, 1, -1]);
specialSubsequence([-1, -1, -1, 1, -1]);
specialSubsequence([1, 2, 3, 4, 5]);