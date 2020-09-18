
function solve(input) {

    let lastStep = Number(input.pop());
    
    for (let i = 0; i < input.length; i += lastStep) {
        console.log(input[i]);
    }
}

solve(['1', 
'2',
'3', 
'4', 
'5', 
'6']
);