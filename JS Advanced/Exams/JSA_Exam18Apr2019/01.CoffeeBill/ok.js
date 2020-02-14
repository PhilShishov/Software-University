function addProduct() {
    let productList = document.getElementById('product-list');
    let product = document.getElementsByTagName('input')[0].value;
    let price = document.getElementsByTagName('input')[1].value;

    if (product && +price > 0) {
        let totalSum = document.querySelector('tfoot')
            .getElementsByTagName('tr')[0]
            .getElementsByTagName('td')[1];

        let tr = document.createElement('tr');
        let tdProduct = document.createElement('td');
        let tdPrice = document.createElement('td');

        tdProduct.textContent = product;
        tdPrice.textContent = price;

        tr.appendChild(tdProduct);
        tr.appendChild(tdPrice);
        productList.appendChild(tr);

        let convertSum = +totalSum.textContent;
        convertSum += +price;
        totalSum.textContent = convertSum;
    }

    document.getElementsByTagName('input')[0].value = '';
    document.getElementsByTagName('input')[1].value = '';
}
