$(() => {
    let monkeyTemplate = document.getElementById('monkey-template').innerHTML;
    let compiled = Handlebars.compile(monkeyTemplate);
    let rendered = compiled({ monkeys: monkeys });

    document.getElementsByClassName('monkeys')[0].innerHTML = rendered;

    let monkeysDiv = document.getElementsByClassName('monkeys')[0];
    monkeysDiv.addEventListener('click', showInfo);

    function showInfo(event) {
        if (event.target.tagName === 'BUTTON') {
            if (event.target.nextElementSibling.style.display === 'none') {
                event.target.nextElementSibling.style.display = 'block';
            } else {
                event.target.nextElementSibling.style.display = 'none';
            }
        }
    }

});