function stringLength(firstString, secondString, thirdString) {

    let sumLength;
    let averageLength;

    let firstStringLength = firstString.length; 
    let secondStringLength = secondString.length; 
    let thirdStringLength = thirdString.length; 


    sumLength = firstStringLength + secondStringLength + thirdStringLength;
    averageLength = Math.round(sumLength / 3);

    console.log(sumLength);
    console.log(averageLength);
}

stringLength('chocolate', 'ice cream', 'cake');
stringLength('pasta', '5', '22.3');

