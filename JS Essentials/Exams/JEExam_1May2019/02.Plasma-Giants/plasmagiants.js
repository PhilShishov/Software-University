function plasmaGiants(plasmaArr, sizeCut) {

    if (sizeCut === 0) {
        return;
    }    

    const halfwayThrough = Math.floor(plasmaArr.length / 2);

    let firstGiantArr = plasmaArr.slice(0, halfwayThrough);
    let secondGiantArr = plasmaArr.slice(halfwayThrough, plasmaArr.length);

    let firstGiantArrSplit = splitArrayIntoNArrays(firstGiantArr, sizeCut);
    let secondGiantArrSplit = splitArrayIntoNArrays(secondGiantArr, sizeCut);

    let firstGiant = getTotalProductArr(firstGiantArrSplit);
    let secondGiant = getTotalProductArr(secondGiantArrSplit);

    makeFight();

    function makeFight() {

        const minDamage = Math.min(...plasmaArr);
        const maxNum = Math.max(...plasmaArr);
        let rounds = 1;
        while (firstGiant > maxNum && secondGiant > maxNum && minDamage != 0) {
            rounds++;
            firstGiant -= minDamage;
            secondGiant -= minDamage;
        }
        if (firstGiant > secondGiant) {
            console.log(`First Giant defeated Second Giant with result ${firstGiant} - ${secondGiant} in ${rounds} rounds`);
        }
        else if (secondGiant > firstGiant) {
            console.log(`Second Giant defeated First Giant with result ${secondGiant} - ${firstGiant} in ${rounds} rounds`);
        }
        else {
            console.log(`Its a draw ${firstGiant} - ${secondGiant}`);
        }
    }

    function getTotalProductArr(giantArrSpl) {
        let total = 0;
        for (let arr of giantArrSpl) {
            total += arr.reduce((a, b) => a * b);
        }
        return total;
    }

    function splitArrayIntoNArrays(giantArr, sizeCut) {
        let splittedArr = [];

        while (giantArr.length) {
            splittedArr.push(giantArr.splice(0, sizeCut));
        }

        return splittedArr;
    }
}

plasmaGiants([0, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 2);
plasmaGiants([3, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 0);
plasmaGiants([3, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 2);
plasmaGiants([4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4], 2);