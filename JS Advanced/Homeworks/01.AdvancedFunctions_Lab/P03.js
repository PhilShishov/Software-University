// function solution() {
//     let str = '';

//     return {
//         append: (s) => str += s,
//         removeStart: (n) => str = str.substring(n),
//         removeEnd: (n) => str = str.substring(0, str.length - n),
//         print: () => console.log(str)
//     };
// }

// let firstZeroTest = solution();

// firstZeroTest.append('hello');
// firstZeroTest.append('again');
// firstZeroTest.removeStart(3);
// firstZeroTest.removeEnd(4);
// firstZeroTest.print();

function solve(array) {
    let closure = (function () {
        let currentString = '';

        return {
            append: (str) => currentString += str,
            removeStart: (n) => currentString = currentString.slice(n),
            removeEnd: (n) => currentString = currentString.slice(0, currentString.length - n),
            print: () => console.log(currentString)
        }
    })();

    for (let currentString of array) {
        let [comm, value] = currentString.split(' ');
        closure[comm](value);
    }
}

solve(['append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print']
);

solve(['append 123',
    'append 45',
    'removeStart 2',
    'removeEnd 1',
    'print']
);