function coffeeMachine(input) {
    
    let totalSum = 0;
    for (let tokens of input) {

        let [coins, drink, type, milk, sugar] = tokens.split(', ');

        let price = 0.80;

        if (tokens.includes('decaf')) {
            price += 0.10;
        }

        if (tokens.includes('milk')) {
            price += 0.10;
        }

        if (Number(tokens.split(', ').pop()) > 0) {
            price += 0.10;
        }

        let difference = Math.abs(price - Number(coins));

        if (+coins >= price) {
            console.log(`You ordered ${drink}. Price: ${price.toFixed(2)}$ Change: ${difference.toFixed(2)}$`)
            totalSum += price;
        }
        else if (+coins < price) {
            console.log(`Not enough money for ${drink}. Need ${difference.toFixed(2)}$ more.`)
        }
    }

    console.log(`Income Report: ${totalSum.toFixed(2)}$`)

}

coffeeMachine(['1.00, coffee, caffeine, milk, 4',
    '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']
)