function stringLength(fruit, quantity, priceKilo) {

    let kg = quantity / 1000;
    let money = kg * priceKilo;

    console.log(`I need $${money.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`)

}

stringLength('orange', 2500, 1.80);

