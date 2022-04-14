function matrixFun(inputArr) {

    let result = '';

    for (const line of inputArr) {
        let command = line[0];

        switch (command) {
            case 'filter':
                const filterCommand = line[1];
                const filterPosition = line[2];
                const filterWord = line[3];
                let filteredResult = [];

                switch (filterCommand) {
                    case 'UPPERCASE':
                        for (const char of filterWord) {
                            if (isUpperCase(char) && isNaN(char)) {
                                filteredResult.push(char);
                            }
                        }
                        break;
                    case 'LOWERCASE':
                        for (const char of filterWord) {
                            if (isLowerCase(char) && isNaN(char)) {
                                filteredResult.push(char);
                            }
                        }
                        break;
                    case 'NUMS':
                        for (const char of filterWord) {
                            if (!isNaN(char)) {
                                filteredResult.push(char);
                            }
                        }
                        break;
                }

                result += filteredResult.splice(filterPosition - 1, 1);
                break;
            case 'sort':
                const sortCommand = line[1];
                const sortPosition = line[2];
                const sortWord = line[3];
                let sortResult = [];

                switch (sortCommand) {
                    case 'A':
                        for (const char of sortWord) {
                            sortResult.push(char);
                        }
                        sortResult.sort();
                        result += sortResult.splice(sortPosition - 1, 1);
                        break;
                    case 'Z':
                        for (const char of sortWord) {
                            sortResult.push(char);
                        }
                        sortResult.sort((a, b) => {
                            return b.localeCompare(a)
                        });
                        result += sortResult.splice(sortPosition - 1, 1);
                        break;
                }

                break;
            case 'rotate':
                const rotateCommand = line[1];
                const rotatePosition = line[2];
                const rotateWord = line[3];
                let rotateResult = [];

                for (const char of rotateWord) {
                    rotateResult.push(char);
                }
                for (let i = 0; i < rotateCommand; i++) {
                    rotateResult.unshift(rotateResult.pop());
                }

                result += rotateResult.splice(rotatePosition - 1, 1);
                break;
            case 'get':
                const getPosition = line[1];
                const getWord = line[2];
                let getResult = [];

                for (const char of getWord) {
                    getResult.push(char);
                }
                result += getResult.splice(getPosition - 1, 1);
                break;
        }
    }

    console.log(result);

    function isUpperCase(char) {
        return char === char.toUpperCase();
    }

    function isLowerCase(char) {
        return char === char.toLowerCase();
    }
}

matrixFun([["filter", "UPPERCASE", 4, "AkIoRpSwOzFdT"],
["sort", "A", 3, "AOB"],
["sort", "A", 3, "FAILCL"],
["sort", "Z", 2, "OUTAGN"],
["filter", "UPPERCASE", 2, "01S345U7N"],
["rotate", 2, 2, "DAN"],
["get", 2, "PING"],
["get", 3, "?- 654"]]
);