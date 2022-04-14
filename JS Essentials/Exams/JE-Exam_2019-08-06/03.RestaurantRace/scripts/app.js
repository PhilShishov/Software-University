function solve() {
    const sendButton = document.getElementById('btnSend');
    sendButton.addEventListener('click', displayTheBestRestaurant);

    function displayTheBestRestaurant() {
        const array = JSON.parse(document.getElementsByTagName('textarea')[0].value);
        const restaurants = [];

        for (let i = 0; i < array.length; i++) {
            const args = array[i].split(' - ');
            const name = args[0];

            const restaurant = {
                name,
                workers: [],
            };

            const workers = args[1].split(', ');

            for (const worker of workers) {
                const nameAndSalary = worker.split(' ');
                const name = nameAndSalary[0];
                const salary = +nameAndSalary[1];
                restaurant.workers.push({name, salary});
            }

            restaurant.averageSalary = getAverageSalary(restaurant.workers);
            restaurant.bestSalary = getBestSalary(restaurant.workers);

            const index = restaurants.findIndex(r => r.name === restaurant.name);

            if (index === -1) {
                restaurants.push(restaurant);
            } else {
                restaurants[index].workers.push(...restaurant.workers);
                restaurants[index].averageSalary = getAverageSalary(restaurants[index].workers);
                restaurants[index].bestSalary = getBestSalary(restaurants[index].workers);
            }
        }

        restaurants.sort((a, b) => b.averageSalary - a.averageSalary);

        const bestRestaurant = document
            .getElementById('bestRestaurant')
            .getElementsByTagName('p')[0];

		bestRestaurant.textContent = 
		`Name: ${restaurants[0].name} Average Salary: ${restaurants[0].averageSalary.toFixed(2)} Best Salary: ${restaurants[0].bestSalary.toFixed(2)}`;

        const workers = document
            .getElementById('workers')
            .getElementsByTagName('p')[0];

        restaurants[0].workers.sort((a, b) => b.salary - a.salary);
        let result = [];

        for (const worker of restaurants[0].workers) {
            result.push(`Name: ${worker.name} With Salary: ${worker.salary}`);
        }

        workers.textContent = result.join(' ');
    }

    function getAverageSalary(workers) {
        let averageSalary = 0;
        workers.forEach(worker => averageSalary += worker.salary);
        return averageSalary / workers.length;
    }

    function getBestSalary(workers) {
		bestSalaryWorker = workers.sort((a, b) => b.salary - a.salary)[0];
        return bestSalaryWorker.salary;
    }
}