const mathEnforcer = require('./mathEnforcer');

const assert = require('chai').assert;

describe('Math Enforcer Tests', function () {
    describe('Add Five Tests', function () {

        it('should return undefined if param is a non-number', function () {
            assert.isUndefined(mathEnforcer.addFive('string'));
            assert.isUndefined(mathEnforcer.addFive(true));
            assert.isUndefined(mathEnforcer.addFive([]));
        });

        it('should add 5 to positive numbers', function () {
            const number = 10;

            const expected = number + 5;
            const actual = mathEnforcer.addFive(number);

            assert.equal(actual, expected);
        });

        it('should add 5 to negative numbers', function () {
            const number = -10;

            const expected = number + 5;
            const actual = mathEnforcer.addFive(number);

            assert.equal(actual, expected);
        });

        it('should add 5 to decimal numbers', function () {
            const number = 10.5;

            const expected = number + 5;
            const actual = mathEnforcer.addFive(number);

            assert.closeTo(actual, expected, 0.01);
        });
    });

    describe('Subtract Ten Tests', function () {

        it('should return undefined if param is a non-number', function () {
            assert.isUndefined(mathEnforcer.subtractTen('string'));
            assert.isUndefined(mathEnforcer.subtractTen(true));
            assert.isUndefined(mathEnforcer.subtractTen([]));
        });

        it('should subtract 10 from positive numbers', function () {
            const number = 10;

            const expected = number - 10;
            const actual = mathEnforcer.subtractTen(number);

            assert.equal(actual, expected);
        });

        it('should subtract 10 from negative numbers', function () {
            const number = -10;

            const expected = number - 10;
            const actual = mathEnforcer.subtractTen(number);

            assert.equal(actual, expected);
        });

        it('should subtract 10 from decimal numbers', function () {
            const number = 10.5;

            const expected = number - 10;
            const actual = mathEnforcer.subtractTen(number);

            assert.closeTo(actual, expected, 0.01);
        });
    });

    describe('Sum Tests', function () {

        it('should return undefined if parameters are non-numbers', function () {
            assert.isUndefined(mathEnforcer.sum(1, 'string'));
            assert.isUndefined(mathEnforcer.sum('string', 1));
            assert.isUndefined(mathEnforcer.sum('string', 'string'));
            assert.isUndefined(mathEnforcer.sum([], []));
        });

        it('should sum positive numbers', function () {
            const numberOne = 5;
            const numberTwo = 10;

            const expected = numberOne + numberTwo;
            const actual = mathEnforcer.sum(numberOne, numberTwo);

            assert.equal(actual, expected);
        });

        it('should sum negative numbers', function () {
            const numberOne = -5;
            const numberTwo = -10;

            const expected = numberOne + numberTwo;
            const actual = mathEnforcer.sum(numberOne, numberTwo);

            assert.equal(actual, expected);
        });

        it('should sum decimal numbers', function () {
            const numberOne = 5.3;
            const numberTwo = 10.2;

            const expected = numberOne + numberTwo;
            const actual = mathEnforcer.sum(numberOne, numberTwo);

            assert.closeTo(actual, expected, 0.01);
        });
    });
});