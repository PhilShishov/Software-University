
function calorieObject (input) {
    let obj = {};

    for (let i = 0; i < input.length; i+=2) {
        obj[input[i]] = +input[i + 1];        
    }
    
    console.log(obj);
}

calorieObject(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);
calorieObject(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);