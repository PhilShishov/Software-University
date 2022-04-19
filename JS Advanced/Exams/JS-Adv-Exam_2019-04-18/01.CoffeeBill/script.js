function addProduct() {
    const productList = document.getElementById('product-list');
    let totalPriceField = document.getElementById('bill')
        .getElementsByTagName('tfoot')[0]
        .getElementsByTagName('td')[1];

    const addProductSection = document.getElementById('add-product');
    const productInput = addProductSection.getElementsByTagName('input')[0];
    const priceInput = addProductSection.getElementsByTagName('input')[1];

    const product = productInput.value;
    const price = +priceInput.value;

    if (product && price > 0) {
        const tr = document.createElement('tr');

        const productTd = document.createElement('td');
        productTd.textContent = product;

        const priceTd = document.createElement('td');
        priceTd.textContent = price;

        totalPrice = +totalPriceField.innerHTML;
        totalPrice += price;

        tr.appendChild(productTd);
        tr.appendChild(priceTd);
        productList.appendChild(tr);

        totalPriceField.innerHTML = totalPrice;
    }
    productInput.value = '';
    priceInput.value = '';
}