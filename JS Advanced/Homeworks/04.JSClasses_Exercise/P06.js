class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(element) {
        this.list.push(element);
        this.list.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if (this._checkIndex(index)) {
            this.list.splice(index, 1);
            this.size--;
        }
    }

    get(index) {
        if (this._checkIndex(index)) {
            return this.list[index];
        }
    }

    _checkIndex(index) {
        if (index < 0 || index >= this.list.length) {
            return false;
        }

        return true;
    }
}

const list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));