// let functionalSum = (function(){
//     let sum = 0;

//     return function add(number){
//         sum+=number;
//         add.toString = function(){
//             return sum
//         };
//         return add;
//     }
// })();


// console.log(functionalSum(1)(6)(-3).toString());

function add(num) {
    let sum = num;

    const calc = num2 => {
        sum += num2;
        return calc;
    };

    calc.toString = () => sum;
    return calc;
}

console.log(add(1).toString());
console.log(add(1)(6)(-3).toString());