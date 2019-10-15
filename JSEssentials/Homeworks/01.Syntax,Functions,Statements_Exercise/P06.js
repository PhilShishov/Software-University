function roadRadar(inputArr) {

    function checkLimit(area) {
        switch (area) {
            case 'motorway': return 130;
            case 'interstate': return 90;
            case 'city': return 50;
            case 'residential': return 20;
        }
    }

    let result = '';
    let [speed, area] = inputArr;

    let speedLimit = checkLimit(area);
    let overLimit = speed - speedLimit;

    if (overLimit > 0) {
        if (overLimit <= 20) {
            result = 'speeding';
        } else if (overLimit <= 40) {
            result = 'excessive speeding';
        } else {
            result = 'reckless driving';
        }
    }

    console.log(result);
}

roadRadar([40, 'city']);
roadRadar([21, 'residential']);
roadRadar([120, 'interstate']);
roadRadar([200, 'motorway']);