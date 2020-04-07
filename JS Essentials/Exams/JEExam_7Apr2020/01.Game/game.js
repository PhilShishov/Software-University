function game(input) {

    let aSectorTeamPrice = 10;
    let bSectorTeamPrice = 7;
    let cSectorTeamPrice = 5;

    let aSectorVIPPrice = 25;
    let bSectorVIPPrice = 15;
    let cSectorVIPPrice = 10;

    let totalMoney = 0;
    let countOfFans = 0;

    let seats = input.shift();

    // let availableSeatsLitex = [['A', seats], ['B', seats], ['C', seats]];
    // let availableSeatsLevski = [['A', seats], ['B', seats], ['C', seats]];
    // let availableSeatsVIP = [['A', seats], ['B', seats], ['C', seats]];
    let takenSeats = [];

    for (const line of input) {

        let tokens = line.split('*');
        let team = tokens[0];
        let seatNumber = tokens[1];
        let sector = tokens[2];

        let taken = takenSeats.find(s => s === line);

        if (taken) {
            console.log(`Seat ${seatNumber} in zone ${team} sector ${sector} is unavailable`);
            continue;
        }

        takenSeats.push(line);

        if (team === 'VIP') {
            switch (sector) {
                case 'A':
                    totalMoney += aSectorVIPPrice;
                    break;
                case 'B':
                    totalMoney += bSectorVIPPrice;
                    break;
                case 'C':
                    totalMoney += cSectorVIPPrice;
                    break;
            }
            countOfFans++;
        } else if (team === 'LITEX') {
            switch (sector) {
                case 'A':
                    totalMoney += aSectorTeamPrice;
                    break;
                case 'B':
                    totalMoney += bSectorTeamPrice;
                    break;
                case 'C':
                    totalMoney += cSectorTeamPrice;
                    break;
            }
            countOfFans++;
        }
        else if (team === 'LEVSKI') {
            switch (sector) {
                case 'A':
                    totalMoney += aSectorTeamPrice;
                    break;
                case 'B':
                    totalMoney += bSectorTeamPrice;
                    break;
                case 'C':
                    totalMoney += cSectorTeamPrice;
                    break;
            }
            countOfFans++;
        }

    }

    console.log(`${totalMoney} lv.`);
    console.log(`${countOfFans} fans`);
}

game(["5",
    "LITEX*5*A", "LITEX*5*B", "LITEX*5*A", "VIP*1*A"]
);
game(["5", "LITEX*5*A", "LEVSKI*2*A", "LEVSKI*3*B", "VIP*4*C", "LITEX*3*B", "LEVSKI*2*A", "LITEX*5*B", "LITEX*5*A", "VIP*1*A"]);