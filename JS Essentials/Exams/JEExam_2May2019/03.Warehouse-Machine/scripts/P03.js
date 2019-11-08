function coffeeStorage() {
    let brands = {};

    const input = JSON.parse(document.getElementsByTagName('textarea')[0].value);
    let reportSection = document.getElementsByTagName('p')[0];
    let inspectSection = document.getElementsByTagName('p')[1];

    for (const element of input) {
        const brandInfo = element.split(', ');
        const command = brandInfo[0];
        const brand = brandInfo[1];
        const coffee = brandInfo[2];
        const expireDate = brandInfo[3];
        const quantity = brandInfo[4];

        let currentBrand = {
            brand,
            coffee,
            expireDate,
            quantity
        };

        switch (command) {
            case "IN":
                add(currentBrand);
                break;
            case "OUT":
                remove(currentBrand);
                break;
            case "REPORT":
                report();
                break;
            case "INSPECTION":
                inspect();
                break;
        }
    }
    function add(currentBrand) {
        const brand = currentBrand.brand;
        const coffee = currentBrand.coffee;
        const expireDate = currentBrand.expireDate;
        const quantity = currentBrand.quantity;

        if (!brands[brand]) {
            brands[brand] = {};
        }

        if (!brands[brand][coffee]) {
            brands[brand][coffee] = currentBrand;

        } else {
            if (expireDate > brands[brand][coffee].expireDate) {
                brands[brand][coffee] = currentBrand;

            } else if (expireDate === brands[brand][coffee].expireDate) {
                brands[brand][coffee].quantity += quantity;
            }
        }
    }

    function remove(currentBrand) {
        const brand = currentBrand.brand;
        const coffee = currentBrand.coffee;
        const expireDate = currentBrand.expireDate;
        const quantity = currentBrand.quantity;

        if (brands[brand] && brands[brand][coffee]) {
            if (brands[brand][coffee].expireDate > expireDate
                && brands[brand][coffee].quantity >= quantity) {
                brands[brand][coffee].quantity -= quantity;
            }
        }
    }

    function report() {
        for (const brand in brands) {
            let result = `${brand}:`;

            for (const info in brands[brand]) {
                result += ` ${brands[brand][info].coffee} - ${brands[brand][info].expireDate} - ${brands[brand][info].quantity}.`;
            }

            result += '</br>';
            reportSection.innerHTML += result;
        }
    }

    function inspect() {
        const sortedBrands = Object.keys(brands)
            .sort((a, b) => (a).localeCompare(b));

        for (const brand of sortedBrands) {
            let result = `${brand}:`;

            const sortedInfo = Object.keys(brands[brand])
                .sort((a, b) => brands[brand][b].quantity - brands[brand][a].quantity);

            for (const info of sortedInfo) {
                result += ` ${brands[brand][info].coffee} - ${brands[brand][info].expireDate} - ${brands[brand][info].quantity}.`;
            }

            result += '</br>';
            inspectSection.innerHTML += result;
        }
    }

}