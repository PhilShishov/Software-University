function spaceshipCrafting() {
    const availableBars = document.getElementById('availableBars').getElementsByTagName('p')[0];
    const builtSpaceshipsSection = document.getElementById('builtSpaceships').getElementsByTagName('p')[0];
    const inputFields = document.getElementById('inputs').getElementsByTagName('input');

    let titanium = inputFields[0].value;
    let aluminium = inputFields[1].value;
    let magnesium = inputFields[2].value;
    let carbon = inputFields[3].value;
    let lossesPercent = (inputFields[4].value / 4) / 100;

    titanium -= titanium * lossesPercent;
    let titaniumBar = Math.floor(titanium / 25);

    aluminium -= aluminium * lossesPercent;
    let aluminiumBar = Math.floor(aluminium / 50);

    magnesium -= magnesium * lossesPercent;
    let magnesiumBar = Math.floor(magnesium / 75);

    carbon -= carbon * lossesPercent;
    let carbonBar = Math.floor(carbon / 100);

    let spaceships = [
        ['THE-UNDEFINED-SHIP', 0],
        ['NULL-MASTER', 0],
        ['JSON-CREW', 0],
        ['FALSE-FLEET', 0]
    ]

    while (titaniumBar >= 2 && aluminiumBar >= 2 && magnesiumBar >= 3 && carbonBar >= 1) {
        if (titaniumBar >= 7 && aluminiumBar >= 9 && magnesiumBar >= 7 && carbonBar >= 7) {
            spaceships[0][1]++;
            titaniumBar -= 7;
            aluminiumBar -= 9;
            magnesiumBar -= 7;
            carbonBar -= 7;
        }
        if (titaniumBar >= 5 && aluminiumBar >= 7 && magnesiumBar >= 7 && carbonBar >= 5) {
            spaceships[1][1]++;
            titaniumBar -= 5;
            aluminiumBar -= 7;
            magnesiumBar -= 7;
            carbonBar -= 5;
        }
        if (titaniumBar >= 3 && aluminiumBar >= 5 && magnesiumBar >= 5 && carbonBar >= 2) {
            spaceships[2][1]++;
            titaniumBar -= 3;
            aluminiumBar -= 5;
            magnesiumBar -= 5;
            carbonBar -= 2;
        }
        if (titaniumBar >= 2 && aluminiumBar >= 2 && magnesiumBar >= 3 && carbonBar >= 1) {
            spaceships[3][1]++;
            titaniumBar -= 2;
            aluminiumBar -= 2;
            magnesiumBar -= 3;
            carbonBar -= 1;
        }
    }

    let builtSpaceships = spaceships.filter(s => s[1] > 0);

    let result = [];

    for (const spaceship of builtSpaceships) {
        result.push(`${spaceship[1]} ${spaceship[0]}`);
    }
    builtSpaceshipsSection.textContent = result.join(', ');

    availableBars.textContent = `${titaniumBar} titanium bars, ${aluminiumBar} aluminum bars, ${magnesiumBar} magnesium bars, ${carbonBar} carbon bars`;
}