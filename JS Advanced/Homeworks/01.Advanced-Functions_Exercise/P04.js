function personalBMI(name, age, weight, height) {

    let obj = {
        name: name,
        personalInfo: {
            age,
            weight,
            height
        },
        BMI: Math.round(weight / Math.pow(height / 100, 2)),
        status: ''
    };

    if (obj.BMI < 18.5) {
        obj.status = 'underweight';
    } else if (obj.BMI < 25) {
        obj.status = 'normal';

    } else if (obj.BMI < 30) {
        obj.status = 'overweight';

    } else {
        obj.status = 'obese';
        obj.recommendation = 'admission required';
    }

    return obj;
}

console.log(personalBMI('Peter', 29, 75, 182));
console.log(personalBMI('Honey Boo Boo', 9, 57, 137));