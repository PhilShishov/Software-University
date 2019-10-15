function cookingByNumbers(inputArr) {
    let number = +inputArr[0];

    for (let i = 1; i < inputArr.length; i++) {
        let operation = inputArr[i];
        switch (operation) {
            case 'chop': number /= 2;
                break;
            case 'dice': number = Math.sqrt(number);
                break;
            case 'spice': number += 1;
                break;
            case 'bake': number *= 3;
                break;
            case 'fillet': number -= number * 0.20;
                break;
        }
        console.log(number);
    }
}

cookingByNumbers(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
cookingByNumbers(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);