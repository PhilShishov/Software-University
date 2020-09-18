
function main(input) {
    // let delimiter = input[input.lenght - 1];
    // input.pop();

    // let result = "";

    // for (let i = 0; i < input.length; i++) {
    //     if (i == 0) {
    //         result += input[i];
    //     } else {
    //         result += delimiter + input[i];
    //     }
    // }
    // console.log(result);

    console.log(input.filter((x, i) => i !== input.length - 1).join(input[input.length - 1]));
}

main(['One', 'Two', 'Three', 'Four', 'Five', '-']);