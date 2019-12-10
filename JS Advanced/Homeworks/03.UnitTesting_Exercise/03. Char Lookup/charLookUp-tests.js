const lookupChar = require('./charLookUp');

const assert = require('chai').assert;

describe('Char Lookup Tests', function () {
    it('should return undefined if firstParam is not a string', function () {
        assert.isUndefined(lookupChar(3, 3));
    });    

    it('should return undefined if secondParam is not a number', function () {
        assert.isUndefined(lookupChar('string', 'string'));
    });    

    it('should return undefined if secondParam is a floating point number', function () {
        assert.isUndefined(lookupChar('string', 1.50));
    });   

    it('should return Incorrect index if index is out of range', function () {

        const actual = lookupChar('abc', 3);
        const expected = 'Incorrect index';

        assert.equal(actual, expected);
    });

    it('should return Incorrect index if index is negative', function () {

        const actual = lookupChar('abc', -3);
        const expected = 'Incorrect index';

        assert.equal(actual, expected);
    });

    it('should return character at index', function () {

        const actual = lookupChar('abc', 2);
        const expected = 'c';

        assert.equal(actual, expected);
    });
});