function caffeineStudy(days) {

    let coffeeConsumption = ((3 * 150) / 100) * 40;
    let colaConsumption = ((2 * 250) / 100) * 8;
    let teaConsumption = ((3 * 350) / 100) * 20;
    let energyConsumption = ((3 * 500) / 100) * 30;

    let consumedCaffeine = 0;


    for (let day = 1; day <= days; day++) {
        consumedCaffeine += coffeeConsumption + colaConsumption + teaConsumption;

        if (day % 5 === 0) {
            consumedCaffeine += energyConsumption;
        }

        if (day % 9 === 0) {
            consumedCaffeine += colaConsumption * 2;
            consumedCaffeine += 300;
        }
    }

    console.log(`${consumedCaffeine} milligrams of caffeine were consumed`)
}

caffeineStudy(5);
caffeineStudy(8);