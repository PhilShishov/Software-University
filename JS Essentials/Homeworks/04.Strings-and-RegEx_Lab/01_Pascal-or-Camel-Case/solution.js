
function solve() {

    let input = document.getElementById("text").value;
    let currentCase = document.getElementById("naming-convention").value;

    function pascalOrCamelCase(input, currentCase) {

        let words = input
            .toLowerCase()
            .split(' ')
            .filter(a => a !== '');

        let output = "";

        if (currentCase === "Pascal Case" || currentCase === "Camel Case") {
            for (let word of words) {
                word = word.replace(word[0], word[0].toUpperCase());
                output += word;
            }
        } else {
            output = "Error!";
        }
        
        if (currentCase === "Camel Case") {
            output = output.replace(output[0], output[0].toLowerCase());            
        }
        document.getElementById("result").innerHTML = output;
    }
    pascalOrCamelCase(input, currentCase);
}
