function concrete(budget, concrete, discount) {

    let gravelPrice = 0.50;
    let sandPrice = 0.20;
    let cementPrice = 1.10;

    let gravelPerM2 = 120 * (concrete * 10);
    let sandPerM2 = 75 * (concrete * 10);
    let cementPerM2 = 30 * (concrete * 10);

    gravelPrice *= gravelPerM2;
    sandPrice *= sandPerM2;
    cementPrice *= cementPerM2;

    let price = gravelPrice + sandPrice + cementPrice;
    let priceWithDiscount = 0;
    let isDiscount = false;

    if (price > 1000) {
        isDiscount = true;
        // gravelPrice -= gravelPrice * discount / 100;
        // sandPrice -= sandPrice * discount / 100;
        // cementPrice -= cementPrice * discount / 100;
        // priceWithDiscount = gravelPrice + sandPrice + cementPrice;
        priceWithDiscount = price - (price * (discount / 100));
    }

    if (budget >= price) {
        console.log(`The price without discount is ${price.toFixed(2)} BGN`);
        console.log(`Gravel: ${(Math.round(gravelPrice * 100) / 100).toFixed(2)} BGN`);
        console.log(`Sand: ${(Math.round(sandPrice * 100) / 100).toFixed(2)} BGN`);
        console.log(`Cement: ${(Math.round(cementPrice * 100) / 100).toFixed(2)} BGN`);
        if (isDiscount) {
            console.log(`The price with discount is ${priceWithDiscount.toFixed(2)} BGN`);
        }

    } else {
        console.log(`You can't buy all these things! You need ${(priceWithDiscount - budget).toFixed(2)} BGN more`);
    }
}

concrete(1500, 0.5, 10);
concrete(1500, 0.95, 3);
concrete(800, 3, 10);