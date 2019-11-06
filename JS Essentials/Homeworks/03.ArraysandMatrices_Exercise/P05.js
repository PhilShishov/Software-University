
function solve(input) {

    let currentMaxNum = input[0];
    console.log(currentMaxNum);
    

    for (let i = 1; i < input.length; i++) {
        if (input[i] >= currentMaxNum) {
            console.log(input[i]);
            currentMaxNum = input[i];
        }
    }    
}

solve([20, 
    3, 
    2, 
    15,
    6, 
    1]
      
    );