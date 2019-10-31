
// function populationsInTowns(input) {

//     let map = new Map();

//     for(let line of input) {
//         let tokens = line.split(" <-> ");
//         let town = tokens[0];
//         let population = Number(tokens[1]);

//         if(!map.has(town)) {
//             map.set(town, 0);
//         }

//         map.set(town, map.get(town) + population);
//     }

//     for(let city of map){
//         console.log(`${city[0]} : ${city[1]}`)
//     }    
// }

// function solve(input) {
//     let object = {};
//     for (let i = 0; i <input.length ; i++) {
//         let populationsAndTown = input[i].split(" <-> ");

//         if (!object[populationsAndTown[0]]) {
//             object[populationsAndTown[0]]=0;
//         }
//         object[populationsAndTown[0]]+=Number(populationsAndTown[1]);

//     }

//     for (const propName in object) {
//         console.log(`${propName} : ${object[propName]}`);
//     }
// }

function populationInTowns(input) {

    let towns = {};

    for (let line of input) {

        let townInfo = line.split(' <-> ');
        [town, population] = townInfo;

        if (!towns.hasOwnProperty(town)) {
            towns[town] = +population;
        } else {
            towns[town] += +population;
        }
    }

    for (var town in towns) {
        console.log(`${town} : ${towns[town]}`);
    }
}

populationInTowns([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);

populationInTowns([
    'Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']);