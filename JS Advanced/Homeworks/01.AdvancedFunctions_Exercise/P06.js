function breakfastRobot() {
    return (function () {
        const ingredientsObj = {
            protein: 0,
            carbohydrate: 0,
            fat: 0,
            flavour: 0,
        };

        const recipesObj = {
            'apple': { carbohydrate: 1, flavour: 2 },
            'lemonade': { carbohydrate: 10, flavour: 20 },
            'burger': { carbohydrate: 5, fat: 7, flavour: 3 },
            'eggs': { protein: 5, fat: 1, flavour: 1 },
            'turkey': { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
        };

        function restock(ingredient, quantity) {
            ingredientsObj[ingredient] += +quantity;
            return 'Success';
        }

        function prepare(recipe, neededQuantity) {
            const neededIngredients = Object.entries(recipesObj[recipe]);

            for (const [ingredient, quantity] of neededIngredients) {
                const storedIngredient = ingredientsObj[ingredient] * neededQuantity;

                if (quantity > storedIngredient) {
                    return `Error: not enough ${ingredient} in stock`;
                }
            }

            for (const [ingredient, quantity] of neededIngredients) {
                ingredientsObj[ingredient] -= quantity * neededQuantity;
            }

            return 'Success';
        }

        function report() {
            return Object.entries(ingredientsObj)
                .map(kvp => `${kvp[0]}=${kvp[1]}`)
                .join(' ');
        }

        return function (input) {
            const tokens = input.split(' ');
            const command = tokens[0];

            switch (command) {
                case "prepare":
                    return prepare(tokens[1], +tokens[2]);

                case "restock":
                    return restock(tokens[1], +tokens[2]);

                case "report":
                    return report();
            }
        }
    })();
}

let manager = breakfastRobot();
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));