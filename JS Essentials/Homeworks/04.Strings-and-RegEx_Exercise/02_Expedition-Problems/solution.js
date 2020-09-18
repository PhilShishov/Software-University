function solve() {

    const keyword = document.getElementById("string").value;
    const text = document.getElementById("text").value;
    let result = document.getElementById("result");

    let messageRegexString = `${keyword}(.*)${keyword}`;
    let messageRegex = new RegExp(messageRegexString, "g");
    let messageMatch = messageRegex.exec(text);
    let message = messageMatch[1];

    let locationRegex = /(north|east).*?(\d{2})[^,]*?,[^,]*?(\d{6})/gmi;

    let eastMatch;
    let northMatch;

    let match = locationRegex.exec(text);

    while (match !== null) {
        if (match[1].toUpperCase() === "NORTH") {
            northMatch = match;
        } else {
            eastMatch = match;
        }
        match = locationRegex.exec(text);
    }

    let p1 = document.createElement("p");
    p1.innerHTML = `${northMatch[2]}.${northMatch[3]} N`;

    let p2 = document.createElement("p");
    p2.innerHTML = `${eastMatch[2]}.${eastMatch[3]} E`;    
    
    let p3 = document.createElement("p");
    p3.innerHTML = `Message: ${message}`;

    result.appendChild(p1);
    result.appendChild(p2);
    result.appendChild(p3);
    
}