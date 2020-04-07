function getData() {
    const input = JSON.parse(document.getElementsByTagName('textarea')[0].value);

    const peopleInSection = document.getElementById('peopleIn').getElementsByTagName('p')[0];
    const peopleOutSection = document.getElementById('peopleOut').getElementsByTagName('p')[0];
    const blacklistSection = document.getElementById('blacklist').getElementsByTagName('p')[0];

    let peopleIn = [];
    let peopleOut = [];
    let blacklist = [];

    const lastElement = input.pop();

    for (const line of input) {

        let firstName = line.firstName;
        let lastName = line.lastName;
        let action = line.action;

        let person = {
            firstName,
            lastName
        };

        let index = peopleIn.findIndex(p => p.firstName === person.firstName &&
            p.lastName === person.lastName);

        switch (action) {
            case 'peopleIn':
                if (!doesExist(blacklist, person)) {
                    peopleIn.push(person);
                }
                break;
            case 'peopleOut':
                if (index > -1) {
                    peopleIn.splice(index, 1);
                    peopleOut.push(person);
                }
                break;
            case 'blacklist':
                if (index > -1) {
                    peopleIn.splice(index, 1);
                    peopleOut.push(person);
                }
                blacklist.push(person);
                break;
        }
    }

    if (lastElement.action !== '' && lastElement.criteria !== '') {

        switch (lastElement.action) {
            case 'peopleIn':
                peopleIn.sort((a, b) => a[lastElement.criteria]
                    .localeCompare(b[lastElement.criteria]));
                break;
            case 'peopleOut':
                peopleOut.sort((a, b) => a[lastElement.criteria]
                    .localeCompare(b[lastElement.criteria]));
                break;
            case 'blacklist':
                blacklist.sort((a, b) => a[lastElement.criteria]
                    .localeCompare(b[lastElement.criteria]));
                break;
        }
    }

    for (const person of peopleIn) {
        peopleInSection.innerHTML += JSON.stringify(person) + ' ';
    }

    for (const person of peopleOut) {
        peopleOutSection.innerHTML += JSON.stringify(person) + ' ';
    }

    for (const person of blacklist) {
        blacklistSection.innerHTML += JSON.stringify(person) + ' ';
    }

    function doesExist(currentArr, currentPerson) {
        return currentArr.find(p => p.firstName === currentPerson.firstName &&
            p.lastName === currentPerson.lastName)
    }
}