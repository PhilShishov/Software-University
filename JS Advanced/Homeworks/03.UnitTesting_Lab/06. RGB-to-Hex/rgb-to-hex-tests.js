const rgbToHexColor = require('./rgb-to-hex');
const assert = require('chai').assert;

describe('RGB to HEX Tests', function () {
    it('should return color string when parameters are valid', function () {
        let expected = '#FF9EAA';
        let actual = rgbToHexColor(255, 158, 170);
        assert.equal(actual, expected);

        expected = '#000000';
        actual = rgbToHexColor(0, 0, 0);
        assert.equal(actual, expected);

        expected = '#FFFFFF';
        actual = rgbToHexColor(255, 255, 255);
        assert.equal(actual, expected);
    });

    it('should return undefined with invalid red', function () {
        const expected = undefined;

        let actual = rgbToHexColor('abc', 0, 0);
        assert.equal(actual, expected);

        actual = rgbToHexColor(-5, 0, 0);
        assert.equal(actual, expected);

        actual = rgbToHexColor(256, 0, 0);
        assert.equal(actual, expected);
    });

    it('should return undefined with invalid green', function () {
        const expected = undefined;

        let actual = rgbToHexColor(0, 'abc', 0);
        assert.equal(actual, expected);

        actual = rgbToHexColor(0, -5, 0);
        assert.equal(actual, expected);

        actual = rgbToHexColor(0, 256, 0);
        assert.equal(actual, expected);
    });

    it('should return undefined with invalid blue', function () {
        const expected = undefined;

        let actual = rgbToHexColor(0, 0, 'abc');
        assert.equal(actual, expected);

        actual = rgbToHexColor(0, 0, -5);
        assert.equal(actual, expected);

        actual = rgbToHexColor(0, 0, 256);
        assert.equal(actual, expected);
    });
});