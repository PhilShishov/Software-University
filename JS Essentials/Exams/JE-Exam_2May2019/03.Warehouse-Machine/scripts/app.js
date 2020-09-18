function coffeeStorage() {
    let input = JSON.parse(document.getElementsByTagName('textarea')[0].value);
    let reportSection = document.getElementsByTagName('p')[0];
    let inspectionSection = document.getElementsByTagName('p')[1];

    let warehouse = {};

    for (const line of input) {
        [command, brand, coffee, expireDate, quantity] = line.split(',');

        quantity = Number(quantity);

        let currentCoffee = {
            brand,
            coffee,
            expireDate,
            quantity
        }

        switch (command) {
            case 'IN':
                if (!warehouse[brand]) {
                    warehouse[brand] = {};
                }
                if (!warehouse[brand][coffee]) {
                    warehouse[brand][coffee] = currentCoffee;
                } else if (warehouse[brand][coffee]) {
                    if (warehouse[brand][coffee].expireDate < currentCoffee.expireDate) {
                        warehouse[brand][coffee] = currentCoffee;
                    } else if (warehouse[brand][coffee].expireDate === currentCoffee.expireDate) {
                        warehouse[brand][coffee].quantity += +currentCoffee.quantity;
                    }
                }
                break;
            case 'OUT':
                if (warehouse[brand] && warehouse[brand][coffee]) {
                    if (warehouse[brand][coffee].expireDate > currentCoffee.expireDate &&
                        warehouse[brand][coffee].quantity > 0) {
                        warehouse[brand][coffee].quantity -= +currentCoffee.quantity;
                    }
                }
                break;
            case 'REPORT':
                for (const brand in warehouse) {
                    reportSection.innerHTML += `${brand}: `;

                    for (const info in warehouse[brand]) {
                        reportSection.innerHTML += `${warehouse[brand][info].coffee} - ${warehouse[brand][info].expireDate} - ${warehouse[brand][info].quantity}.`;
                    }

                    reportSection.innerHTML += '</br>';
                }
                break;
            case 'INSPECTION':
                const orderedWarehouse = {};

                Object.keys(warehouse).sort().forEach((key) => {
                    orderedWarehouse[key] = warehouse[key];
                });

                for (const brand in orderedWarehouse) {
                    inspectionSection.innerHTML += `${brand}: `;

                    const sortedBrand = Object.keys(warehouse[brand])
                        .sort((a, b) => warehouse[brand][b].quantity - warehouse[brand][a].quantity
                        );

                    for (const info of sortedBrand) {
                        inspectionSection.innerHTML += `${warehouse[brand][info].coffee} - ${warehouse[brand][info].expireDate} - ${warehouse[brand][info].quantity}.`;
                    }

                    inspectionSection.innerHTML += '</br>';
                }
                break;
        }
    }
    console.log(warehouse);
}