function coffeeMachine(input) {

    for (const order of input) {
        let [coins, drink, decaf, milk, sugar] = order.split(', ');

        console.log(coins);
    }

}

coffeeMachine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']
);
coffeeMachine(['8.00, coffee, decaf, 4',
    '1.00, tea, 2']
);
