
function solve(matrix) {
    
    let maxNum = Number.MIN_SAFE_INTEGER;

    for (let arr of matrix) {
        let currentMaxNum =  arr.reduce(function(a, b) {
            return Math.max(a, b);
        });

        if (currentMaxNum > maxNum) {
            maxNum = currentMaxNum;
        }        
    }    
    console.log(maxNum);
    
}

solve([[20, 50, 10],
    [8, 33, 145]]
   );