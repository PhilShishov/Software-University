
function GCD(a, b) {

    a = +a;
    b = +b;

    let greatestDivisor = 0;

    for (let i = 1; i <= Math.min(a, b); i++) {

        if (a % i === 0 && b % i === 0) {

            greatestDivisor = i;
        }
    }

    console.log(greatestDivisor);
}

GCD('15', 5);