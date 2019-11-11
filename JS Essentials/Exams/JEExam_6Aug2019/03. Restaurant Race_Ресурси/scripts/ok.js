function solve() {

	let input = JSON.parse(document.querySelector('textarea').value);

	let workers = {};
	let restaurants = {};

	let totalSalary = 0;

	for (let element of input) {

		let info = element.split('- ');
		let restaurant = info[0];
		let workerInfoTokens = info[1].split(', ');
		let workerInfo = workerInfoTokens[0].split(" ");

		let worker = workerInfo[0];
		let salary = workerInfo[1];
		totalSalary += +salary;
		let workersCount = Object.keys(workers).length;
		let averageSalary = totalSalary / workersCount;

		let currentWorker = {
			worker,
			salary
		};

		let currentRestaurant = {
			restaurant,
			workers,
			averageSalary
		}

		addWorker(currentWorker);
		addRestaurant(currentRestaurant);
	}

	function addWorker(currentWorker) {
		let worker = currentWorker.worker;
		let salary = currentWorker.salary;

		if (!workers[worker]) {
			workers[worker] = currentWorker;
		}
	}

	function addRestaurant(currentRestaurant) {
		let restaurant = currentRestaurant.restaurant;
		let workers = currentRestaurant.workers;
		let averageSalary = currentRestaurant.averageSalary;

		if (!restaurants[restaurant]) {
			restaurants[restaurant] = currentRestaurant;
		}
	}

	let restaurantSection = document.getElementsByTagName('p')[0];
	let workerSection = document.getElementsByTagName('p')[1];

	let btn = document.getElementById('btnSend');

	btn.addEventListener('click', getBestRestaurant());

	function getBestRestaurant() {

		const bestRest = Object.keys(restaurants).reduce((a, b) => restaurants[a] > restaurants[b] ? a : b);

		restaurantSection.textContent = `Name: ${bestRest} Average Salary: ${bestRest.averageSalary} Best  Salary: `;

	}
}