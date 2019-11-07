function solve() {
    let input = document.getElementById("string").value.split(", ");
    let text = input[0];
    let command = input[1];
   let nameRegex =new RegExp(" (([A-Z][A-Za-z]*?)(-[A-Z][A-Za-z]*\\.)?-([A-Z][A-Za-z]*?)) ");
    let airportRegex = new RegExp(" ([A-Z]{3}\\/[A-Z]{3}) ");
    let flightNumberRegex = new RegExp(" ([A-Z]{1,3}[0-9]{1,5}) ");
    let companyRegex = new RegExp("- ([A-Z][A-Za-z]*\\*[A-Z][A-Za-z]*) ");

    let name = nameRegex.exec(text)[1].split("-").join(" ");
    let airport = airportRegex.exec(text)[1].split("/").join(" to ");
    let flightNumber = flightNumberRegex.exec(text)[1];
    let company = companyRegex.exec(text)[1].split("*").join(" ");

    let result = "";
    switch (command) {
        case"name":
            result = `Mr/Ms, ${name}, have a nice flight!`;
            break;
        case"flight":
            result = `Your flight number ${flightNumber} is from ${airport}.`;
            break;
        case"company":
            result = `Have a nice flight with ${company}.`;
            break;
        case"all":
            result = `Mr/Ms, ${name}, your flight number ${flightNumber} is from ${airport}. Have a nice flight with ${company}.`;
            break;

    }
    document.getElementById("result").textContent= `${result}`;
}