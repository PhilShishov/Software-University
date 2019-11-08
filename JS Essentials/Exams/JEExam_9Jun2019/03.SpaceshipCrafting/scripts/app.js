function spaceshipCrafting() {

	let titanium = document.getElementById('titaniumCoreFound').value;
	let aluminium = document.getElementById('aluminiumCoreFound').value;
	let magnesium = document.getElementById('magnesiumCoreFound').value;
	let carbon = document.getElementById('carbonCoreFound').value;
	let lossesPercent = document.getElementById('lossesPercent').value / 4;

	let titaniumBar = Math.round((titanium - titanium * lossesPercent / 100) / 25);
	let aluminiumBar = Math.round((aluminium - aluminium * lossesPercent / 100) / 50);
	let magnesiumBar = Math.round((magnesium - magnesium * lossesPercent / 100) / 75);
	let carbonBar = Math.round((carbon - carbon * lossesPercent / 100) / 100);

	let availableBars = document.getElementsByTagName('p')[0];
	let builtSpaceshipsSection = document.getElementsByTagName('p')[1];

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

	availableBars.textContent = `${titaniumBar} titanium bars, ${aluminiumBar} aluminum bars, ${magnesiumBar} magnesium bars, ${carbonBar} carbon bars`;

	let builtSpaceships = spaceships.filter(s => s[1] > 0);

	result = [];

	for (let i = 0; i < builtSpaceships.length; i++) {
		result.push(`${builtSpaceships[i][1]} ${builtSpaceships[i][0]}`);
	}

	builtSpaceshipsSection.textContent = result.join(', ');
}