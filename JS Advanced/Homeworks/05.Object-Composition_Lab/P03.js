function listProcessor(data) {
    const processor = (function () {
        let list = [];
        return {
            add: (elem) => {
                list.push(elem);
            },
            remove: (elem) => {
                list = list.filter(item => item !== elem);
            },
            print: () => {
                console.log(list.join(','));
            }
        };
    })();

    for (const input of data) {
        const tokens = input.split(' ');
        const command = tokens[0];
        const text = tokens[1];

        processor[command](text);
        console.log(typeof(processor[command]));
    }
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);
listProcessor(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);