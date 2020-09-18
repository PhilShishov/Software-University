function sortedList() {
    const myObj = {
        list: [],
        size: 0,
        add: function (el) {
            this.list.push(el);
            this.size++;
            this.list = this.list.sort((a, b) => a - b);
        },
        remove: function (index) {
            if (index >= 0 && index < this.list.length) {
                this.list.splice(index, 1);
                this.size--;
            } else {
                throw new Error('Incorrect index');
            }
        },
        get: function (index) {
            if (index >= 0 && index < this.list.length) {
                return this.list[index];
            }
        }
    };

    // myObj.add(5);
    // myObj.add(1);
    // myObj.add(2);
    // myObj.remove(1);
    return myObj;
}

console.log(sortedList());