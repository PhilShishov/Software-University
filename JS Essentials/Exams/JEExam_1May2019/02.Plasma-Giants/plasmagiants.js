function plasmaGiants(plasmaArr, cutSize) {

    if (cutSize === 0) {
        return;
    }

    const halfway = Math.floor(plasmaArr.length / 2);

    let firstGiantArr = plasmaArr.slice(0, halfway);
    let secondGiantArr = plasmaArr.slice(halfway, plasmaArr.length);

    let firstGiantArrSpl = splitIntoNArray(firstGiantArr);
    let secondGiantArrSpl = splitIntoNArray(secondGiantArr);

    let firstGiant = getTotalProduct(firstGiantArrSpl);
    let secondGiant = getTotalProduct(secondGiantArrSpl);

    const damagePerHit = Math.min.apply(0, plasmaArr);
    const endPoint = Math.max.apply(0, plasmaArr);
    let rounds = 1;

    while (firstGiant > endPoint && secondGiant > endPoint && damagePerHit > 0) {
        firstGiant -= damagePerHit;
        secondGiant -= damagePerHit;
        rounds++;
    }

    if (firstGiant > secondGiant) {
        console.log(`First Giant defeated Second Giant with result ${firstGiant} - ${secondGiant} in ${rounds} rounds`);
    } else if (secondGiant > firstGiant) {
        console.log(`Second Giant defeated First Giant with result ${secondGiant} - ${firstGiant} in ${rounds} rounds`);
    } else {
        console.log(`Its a draw ${firstGiant} – ${secondGiant}`);
    }

    function getTotalProduct(giantArr) {
        let total = 0;

        for (const arr of giantArr) {
            total += arr.reduce((a, b) => a * b);
        }
        return total;
    }

    function splitIntoNArray(giantArr) {
        let splittedArr = [];
        while (giantArr.length) {
            let arr = giantArr.splice(0, cutSize);
            splittedArr.push(arr);
        }

        return splittedArr;
    }
}

// plasmaGiants([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12], 3);
plasmaGiants([3, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 2);
plasmaGiants([4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4], 2);
plasmaGiants([3, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 0);
plasmaGiants([0, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 2);