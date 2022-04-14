function coursesPrices(jsFund, jsAdv, jsApp, form) {

    let jsFundPrice = 170;
    let jsAdvPrice = 180;
    let jsAppPrice = 190;

    let total = 0;

    if (form === 'online') {
        jsFundPrice -= jsFundPrice * 0.06;
        jsAdvPrice -= jsAdvPrice * 0.06;
        jsAppPrice -= jsAppPrice * 0.06;
    }

    if (jsFund) {
        total += jsFundPrice;
    }
    if (jsAdv) {
        if (jsFund && jsAdv) {
            jsAdvPrice -= jsAdvPrice * 0.10;
        }
        total += jsAdvPrice;
    }
    if (jsApp) {
        total += jsAppPrice;
    }

    if (jsFund && jsAdv && jsApp) {
        total = (jsFundPrice + jsAdvPrice + jsAppPrice);
        total -= total * 0.06;
    }

    console.log(Math.floor(total));
}

coursesPrices(true, false, false, "onsite");
coursesPrices(true, false, false, "online");
coursesPrices(true, true, false, "onsite");
coursesPrices(false, false, false, "onsite");
coursesPrices(true, false, true, "onsite");
coursesPrices(true, false, true, "online");
coursesPrices(true, true, true, "onsite");
coursesPrices(true, true, true, "online");