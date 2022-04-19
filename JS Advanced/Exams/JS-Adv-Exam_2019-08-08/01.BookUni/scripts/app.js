function BookUni() {

    [oldBooks, newBooks] = [document.getElementsByClassName('bookShelf')[0],
    document.getElementsByClassName('bookShelf')[1]];

    const addBtn = document.getElementsByTagName('button')[0];

    const totalPriceHeader = document.getElementsByTagName('h1')[1];
    let totalPrice = 0;

    addBtn.addEventListener('click', function (e) {
        e.preventDefault();
        const inputFields = document.getElementsByTagName('input');

        [title, year, price] = [inputFields[0].value,
        Number(inputFields[1].value),
        Number(inputFields[2].value)];

        if (title && year > 0 && price > 0) {
            if (year > 2000) {
                const div = createBook(title, year, false, price);
                newBooks.appendChild(div);
            } else {
                const div = createBook(title, year, true, price);
                oldBooks.appendChild(div);
            }
        }
    });

    function createBook(title, year, isOld, price) {
        price = isOld ? price * 0.85 : price;
        
        const div = document.createElement('div');
        div.classList.add('book');

        const p = document.createElement('p');
        p.innerHTML = `${title} [${year}]`;

        const btnBuy = document.createElement('button');
        btnBuy.innerHTML = `Buy it only for ${price.toFixed(2)} BGN`;

        btnBuy.addEventListener('click', function (e) {
            e.preventDefault();

            totalPrice += price;
            totalPriceHeader.innerHTML = `Total Store Profit: ${totalPrice.toFixed(2)} BGN`;

            this.parentNode.parentNode.removeChild(this.parentNode);
        });

        div.appendChild(p);
        div.appendChild(btnBuy);

        if (!isOld) {
            const btnMoveToOld = document.createElement('button');
            btnMoveToOld.innerHTML = 'Move to old section';

            btnMoveToOld.addEventListener('click', function (e) {
                e.preventDefault();
                oldBooks.appendChild(createBook(title, year, true, price));
                this.parentNode.parentNode.removeChild(this.parentNode);
            });

            div.appendChild(btnMoveToOld);
        }
        return div;
    }
}