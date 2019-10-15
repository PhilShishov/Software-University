function fruit(fruitType, weightG, priceKg) {

    let weightKg = weightG / 1000;
    let money = weightKg * priceKg;

    console.log(`I need $${money.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruitType}.`);
}

fruit('orange', 2500, 1.80);
fruit('apple', 1563, 2.35);