function trainStation(capacity, passengers) {

    let train = [];
    let length = passengers.length;
    let remainingPassengers = 0;

    for (let i = 0; i < length; i++) {

        remainingPassengers += passengers.shift();

        if (remainingPassengers <= capacity) {
            train.push(remainingPassengers)
            remainingPassengers = 0;
        } else {
            train.push(capacity);
            remainingPassengers -= capacity;
        }
    }

    console.log(train);
    if (remainingPassengers > 0) {
        console.log(`Could not fit ${remainingPassengers} passengers`)
    } else {
        console.log('All passengers aboard');
    }
}

trainStation(10, [9, 39, 1, 0, 0]);

trainStation(6, [5, 15, 2]);