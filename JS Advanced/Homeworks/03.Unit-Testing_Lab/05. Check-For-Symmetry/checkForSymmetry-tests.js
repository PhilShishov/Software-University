
const isSymmetric = require('./checkForSymmetry');
const assert = require('chai').assert;

describe('Check for symmetry Tests', function () {
    it('should return true when input array is symmetrical', () => {
        const inputArr = ['a', 'b', 'c', 'b', 'a'];

        const expected = true;
        const actual = isSymmetric(inputArr);

        assert.equal(actual, expected, 'Returns false but input array is symmetrical');
    });

    it('should return true when input array has elements of differents types', () => {
        const inputArr = [1, 'text', { name: 'Peter' }, false, { name: 'Peter' }, 'text', 1];

        const expected = true;
        const actual = isSymmetric(inputArr);

        assert.equal(actual, expected, 'Returns false but input array is symmetrical');
    });

    it('should return true when empty array is passed', () => {
        const inputArr = [];

        const expected = true;
        const actual = isSymmetric(inputArr);

        assert.equal(actual, expected, 'Returns false but input array is empty');
    });

    it('should return false when array is not symmetrical', () => {
        const inputArr = [1, 2, 3, 4, 5];
        const expected = false;
        const actual = isSymmetric(inputArr);

        assert.equal(actual, expected, 'Returns true but input array is not symmetrical');
    });
    it('should return false if input is string', () => {
        const input = 'text';

        const expected = false;
        const actual = isSymmetric(input);

        assert.equal(actual, expected, 'Returns true but input is not array');
    });
    it('should return false if input is number', () => {
        const input = 5;

        const expected = false;
        const actual = isSymmetric(input);

        assert.equal(actual, expected, 'Returns true but input is not array');
    });
});