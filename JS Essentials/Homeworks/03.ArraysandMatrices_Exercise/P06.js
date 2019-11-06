
function solve(arr) {

    arr.sort((a, b) => {
        return a.length - b.length || a.localeCompare(b); //a > b
    }).forEach(x=>console.log(x));
}

solve(['alpha', 
'beta', 
'gamma']
);