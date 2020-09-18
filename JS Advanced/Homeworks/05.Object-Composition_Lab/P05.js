
const SELECTORS = {
    NUM1: '#num1',
    NUM2: '#num2',
    RESULT: '#result',
    SUM_BUTTON: '#sumButton',
    SUBTRACT_BUTTON: '#subtractButton',
}

class Calculator {
    constructor() {
        // debugger;
        this.handleAddClick = this.handleAddClick.bind(this);
        this.handleSubtractClick = this.handleSubtractClick.bind(this);

        this.num1 = document.querySelector(SELECTORS.NUM1);
        this.num2 = document.querySelector(SELECTORS.NUM2);
        this.result = document.querySelector(SELECTORS.RESULT);
        this.btnAdd = document.querySelector(SELECTORS.SUM_BUTTON);
        this.btnSubstract = document.querySelector(SELECTORS.SUBTRACT_BUTTON);

        this._initEvents();
    }

    handleAddClick() {
        const x = this.num1.value;
        const y = this.num2.value;
        this.result.value = +x + +y;
    }

    handleSubtractClick() {
        const x = this.num1.value;
        const y = this.num2.value;
        this.result.value = x - y;
    }

    _initEvents() {
        this.btnAdd.addEventListener('click', this.handleAddClick);
        this.btnSubstract.addEventListener('click', this.handleSubtractClick);
    }
}

new Calculator();


// function sum() {
//     let firstElement;
//     let secondElement;
//     let resultElement;

//     return {
//         init: (selectorOne, selectorTwo, resultSelector) => {
//             firstElement = $(selectorOne);
//             secondElement = $(selectorTwo);
//             resultElement = $(resultSelector);
//         },

//         add: () => resultElement.val(+firstElement.val() + +secondElement.val()),
//         subtract: () => resultElement.val(+firstElement.val() - +secondElement.val())
//     }
// }