function trainStation(capacity, passengersArr) {

    let train = [];
    let remainingPassengers = 0;

    for (const passengers of passengersArr) {
        if (passengers + remainingPassengers <= capacity) {
            train.push(passengers + remainingPassengers);
            remainingPassengers = 0;
        } else {
            remainingPassengers += passengers - capacity;
            train.push(capacity);
        }
    }

    console.log(passengersArr);
    console.log(train);

    if (remainingPassengers > 0) {
        console.log(`Could not fit ${remainingPassengers} passengers`);
    }
    else {
        console.log('All passengers aboard');
    }
}

trainStation(10, [9, 39, 1, 0, 0]);
trainStation(6, [5, 15, 2]);