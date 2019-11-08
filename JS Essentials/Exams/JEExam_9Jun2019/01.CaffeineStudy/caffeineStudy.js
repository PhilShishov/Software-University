function caffeineStudy(days) {

    let consumedCaffeine = 0;
    let coffeeCaffeine = 40;
    let colaCaffeine = 8;
    let teaCaffeine = 20;
    let energyCaffeine = 30;

    let consumedCoffee = ((3 * 150) / 100) * coffeeCaffeine;
    let consumedCola = ((2 * 250) / 100) * colaCaffeine;
    let consumedTea = ((3 * 350) / 100) * teaCaffeine;
    let consumedEnergy = ((3 * 500) / 100) * energyCaffeine;

    for (let i = 1; i <= days; i++) {

        consumedCaffeine += consumedCoffee + consumedCola + consumedTea;

        if (i % 5 == 0) {
            consumedCaffeine += consumedEnergy;
        }

        if (i % 9 == 0) {
            consumedCaffeine += consumedCola * 2;
            consumedCaffeine += 300;
        }
    }

    console.log(`${consumedCaffeine} milligrams of caffeine were consumed`);
}

caffeineStudy(1);
caffeineStudy(5);
caffeineStudy(8);
caffeineStudy(9);