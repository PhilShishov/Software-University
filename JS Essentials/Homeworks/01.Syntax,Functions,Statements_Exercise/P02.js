
// function GCD_Stein(a, b) {

//     let greatestDivisor = 0;

//     for (let i = 1; i <= Math.min(a, b); i++) {

//         if (a % i === 0 && b % i === 0) {

//             greatestDivisor = i;
//         }
//     }

//     console.log(greatestDivisor);
// }

function GCD_Euclid(a, b) {

    while (a != b) {
        if (a > b) {
            a = a - b;
        } else if (b > a) {
            b = b - a;
        }
    }

    console.log(a);
}

GCD(15, 5);
GCD(2154, 458);