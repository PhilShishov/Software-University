function attachEventsListeners() {
    function convertDistance() {
        const inputDistance = +document.getElementById('inputDistance').value;
        const inputUnits = document.getElementById('inputUnits');
        const inputUnit = inputUnits.options[inputUnits.selectedIndex].value;

        const outputUnits = document.getElementById('outputUnits');
        const outputUnit = outputUnits.options[outputUnits.selectedIndex].value;

        let convertedDistance = converter[inputUnit][outputUnit](inputDistance);
        document.getElementById('outputDistance').value = convertedDistance;
    }

    const convertButton = document.getElementById('convert');
    convertButton.addEventListener('click', convertDistance);

    let converter = {
        km: {
            km: (value) => value,
            m: (value) => value * 1000,
            cm: (value) => value * 100000,
            mm: (value) => value * 1000000,
            mi: (value) => value * 0.62137119223733,
            yrd: (value) => value * 1093.6132983377,
            ft: (value) => value * 3280.8398950131,
            in: (value) => value * 39370.078740157,
        },

        m: {
            km: (value) => value * 0.001,
            m: (value) => value,
            cm: (value) => value * 100,
            mm: (value) => value * 1000,
            mi: (value) => value * 0.00062137119223733,
            yrd: (value) => value * 1.0936132983377,
            ft: (value) => value * 3.2808398950131,
            in: (value) => value * 39.370078740157,
        },

        cm: {
            km: (value) => value * 0.00001,
            m: (value) => value * 0.01,
            cm: (value) => value,
            mm: (value) => value * 10,
            mi: (value) => value * 0.0000062137119223733,
            yrd: (value) => value * 0.010936132983377,
            ft: (value) => value * 0.032808398950131,
            in: (value) => value * 	0.39370078740157,
        },

        mm: {
            km: (value) => value * 0.000001,
            m: (value) => value * 0.001,
            cm: (value) => value * 0.1,
            mm: (value) => value,
            mi: (value) => value * 0.00000062137119223733,
            yrd: (value) => value * 0.001093613298337,
            ft: (value) => value * 0.0032808398950131,
            in: (value) => value * 	0.039370078740157,
        },

        mi: {
            km: (value) => value * 1.609344,
            m: (value) => value * 1609.344,
            cm: (value) => value * 160934.4,
            mm: (value) => value * 1609344,
            mi: (value) => value,
            yrd: (value) => value * 1760,
            ft: (value) => value * 5280,
            in: (value) => value * 63360,
        },

        yrd: {
            km: (value) => value * 0.0009144,
            m: (value) => value * 0.9144,
            cm: (value) => value * 91.44,
            mm: (value) => value * 914.4,
            mi: (value) => value * 0.00056818181818182,
            yrd: (value) => value,
            ft: (value) => value * 3,
            in: (value) => value * 36,
        },

        ft: {
            km: (value) => value * 0.0003048,
            m: (value) => value * 0.3048,
            cm: (value) => value * 30.48,
            mm: (value) => value * 304.8,
            mi: (value) => value * 0.00018939393939394,
            yrd: (value) => value * 0.33333333333333,
            ft: (value) => value,
            in: (value) => value * 12,
        },

        in: {
            km: (value) => value * 0.0000254,
            m: (value) => value * 0.0254,
            cm: (value) => value * 2.54,
            mm: (value) => value * 25.4,
            mi: (value) => value * 0.000015782828282828,
            yrd: (value) => value * 0.027777777777778,
            ft: (value) => value * 0.083333333333333,
            in: (value) => value,
        }
    };
}