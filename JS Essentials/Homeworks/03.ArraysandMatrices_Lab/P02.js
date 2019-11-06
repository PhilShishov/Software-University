
function solve(arr) {

    let result = "";

    for (let i = 0; i < arr.length; i++) {       
        if (i % 2 === 0) {            
            result += arr[i] + " ";
        }
    }

    console.log(result);
    
}

solve(['5', '10']);
solve(['JS']);