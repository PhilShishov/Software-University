
function countWordsInAText(input) {

    let words = input[0].split(/\W+/).filter(w => w != "");
    let obj = {};

    for (let word of words) {
        if (!obj.hasOwnProperty(word)) {
            obj[word] = 1;
        } else {
            obj[word]++;
        }
    }

    console.log(JSON.stringify(obj));
}

// function countWordsInAText(input) {

//     let regex = /\W+/;
//     input = input[0].split(regex).filter(i => i != '');

//     let words = {};

//     for (let i = 0; i < input.length; i++) {

//         let word = input[i];

//         if (!words[word]) {
//             words[word] = 0;
//         }

//         words[word]++;
//     }

//     console.log(JSON.stringify(words));
// }

countWordsInAText(['Far too slow, you\'re far too slow.']);
countWordsInAText(['JS devs use Node.js for server-side JS.-- JS for devs']);