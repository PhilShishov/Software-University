
function solve(arr) {
    
    let first = arr.shift();
    let firstNums = arr.slice(0, first);
    let secondNums = arr.slice(arr.length - first, arr.length);


    // let result1 = "";
    // let result2 = "";
    
    // for (let i = 0; i < first; i++) {
    //     result1 += arr[i] + " ";     
        
    // }
    // for (let i = arr.length - first; i <= first; i++) {
    //     result2 += arr[i] + " ";         
    // }

    console.log(firstNums.join(" "));
    console.log(secondNums.join(" "));    
}

solve([3, 6, 7, 8, 9]);