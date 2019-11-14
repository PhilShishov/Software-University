// function argumentInfo() {
//     let args = arguments;
//     let objects = {};

//     for (let item of args) {
//         let type = typeof (item);
//         if (!objects.hasOwnProperty(type)) objects[type] = 0;
//         objects[type]++;

//         console.log(`${type}: ${item}`);
//     }

//     let objArr = Object.keys(objects).sort((a, b) => {
//         return objects[b] - objects[a];
//     });

//     for (const item of objArr) {
//         console.log(`${item} = ${objects[item]}`);
//     }
// }

function argumentInfo() {
    let args = arguments;
    let objects = {};

    for (let item of args) {
        let type = typeof (item);

        if (type === 'object') {
            console.log(`${type}: `);
        } else {
            console.log(`${type}: ${item}`);
        }

        if (objects[type]) {
            objects[type]++;
        } else {
            objects[type] = 1;
        }
    }

    objects = Object.entries(objects)
        .sort((a, b) => {
            return b[1] - a[1]
        }).forEach(el => {
            console.log(`${el[0]} = ${el[1]}`)
        });
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); });