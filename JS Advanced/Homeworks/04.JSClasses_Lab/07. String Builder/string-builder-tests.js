const StringBuilder = require('./string-builder');

const assert = require('chai').assert;

describe('String Builder Tests', function () {
    let stringBuilder;

    beforeEach(function () {
        stringBuilder = new StringBuilder();
    });

    it('should have the correct function properties', function () {
        assert.isFunction(StringBuilder.prototype.append);
        assert.isFunction(StringBuilder.prototype.prepend);
        assert.isFunction(StringBuilder.prototype.insertAt);
        assert.isFunction(StringBuilder.prototype.remove);
        assert.isFunction(StringBuilder.prototype.toString);
    });

    describe('constructor', function () {
        it('should work correctly without passed parameter', function () {
            const expected = '';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });

        it('should work correctly with passed string parameter', function () {
            stringBuilder = new StringBuilder('abc');

            const expected = 'abc';
            const actual = stringBuilder._stringArray.join('');

            assert.equal(actual, expected);
        });

        it('should throw error when different type from string is passed', function () {
            assert.throw(() => {
                new StringBuilder([]);
            }, 'Argument must be string');
        });

        it('should work correctly with passed undefined parameter', function () {
            stringBuilder = new StringBuilder(undefined);

            const expected = 0;
            const actual = stringBuilder._stringArray.length;

            assert.equal(actual, expected);
        });
    });

    describe('append', function () {
        it('should throw error when different type from string is passed', function () {
            assert.throw(() => {
                stringBuilder.append({});
            }, 'Argument must be string');
        });

        it('should work correctly with passed string parameter', function () {
            stringBuilder.append('abc');

            const expected = 'abc';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });

        it('should work correctly when the function is called multiple times', function () {
            stringBuilder.append('abc');
            stringBuilder.append('def');
            stringBuilder.append('ghi');

            const expected = 'abcdefghi';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });
    });

    describe('prepend', function () {
        it('should throw error when different type from string is passed', function () {
            assert.throw(() => {
                stringBuilder.prepend(4);
            }
                , 'Argument must be string');
        });

        it('should work correctly with passed string parameter', function () {
            stringBuilder.prepend('abc');

            const expected = 'abc';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });

        it('should work correctly when the function is called multiple times', function () {
            stringBuilder.prepend('abc');
            stringBuilder.prepend('def');
            stringBuilder.prepend('ghi');

            const expected = 'ghidefabc';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });
    });

    describe('insertAt', function () {
        it('should throw error when different type from string is passed', function () {
            assert.throw(() => {
                stringBuilder.insertAt(true, 4);
            }
                , 'Argument must be string');
        });

        it('should work correctly with passed string parameter', function () {
            stringBuilder.append('abc');
            stringBuilder.insertAt(' appended text ', 1);

            const expected = 'a appended text bc';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });

        it('should work correctly when the function is called multiple times', function () {
            stringBuilder.append('abc');
            stringBuilder.insertAt(' appended text ', 1);
            stringBuilder.insertAt(' appended text ', 1);
            stringBuilder.insertAt(' appended text ', 1);

            const expected = 'a appended text  appended text  appended text bc';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });

        it('should work correctly with negative index', function () {
            stringBuilder.append('abcd');
            stringBuilder.insertAt(' appended text ', -1);

            const expected = 'abc appended text d';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });
    });

    describe('remove', function () {
        it('should work correctly with valid indexes', function () {
            stringBuilder.append('abc');
            stringBuilder.remove(1, 2);

            const expected = 'a';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });

        it('should work correctly when the function is called multiple times', function () {
            stringBuilder.append('abcdefghi');
            stringBuilder.remove(5, 2);
            stringBuilder.remove(3, 1);
            stringBuilder.remove(1, 2);

            const expected = 'aehi';
            const actual = stringBuilder.toString();

            assert.equal(actual, expected);
        });
    });

    it('should work correctly when multiple functions are called', function () {
        stringBuilder.append('ghi');
        stringBuilder.prepend('abc');
        stringBuilder.insertAt('def', 3);
        stringBuilder.remove(3, 3);

        const expected = 'abcghi';
        const actual = stringBuilder.toString();

        assert.equal(actual, expected);
    });

});