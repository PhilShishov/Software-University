// function concrete(budget, concrete, discount) {

//     const gravelPerKg = 0.50;
//     const sandPerKg = 0.20;
//     const cementPerKg = 1.10;

//     const gravel = concrete * 1200;
//     const sand = concrete * 750;
//     const cement = concrete * 300;

//     const gravelPrice = gravelPerKg * gravel;
//     const sandPrice = sandPerKg * sand;
//     const cementPrice = cementPerKg * cement;

//     let price = gravelPrice + sandPrice + cementPrice;
//     let priceWithDiscount = 0;
//     let usedDiscount = false;

//     if (price > 1000) {
//         usedDiscount = true;
//         priceWithDiscount = price - (price * (discount / 100));
//     }

//     if (budget > priceWithDiscount) {
//         if (price > 1000) {
//             console.log(`The price without discount is ${price.toFixed(2)} BGN`);
//             console.log(`Gravel: ${gravelPrice.toFixed(2)} BGN`);
//             console.log(`Sand: ${sandPrice.toFixed(2)} BGN`);
//             console.log(`Cement: ${cementPrice.toFixed(2)} BGN`);
//             console.log(`The price with discount is ${priceWithDiscount.toFixed(2)} BGN`);
//         }
//         else {
//             console.log(`The price without discount is ${price.toFixed(2)} BGN`);
//             console.log(`Gravel: ${gravelPrice.toFixed(2)} BGN`);
//             console.log(`Sand: ${sandPrice.toFixed(2)} BGN`);
//             console.log(`Cement: ${cementPrice.toFixed(2)} BGN`);
//         }
//     }

//     else if (budget <= priceWithDiscount) {
//         let money = 0;
//         if (price > 1000) {
//             money = priceWithDiscount - budget;
//             console.log(`You can't buy all these things! You need ${money.toFixed(2)} BGN more`)

//         } else {
//             money = price - budget;
//             console.log(`You can't buy all these things! You need ${money.toFixed(2)} BGN more`)
//         }
//     }
// }


function concrete(budget, concrete, discount) {

    const gravelPerKg = 0.50;
    const sandPerKg = 0.20;
    const cementPerKg = 1.10;

    const gravel = concrete * 1200;
    const sand = concrete * 750;
    const cement = concrete * 300;

    const gravelPrice = gravelPerKg * gravel;
    const sandPrice = sandPerKg * sand;
    const cementPrice = cementPerKg * cement;

    let price = gravelPrice + sandPrice + cementPrice;
    let priceWithDiscount = 0;
    let usedDiscount = false;

    if (price > 1000) {
        usedDiscount = true;
        priceWithDiscount = price - (price * (discount / 100));
    }

    if (budget < priceWithDiscount) {
        money = priceWithDiscount - budget;
        console.log(`You can't buy all these things! You need ${money.toFixed(2)} BGN more`)
    } else {
        console.log(`The price without discount is ${price.toFixed(2)} BGN`);
        console.log(`Gravel: ${gravelPrice.toFixed(2)} BGN`);
        console.log(`Sand: ${sandPrice.toFixed(2)} BGN`);
        console.log(`Cement: ${cementPrice.toFixed(2)} BGN`);

        if (usedDiscount) {
            console.log(`The price with discount is ${priceWithDiscount.toFixed(2)} BGN`);
        }
    }
}

concrete(1500, 0.5, 10);

concrete(1500, 0.95, 3);

concrete(800, 3, 10);