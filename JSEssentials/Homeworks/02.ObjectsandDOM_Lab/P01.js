function townsToJSON(input){

    let towns = [];
    let regex = /\s*\|\s*/;

    let headers = input[0].split(/\W+/);
    headers = headers.filter(h => h != '');  

    for(let line of input.splice(1)) {
        let tokens = line.split(regex);
        let townObj = { [`${headers[0]}`]: tokens[1], [`${headers[1]}`]: Number(tokens[2]), [`${headers[2]}`]: Number(tokens[3])};
        towns.push(townObj);
    }

    console.log(JSON.stringify(towns));
}

townsToJSON(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);

townsToJSON(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);