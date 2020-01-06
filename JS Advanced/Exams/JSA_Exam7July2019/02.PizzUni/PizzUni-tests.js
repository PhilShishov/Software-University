const PizzUni = require('./PizzUni');
const assert = require('chai').assert;

describe('PizzUni Tests', function () {
    let pizzUni;

    beforeEach(function () {
        pizzUni = new PizzUni();
    });

    it('should return PizzUni object with registeredUsers, availableProducts and orders properties', function () {
       assert.property(pizzUni, 'registeredUsers');
       assert.property(pizzUni, 'availableProducts');
       assert.property(pizzUni, 'orders');
    });

    it('registerUser should throw error if user exists', function () {
        pizzUni.registeredUsers.push({email: 'gmail.com', orderHistory: []});

        assert.throw(() => pizzUni.registerUser('gmail.com'),
            'This email address (gmail.com) is already being used!');
    });    

    it('registerUser should return correct user', function () {
        pizzUni.registerUser({email: 'gmail.com', orderHistory: []});

        const expected = '[{"email":{"email":"gmail.com","orderHistory":[]},"orderHistory":[]}]';
        const actual = JSON.stringify(pizzUni.registeredUsers);

        assert.equal(actual, expected);
    });     
    
    it('makeAnOrder should throw error if user does not exists', function () {
        assert.throw(() => pizzUni.makeAnOrder('gmail.com', 'margarita', 'water'), 
        'You must be registered to make orders!');
    });    

    it('makeAnOrder should throw error when no pizza is ordered', function () {

        pizzUni.registerUser('gmail.com');

        assert.throw(() => pizzUni.makeAnOrder('gmail.com', null, 'water'), 
        'You must order at least 1 Pizza to finish the order.');
    });    

    it('makeAnOrder should add to user orders', function () {
        pizzUni.registerUser('gmail.com');
        pizzUni.makeAnOrder('gmail.com', 'Italian Style');

        assert.throw(() => pizzUni.makeAnOrder('gmail.com', null, 'water'), 
        'You must order at least 1 Pizza to finish the order.');
    });    

    it('makeAnOrder should add pizza and cola to user orders', function () {
        pizzUni.registerUser('abv.bg');
        pizzUni.makeAnOrder('abv.bg', 'Italian Style', 'Water');

        const user = pizzUni.registeredUsers.find(u => u.email === 'abv.bg');

        const expected = [ { orderedPizza: 'Italian Style' , orderedDrink: 'Water'} ];
        const actual = user.orderHistory;

        assert.deepEqual(actual, expected);
    });

    it('makeAnOrder should add return the index of currentOrder', function () {
        pizzUni.registerUser('abv.bg');

        const expected = 0;
        const actual = pizzUni.makeAnOrder('abv.bg', 'Italian Style');

        assert.equal(actual, expected);
    });

    it('detailsAboutMyOrder return undefined if the order doesn\'t exist', function () {
        assert.isUndefined(pizzUni.detailsAboutMyOrder(-3));
    });

    it('detailsAboutMyOrder return the order status if the order exists', function () {
        pizzUni.registerUser('abv.bg');
        pizzUni.makeAnOrder('abv.bg', 'Italian Style');

        const expected = 'Status of your order: pending';
        const actual = pizzUni.detailsAboutMyOrder(0);

        assert.equal(actual, expected);
    });

    // it('doesTheUserExist return undefined if the user doesn\'t exist', function () {
    //     assert.isUndefined(pizzUni.doesTheUserExist('abv.bg'));
    // });

    // it('doesTheUserExist return the searched user if he exists', function () {
    //     pizzUni.registerUser('abv.bg');

    //     const expected = '{"email":"abv.bg","orderHistory":[]}';
    //     const actual = JSON.stringify(pizzUni.doesTheUserExist('abv.bg'));

    //     assert.equal(actual, expected);
    // });

    // it('completeOrder return undefined if there are no orders', function () {
    //     assert.isUndefined(pizzUni.completeOrder());
    // });

    // it('completeOrder change the order\'s status', function () {
    //     pizzUni.registerUser('abv.bg');
    //     pizzUni.makeAnOrder('abv.bg', 'Italian Style');
    //     pizzUni.completeOrder();

    //     const expected = '[{"orderedPizza":"Italian Style","email":"abv.bg","status":"completed"}]';
    //     const actual = JSON.stringify(pizzUni.orders);

    //     assert.equal(actual, expected);
    // });

    it('completeOrder return the completed order\'s index', function () {
        pizzUni.registerUser('abv.bg');
        pizzUni.makeAnOrder('abv.bg', 'Italian Style');

        const expected = '{"orderedPizza":"Italian Style","email":"abv.bg","status":"completed"}';
        const actual = JSON.stringify(pizzUni.completeOrder());

        assert.equal(actual, expected);
    });
    
});