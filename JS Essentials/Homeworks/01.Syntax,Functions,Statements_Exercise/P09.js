function coffeeMachine(input) {

    let totalMoney = 0;

    for (let order of input) {

        let price = 0.80;
        let [coins, drink, coffeeType, milk, sugar] = order.split(', ');

        if (order.includes('decaf')) {
            price += 0.10;
        }
        if (order.includes('milk')) {
            price += 0.10;
        }
        if (Number(order.split(', ').pop()) > 0) {
            price += 0.10;
        }
        if (coins >= price) {
            console.log(`You ordered ${drink}. Price: $${price.toFixed(2)} Change: $${(coins - price).toFixed(2)}`)
            totalMoney += price;
        } else {
            console.log(`Not enough money for ${drink}. Need $${(Math.abs(price - coins)).toFixed(2)} more.`)
        }
    }

    console.log(`Income Report: $${totalMoney.toFixed(2)}`);
}

coffeeMachine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);
coffeeMachine(['8.00, coffee, decaf, 4', '1.00, tea, 2']);