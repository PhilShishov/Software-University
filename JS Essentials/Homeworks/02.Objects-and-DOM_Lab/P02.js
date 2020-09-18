function sumByTown(input) {

    let towns = {};

    for (let i = 0; i < input.length; i += 2) {

        let town = input[i];

        if (!towns[town]) {
            towns[town] = 0;
        }

        towns[town] += Number(input[i + 1]);
    }

    console.log(JSON.stringify(towns));
}

sumByTown(["Sofia",
    "20",
    "Varna",
    "3",
    "Sofia",
    "5",
    "Varna",
    "4",]
);