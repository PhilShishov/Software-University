const PaymentPackage = require('./payment-package');

const assert = require('chai').assert;

describe('Payment Package', function () {
    let paymentPackage;
    let name = 'Consultation';
    let value = 100;

    beforeEach(function () {
        paymentPackage = new PaymentPackage(name, value);
    });

    describe('constructor', function () {
        it('default value of VAT property should be 20', function () {
            const expected = 20;
            const actual = paymentPackage.VAT;

            assert.equal(actual, expected);
        });

        it('default value of active property should be true', function () {
            assert.isTrue(paymentPackage.active);
        });

        it('should initialize with the correct name', function () {
            const expected = 'Consultation';
            const actual = paymentPackage.name;

            assert.equal(actual, expected);
        });

        it('should initialize with the correct value', function () {
            const expected = 100;
            const actual = paymentPackage.value;

            assert.equal(actual, expected);
        });
    });

    describe('name', function () {
        it('setter should throw error when the value is not a string', function () {
            assert.throw(() => {
                paymentPackage.name = 5;
            }, 'Name must be a non-empty string');
        });

        it('setter should throw error when the value is empty string', function () {
            assert.throw(() => {
                paymentPackage.name = '';
            }, 'Name must be a non-empty string');
        });

        it('setter should work correctly with valid data', function () {
            paymentPackage.name = 'HR Services';

            const expected = 'HR Services';
            const actual = paymentPackage.name;

            assert.equal(actual, expected);
        });
    });

    describe('value', function () {
        it('setter should throw error when the value is not a number', function () {
            assert.throw(() => {
                paymentPackage.value = [];
            }, 'Value must be a non-negative number');
        });

        it('setter should throw error when the value is negative', function () {
            assert.throw(() => {
                paymentPackage.value = -50;
            }, 'Value must be a non-negative number');
        });

        it('should work correctly when the value is equal to 0', function () {
            paymentPackage.value = 0;

            const expected = 0;
            const actual = paymentPackage.value;

            assert.equal(actual, expected);
        });

        it('setter should work correctly with valid data', function () {
            paymentPackage.value = 200;

            const expected = 200;
            const actual = paymentPackage.value;

            assert.equal(actual, expected);
        });
    });

    describe('VAT', function () {
        it('setter should throw error when the value is not a number', function () {
            assert.throw(() => {
                paymentPackage.VAT = 'not a number';
            }, 'VAT must be a non-negative number');
        });

        it('setter should throw error when the value is negative', function () {
            assert.throw(() => {
                paymentPackage.VAT = -50;
            }, 'VAT must be a non-negative number');
        });

        it('setter should work correctly with valid data', function () {
            paymentPackage.VAT = 15;

            const expected = 15;
            const actual = paymentPackage.VAT;

            assert.equal(actual, expected);
        });
    });

    describe('active', function () {
        it('setter should throw error when the value is not a boolean', function () {
            assert.throw(() => {
                paymentPackage.active = {};
            }, 'Active status must be a boolean');
        });

        it('setter should work correctly with valid data', function () {
            paymentPackage.active = false;

            const expected = false;
            const actual = paymentPackage.active;

            assert.equal(actual, expected);
        });

        it('should return correct value', function () {
            assert.equal(paymentPackage.active, true);
        });
    });

    describe('toString tests', function () {
        it('should return correct string when the status is active', function () {
            const expected = 'Package: Consultation\n' +
                '- Value (excl. VAT): 100\n' +
                '- Value (VAT 20%): 120';

            const actual = paymentPackage.toString();

            assert.equal(actual, expected);
        });

        it('should return correct string when the status is inactive', function () {
            paymentPackage.active = false;

            const expected = 'Package: Consultation (inactive)\n' +
                '- Value (excl. VAT): 100\n' +
                '- Value (VAT 20%): 120';

            const actual = paymentPackage.toString();

            assert.equal(actual, expected);
        });
    });
});