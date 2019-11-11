// function specialSubsequence(sequenceInput) {

//     let sequenceOrig = sequenceInput;
//     let sequence = [];
//     let maxSequence = [];

//     for (let i = 0; i < sequenceInput.length; i++) {

//         let currentNum = sequenceInput[i];
//         let nextNum = sequenceInput[i + 1];

//         if (currentNum === 0) {
//             sequence = [];
//             continue;
//         }
//         if (nextNum > 0 && currentNum < 0) {
//             sequence.push(currentNum);
//         } else if (nextNum < 0 && currentNum > 0) {
//             sequence.push(currentNum);
//         }
//         if ((nextNum > 0 && currentNum > 0) || (nextNum < 0 && currentNum < 0) || nextNum == undefined) {
//             sequence.push(currentNum);
//             if (sequence.length > maxSequence.length) {
//                 maxSequence = sequence;
//             }
//             sequence = [];
//             continue;
//         }
//     }

//     if (maxSequence.length > 1) {
//         console.log(`The longest sequence is ${maxSequence.join(', ')}`);
//     }
//     else {
//         sequence = sequenceOrig;
//         console.log(`In ${sequence.join(', ')} no special sequence is found`)
//     }
// }

// specialSubsequence([1, -2, 1, -1, 2, 1, -1]);

// specialSubsequence([-1, -1, -1, 1, -1]);

// specialSubsequence([1, 2, 3, 4, 5]);


function solve(array) {
    let longestSequence = [array[0]];
    let currentSequence = [array[0]];

    for (let i = 1; i < array.length; i++) {
        if (array[i] * array[i - 1] < 0) {
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

solve([1, -2, 1, -1, 2, 1, -1]);
solve([-1, -1, -1, 1, -1]);
solve([1, 2, 3, 4, 5]);