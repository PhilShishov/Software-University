// function solve() {
//     let input = document.getElementById('text').value;
//     let n = parseInt(document.getElementById('number').value);

//     function splitStringEqually(input, n) {

//         let arr = [];
//         let indexCounter = 0;

//         if (input.length % n !== 0) {

//             let len = input.length;
//             let symbolsCount = 0;

//             while (len % n !== 0) {

//                 len %= n;

//                 len++;

//                 symbolsCount++;
//             }
//             for (let i = 0; i < symbolsCount; i++) {

//                 input += input[indexCounter];

//                 indexCounter++;
//             }
//         }

//         for (let i = 0; i < input.length; i += n) {

//             arr.push(input.substr(i, n));
//         }

//         document.getElementById("result").innerHTML = arr.join(" ");
//     }

//     splitStringEqually(input, n);
// }

function solve() {
    let text = document.getElementById('text').value;
    const groupSize = +document.getElementById('number').value;

    if (text.length % groupSize > 0) {
        const remainder = text.length % groupSize;
        const charsToFill = groupSize - remainder;
        text = text + text.substr(0, charsToFill);
    }
    
    const result = [];
    for(let i = 0; i < text.length; i += groupSize) {
        result.push(text.substr(i, groupSize))
    }

    document.getElementById("result").innerHTML = result.join(" ")
    
}