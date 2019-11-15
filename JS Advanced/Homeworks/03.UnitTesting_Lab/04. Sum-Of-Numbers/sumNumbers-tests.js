const sum = require('./sumNumbers.js');
const assert = require('chai').assert;

describe('Sum Tests', function () {
    it('should return the correct sum', function () {
        const inputArray = [1, 2, 3, 4, 5];
        const expected = 15;
        const actual = sum(inputArray);

        assert.equal(actual, expected, 'Sum function does not sum correctly');
    });

    it('should return 0 if empty array is given', function () {
        const inputArray = [];

        const expected = 0;
        const actual = sum(inputArray);

        assert.equal(actual, expected, 'Sum function does not return 0 when empty array is given.')
    });

    it('should return NaN when some of the elements are not numbers', function () {
        const inputArray = [-1, 'a', -3];

        const expected = NaN;
        const actual = sum(inputArray);

        assert.isNaN(actual, 'Sum function does not return NaN when some of the elements are not numbers.')
    });
});