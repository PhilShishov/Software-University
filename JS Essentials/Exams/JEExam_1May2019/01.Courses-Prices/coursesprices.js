function coursesPrices(jsFund, jsAdv, jsApp, eduForm) {

    let jsFundPrice = 170;
    let jsAdvPrice = 180;
    let jsAppPrice = 190;

    let totalPrice = 0;

    if (eduForm === 'online') {
        jsFundPrice -= jsFundPrice * 0.06;
        jsAdvPrice -= jsAdvPrice * 0.06;
        jsAppPrice -= jsAppPrice * 0.06;
    }

    if (jsFund) {
        totalPrice += jsFundPrice;
    }

    if (jsAdv) {
        if (jsFund && jsAdv) {
            jsAdvPrice -= jsAdvPrice * 0.10;
        }
        totalPrice += jsAdvPrice;

    }

    if (jsApp) {
        totalPrice += jsAppPrice;
    }

    if (jsFund && jsAdv && jsApp) {
        totalPrice -= totalPrice * 0.06;
    }
    
    console.log(Math.round(totalPrice));
}

coursesPrices(true, false, false, "onsite");
coursesPrices(true, false, false, "online");
coursesPrices(true, true, false, "onsite");