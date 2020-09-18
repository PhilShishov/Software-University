function solve() {
    let input = JSON.parse(document.getElementById('array').value);
    let specialKey = input[0];
    let regex = new RegExp(`(^| )(${specialKey}) +([A-Z!%$#]{8,})(\.|,| |$)`, 'gi');

    for (let i = 1; i < input.length; i++) {
        let text = input[i];
        let match;
        while ((match = regex.exec(text))) {
            if (!(/[a-z]/.test(match[3]))) {
                let changedWord = match[3].replace(/[!]/g, "1");
                changedWord = changedWord.replace(/[%]/g, "2");
                changedWord = changedWord.replace(/[#]/g, "3");
                changedWord = changedWord.replace(/[$]/g, "4");
                text = text.replace(match[3], changedWord.toLowerCase());
            }
        }
        let pElement = document.createElement('p');
        pElement.textContent = text;
        document.getElementById('result').appendChild(pElement);
    }
}
