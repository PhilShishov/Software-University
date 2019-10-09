
function calorieObject (input) {
    let obj = {};

    for (let i = 0; i < input.length; i+=2) {
        obj[input[i]] = +input[i + 1];
        
    }

    console.log(obj);
}