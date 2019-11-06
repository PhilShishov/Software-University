function solve(input) {

    let arr = [];
    let number = 1;

    for (let i = 0; i < input.length; i++) {

        let command = input[i];
        if (command === "add") {
            arr.push(number);
        } else {
            arr.pop();
        }
        number++;

    }

    if (arr.length > 0) {
        console.log(arr.join('\n'));

    } else {
        console.log("Empty");

    }
}

solve(['add',
    'add',
    'remove',
    'add',
    'add']
);