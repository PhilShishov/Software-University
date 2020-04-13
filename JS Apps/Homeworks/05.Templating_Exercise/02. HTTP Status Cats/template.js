(() => {
    renderCatTemplate();

    function renderCatTemplate() {
        let template = document.getElementById('cat-template').innerHTML;
        let compiled = Handlebars.compile(template);
        let rendered = compiled({
            cats: window.cats
        });

        document.getElementById('allCats').innerHTML = rendered;
    }

})()
