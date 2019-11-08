function spaceshipCrafting() {
	let titanium = document.getElementById('titaniumCoreFound').value;
	let aluminium = document.getElementById('aluminiumCoreFound').value;
	let magnesium = document.getElementById('magnesiumCoreFound').value;
	let carbon = document.getElementById('carbonCoreFound').value;
	let losses = document.getElementById('lossesPercent').value / 4;

	let availableBarsSection = document.getElementsByTagName('p')[0];
	let builtSpaceshipsSection = document.getElementsByTagName('p')[1];

	titanium -= titanium * losses / 100;
	aluminium -= aluminium * losses / 100;
	magnesium -= magnesium * losses / 100;
	carbon -= carbon * losses / 100;

	let titaniumBars = Math.round(titanium / 25);
	let aluminiumBars = Math.round(aluminium / 50);
	let magnesiumBars = Math.round(magnesium / 75);
	let carbonBars = Math.round(carbon / 100);

	const spaceships = [
		['THE-UNDEFINED-SHIP', 0],
		['NULL-MASTER', 0],
		['JSON-CREW', 0],
		['FALSE-FLEET', 0]
	];

	while (titaniumBars >= 2 && aluminiumBars >= 2 && magnesiumBars >= 3 && carbonBars >= 1) {
		if (titaniumBars >= 7 && aluminiumBars >= 9 && magnesiumBars >= 7 && carbonBars >= 7) {
			spaceships[0][1]++;
			titaniumBars -= 7;
			aluminiumBars -= 9;
			magnesiumBars -= 7;
			carbonBars -= 7;
		}

		if (titaniumBars >= 5 && aluminiumBars >= 7 && magnesiumBars >= 7 && carbonBars >= 5) {
			spaceships[1][1]++;
			titaniumBars -= 5;
			aluminiumBars -= 7;
			magnesiumBars -= 7;
			carbonBars -= 5;
		}

		if (titaniumBars >= 3 && aluminiumBars >= 5 && magnesiumBars >= 5 && carbonBars >= 2) {
			spaceships[2][1]++;
			titaniumBars -= 3;
			aluminiumBars -= 5;
			magnesiumBars -= 5;
			carbonBars -= 2;
		}

		if (titaniumBars >= 2 && aluminiumBars >= 2 && magnesiumBars >= 3 && carbonBars >= 1) {
			spaceships[3][1]++;
			titaniumBars -= 2;
			aluminiumBars -= 2;
			magnesiumBars -= 3;
			carbonBars -= 1;
		}
	}

	availableBarsSection.textContent = `${titaniumBars} titanium bars, ` +
		`${aluminiumBars} aluminum bars, ` +
		`${magnesiumBars} magnesium bars, ` +
		`${carbonBars} carbon bars`;

	let builtSpaceships = spaceships.filter(s => s[1] > 0);

	let result = [];

	for (let i = 0; i < builtSpaceships.length; i++) {
		result.push(`${builtSpaceships[i][1]} ${builtSpaceships[i][0]}`);
	}

	builtSpaceshipsSection.textContent = result.join(', ');
}