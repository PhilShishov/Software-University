function attachEventsListeners() {
    const buttons = document.querySelectorAll('div input:last-child');

    for (const btn of buttons) {
        btn.addEventListener('click', convert);
    }

    function convert() {
        let currentTextInput = this.parentNode.children[1];
        let value = currentTextInput.value;
        let currentId = currentTextInput.id;

        let convertedTime = [];

        if (currentId === 'days') {
            convertedTime['days'] = value;
            convertedTime['hours'] = value * 24;
            convertedTime['minutes'] = value * 1440;
            convertedTime['seconds'] = value * 86400;

        } else if (currentId === 'hours') {
            convertedTime['days'] = value / 24;
            convertedTime['hours'] = value;
            convertedTime['minutes'] = value * 60;
            convertedTime['seconds'] = value * 3600;

        } else if (currentId === 'minutes') {
            convertedTime['days'] = value / 1440;
            convertedTime['hours'] = value / 60;
            convertedTime['minutes'] = value;
            convertedTime['seconds'] = value * 60;

        } else if (currentId === 'seconds') {
            convertedTime['days'] = value / 86400;
            convertedTime['hours'] = value / 3600;
            convertedTime['minutes'] = value / 60;
            convertedTime['seconds'] = value;
        }

        for (const currentButton of buttons) {
            let input = currentButton.parentNode.children[1];
            input.value = convertedTime[input.id];
        }
    }
}