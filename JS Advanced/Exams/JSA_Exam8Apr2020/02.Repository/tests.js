const Repository = require("./solution.js");
const assert = require('chai').assert;

describe("Repository Tests", function () {
    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    };
    let repository;

    beforeEach(function () {
        repository = new Repository(properties);
    });
    describe("Test Constructor", function () {
        it("Test Properties", function () {
            assert.property(repository, 'data');
            assert.property(repository, 'props');
            assert.property(repository, 'nextId');
        });
    });
    describe("Test Count", function () {
        it("Test count size", function () {
            assert.equal(repository.count, 0);
        });
        it("Test count size after adding", function () {
            repository.add({
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            });
            assert.equal(repository.count, 1);
        });
    });
    describe("Test Add", function () {
        it("Adding an entity returns id", function () {
            repository.add({
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            });
            const actual = repository.add({
                name: 'Gosho',
                age: 22,
                birthday: new Date(1998, 0, 7)
            });
            const expected = 1;
            assert.equal(actual, expected);
        });

        it("Add throws error when validating property", function () {
            let entity = {
                name1: 'Stamat',
                age: 29,
                birthday: new Date(1991, 0, 21)
            };

            // const actual = repository.update(0, entity)._validate(entity);
            // console.log(actual);

            assert.throw(() => {
                repository.add(entity);
                'Property age is missing from the entity!';
            });
        });
        it("Add throws error when not correct type property", function () {
            let entity = {
                name: 'Stamat',
                age: 29,
                birthday: 1991
            };

            // const actual = repository.update(0, entity)._validate(entity);
            // console.log(actual);

            assert.throw(() => {
                repository.add(entity);
                'Property name is not of correct type!';
            });
        });

    });
    describe("Test getId", function () {
        it("Get id throws error when non existing", function () {
            repository.add({
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            });
            assert.throw(() => {
                repository.getId(1),
                    'Entity with id: 1 does not exist!';
            });
        });
        it("Get id returns entity when valid id", function () {
            repository.add({
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            });
            const actual = JSON.stringify(repository.getId(0));
            const expected = '{"name":"Pesho","age":22,"birthday":"1998-01-06T23:00:00.000Z"}';
            assert.equal(actual, expected);
        });
    });

    describe("Test Update", function () {
        it("Update throws error when non existing", function () {
            let entity = {
                name: 'Gosho',
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repository.add(entity);

            assert.throw(() => {
                repository.update(1, entity),
                    'Entity with id: 1 does not exist!';
            });
        });
        it("Update throws error when validating property", function () {
            let entity = {
                name: 'Gosho',
                // age: 22,
                birthday: new Date(1998, 0, 7)
            };

            // const actual = repository.update(0, entity)._validate(entity);
            // console.log(actual);

            assert.throw(() => {
                repository.update(0, entity);
                'Property age is missing from the entity!';
            });
        });
        it("Update throws error when not correct type property", function () {
            let entity = {
                name: {},
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            // const actual = repository.update(0, entity)._validate(entity);
            // console.log(actual);

            assert.throw(() => {
                repository.update(0, entity);
                'Property name is not of correct type!';
            });
        });
        it("Update when valid data", function () {

            let entity1 = {
                name: 'Gosho',
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            let entity2 = {
                name: 'Pesho',
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repository.add(entity1);
            repository.add(entity2);

            repository.update(1, entity1);

            const actual = JSON.stringify(repository.getId(1));
            const expected = '{"name":"Gosho","age":22,"birthday":"1998-01-06T23:00:00.000Z"}';
            assert.equal(actual, expected);
        });
    });
    describe("Test Delete", function () {
        it("Delete throws error when non existing", function () {
            repository.add({
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            });

            assert.throw(() => {
                repository.del(1),
                    'Entity with id: 1 does not exist!';
            });
        });
        it("Delete when valid id", function () {
            repository.add({
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            });

            assert.equal(repository.count, 1);

            repository.del(0);
            assert.equal(repository.count, 0);
        });
    });
});
