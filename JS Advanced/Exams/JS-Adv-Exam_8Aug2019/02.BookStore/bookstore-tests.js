const BookStore = require('./bookstore.js');
const assert = require('chai').assert;

describe('BookStore Tests', function () {

    let bookStore;

    beforeEach(function () {
        bookStore = new BookStore("Test");
    });

    describe('Test Constructor', () => {
        it('Test Properties', () => {
            assert.equal(bookStore.name, "Test");
            assert.deepEqual(bookStore.books, []);
            assert.deepEqual(bookStore.workers, []);
        });
    });

    describe('Test stockBooks', () => {
        it('Test add book', () => {
            const actual = bookStore.stockBooks(['Inferno-Dan Braun']);

            const expected = [{ title: 'Inferno', author: 'Dan Braun' }];

            assert.deepEqual(actual, expected);
            assert.equal(bookStore.books.length, 1);
            assert.deepEqual(bookStore.books[0], { title: 'Inferno', author: 'Dan Braun' });
        });
    });

    describe('Test hire', () => {
        it('Should throw error if already hired', () => {
            bookStore.hire('George', 'seller');

            assert.throw(() => bookStore.hire('George', 'seller'),
                'This person is our employee');
        });
        it('Test valid hire', () => {
            const actual = bookStore.hire('George', 'seller');

            const expected = 'George started work at Test as seller'

            assert.equal(actual, expected);
            assert.equal(bookStore.workers.length, 1);
            assert.deepEqual(bookStore.workers[0], {
                name: 'George',
                position: 'seller',
                booksSold: 0
            });
        });
    });

    describe('Test fire', () => {
        it('Should throw error if doesnt exist', () => {
            assert.throw(() => bookStore.fire('George', 'seller'),
                'George doesn\'t work here');
        });
        it('Test valid fire', () => {
            bookStore.hire('George', 'seller');

            const actual = bookStore.fire('George');

            const expected = 'George is fired'

            assert.equal(actual, expected);
            assert.equal(bookStore.workers.length, 0);
        });
    });

    describe('Test sell book', () => {
        it('Should throw error if book doesnt exist', () => {
            bookStore.hire('George', 'seller');

            assert.throw(() => bookStore.sellBook('Inferno', 'George'),
                'This book is out of stock');
        });

        it('Should throw error if worker doesnt exist', () => {
            bookStore.stockBooks(['Inferno-Dan Braun']);

            assert.throw(() => bookStore.sellBook('Inferno', 'George'),
                'George is not working here');
        });

        it('Test valid sell book', () => {
            bookStore.hire('George', 'seller');
            bookStore.stockBooks(['Inferno-Dan Braun']);
            bookStore.sellBook('Inferno', 'George');

            assert.equal(bookStore.books.length, 0);
            assert.deepEqual(bookStore.workers[0], {
                name: 'George',
                position: 'seller',
                booksSold: 1
            });
        });
    });

    describe('Test printWorkers', () => {

        it('Test valid fire', () => {
            bookStore.hire('George', 'seller');

            const actual = bookStore.printWorkers();

            const expected = 'Name:George Position:seller BooksSold:0';
            assert.equal(actual, expected);
        });
    });
});