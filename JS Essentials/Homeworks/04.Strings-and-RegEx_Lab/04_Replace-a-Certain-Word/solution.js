// function solve() {

//     let word = document.getElementById("word").value;
//     let arr = JSON.parse(document.getElementById("text").value);
//     let result = document.getElementById("result");

//     function replaceCertainWord(arr, word) {

//         let wordToReplace = arr[0].split(" ").filter(a => a !== "")[2];
//         let regex = new RegExp(wordToReplace, "gi");

//         for (let sentence of arr) {

//             sentence = sentence.replace(regex, word);

//             let p = document.createElement("p");
//             p.innerHTML = sentence;
//             result.appendChild(p);
//         }
//     }

//     replaceCertainWord(arr, word);
// }

function solve() {

    const word = document.getElementById("word").value;
    let text = JSON.parse(document.getElementById("text").value);
    let result = document.getElementById("result");

    const wordToReplace = text[0].split(" ")[2];
    const pattern = new RegExp(wordToReplace, 'gi');

    text = text.map(part => part.replace(pattern, word));

    for (const sentence of text) {
        const p = document.createElement("p");
        p.innerHTML = sentence;
        result.appendChild(p);
    }
}