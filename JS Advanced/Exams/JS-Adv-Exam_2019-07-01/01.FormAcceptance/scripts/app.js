function acceptance() {
    const warehouse = document.getElementById('warehouse');
    const companyInput = document.getElementsByName('shippingCompany')[0];
    const productInput = document.getElementsByName('productName')[0];
    const quantityInput = document.getElementsByName('productQuantity')[0];
    const scrapeInput = document.getElementsByName('productScrape')[0];
    const inputFields = document.getElementsByTagName('input');

    const btnAdd = document.getElementById('acceptance');
    btnAdd.addEventListener('click', addProduct);

    function addProduct() {
        const company = companyInput.value;
        const product = productInput.value;
        const quantity = +quantityInput.value;
        const scrape = +scrapeInput.value;

        if (company && product && quantity && scrape && quantity - scrape > 0) {

            const div = document.createElement('div');

            const p = document.createElement('p');
            p.textContent = `[${company}] ${product} - ${quantity - scrape} pieces`;

            const btn = document.createElement('button');
            btn.textContent = 'Out of stock';
            btn.addEventListener('click', removeProduct);

            div.appendChild(p);
            div.appendChild(btn);
            warehouse.appendChild(div);

            function removeProduct() {
                warehouse.removeChild(div);
            }
        }

        for (const input of inputFields) {
            input.value = '';
        }
    }
}