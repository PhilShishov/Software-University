// function solve() {

//   let textElement = document.getElementById("input").textContent;
//   let outputElement = document.getElementById("output");

//   let textAsArray = textElement.split('.').filter(x => x !== "");

//   for (let i = 0; i < textAsArray.length; i++) {
//     let p = document.createElement("p");
//     p.textContent += textAsArray[i] + ".";

//     if (textAsArray[i + 1]) {
//       p.textContent += textAsArray[i + 1] + ".";
//     }

//     if (textAsArray[i + 1]) {
//       p.textContent += textAsArray[i + 2] + ".";
//     }

//     outputElement.appendChild(p);
//   }
// }

function solve() {
  const input = document.getElementById('input').textContent;
  const output = document.getElementById('output');

  let sentences = input.split('.').filter(s => s != "");

  if (sentences.length <= 3) {

    const p = document.createElement('p');
    for (let i = 0; i < sentences.length; i++) {
      p.textContent += sentences[i] + '.';
    }
    output.appendChild(p);
  }
  else {
    let p = document.createElement('p');
    for (let i = 0; i < sentences.length; i++) {
      if (i % 3 == 0) {
        p = document.createElement('p');
      }
      p.textContent += sentences[i] + '.';
      output.appendChild(p);
    }
  }
}