const currencyFormatter = require('./formatter');

function getDollarFormatter(formatter) {
    return function (value) {
        return formatter(',', '$', true, value);
    }
}

function getEuroFormatter(formatter) {
    return function (value) {
        return formatter(',', '€', true, value);
    }
}

const dollarFormatter = getDollarFormatter(currencyFormatter);
const euroFormatter = getEuroFormatter(currencyFormatter);

console.log(dollarFormatter(100));
console.log(euroFormatter(30));