function getData() {

	const input = JSON.parse(document.querySelector('textarea').value);

	const peopleInSection = document.querySelector('#peopleIn p');
	const blacklistSection = document.querySelector('#blacklist p');
	const peopleOutSection = document.querySelector('#peopleOut p');

	let lastElement = input.pop();

	let peopleIn = [];
	let peopleOut = [];
	let blacklist = [];

	for (let person of input) {

		let firstName = person.firstName;
		let lastName = person.lastName;
		let action = person.action;

		let currentPerson = {
			firstName,
			lastName
		};
		let index = peopleIn.findIndex(p => p.firstName === currentPerson.firstName &&
			p.lastName === currentPerson.lastName);

		if (action === "peopleIn") {
			if (!isPerson(blacklist, currentPerson)) {
				peopleIn.push(currentPerson);
			}

		} else if (action === "peopleOut") {
			if (isPerson(peopleIn, currentPerson)) {

				peopleIn.splice(index, 1);
				peopleOut.push(currentPerson);
			}
		} else if (action === "blacklist") {
			if (isPerson(peopleIn, currentPerson)) {

				peopleIn.splice(index, 1);
				peopleOut.push(currentPerson);
			}
			blacklist.push(currentPerson);
		}
	}

	let output = {};

	output['peopleIn'] = peopleIn;
	output['peopleOut'] = peopleOut;
	output['blacklist'] = blacklist;

	if (lastElement.action !== '' && lastElement.criteria !== '') {
		let criteria = lastElement.criteria;
		output[lastElement.action] = output[lastElement.action]
			.sort((a, b) => a[criteria]
				.localeCompare(b[criteria]));
	}

	mapTextContent(peopleInSection, output.peopleIn);
	mapTextContent(peopleOutSection, output.peopleOut);
	mapTextContent(blacklistSection, output.blacklist);

	function mapTextContent(section, output) {
		section.textContent = output
		.map(p => JSON.stringify(p))
		.join(' ');
	}

	function isPerson(currentArr, currentPerson) {
		return currentArr.find(p => p.firstName === currentPerson.firstName &&
			p.lastName === currentPerson.lastName)
	}
}