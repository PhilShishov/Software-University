
function solve(input) {

    let rotation = Number(input.pop());

    for (let i = 0; i < rotation % input.length; i++) {
        let lastElement = input.pop();
        input.unshift(lastElement);
    }
    console.log(input.join(" "));

}

solve(['1',
    '2',
    '3',
    '4',
    '2']
);