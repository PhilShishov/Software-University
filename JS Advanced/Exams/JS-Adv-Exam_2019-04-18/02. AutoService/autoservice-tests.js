const AutoService = require('./autoservice');
const assert = require('chai').assert;

describe('AutoService Tests', function () {
    let autoService;

    beforeEach(function () {
        autoService = new AutoService(2);
    });

    it('should instantiated with one parameter and two properties', () => {

        const actual = autoService;
        const expected = { garageCapacity: 2, workInProgress: [], backlogWork: [] };

        assert.deepEqual(actual, expected);
    });

    it('availableSpace should return a number', () => {

        const actual = autoService.availableSpace;
        const expected = 2;

        assert.equal(actual, expected);
    });

    it('signupForReview should receive three parameters', () => {

        autoService.signUpForReview('Peter', 'CA1234CA',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });

        const actual = autoService.workInProgress[0];
        const expected = { plateNumber: 'CA1234CA', clientName: "Peter", carInfo: { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' } };

        assert.deepEqual(actual, expected);
    });

    it('signupForReview should receive three parameters and push to workInProgress when availableSpace', () => {

        autoService.signUpForReview('Peter', 'CA1234CA',
            { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'exaustPipe': 'REMUS' });

        const actual = JSON.stringify(autoService.workInProgress[0]);
        const expected = '{"plateNumber":"CA1234CA","clientName":"Peter","carInfo":{"engine":"MFRGG23","transmission":"FF4418ZZ","exaustPipe":"REMUS"}}';

        assert.equal(actual, expected);
    });

    it('signupForReview should receive three parameters and push to backlogWork  when no availableSpace', () => {

        autoService.signUpForReview('Peter', 'CA1234CA',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });

        autoService.signUpForReview('Philip', 'PB4321PB',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });

        autoService.signUpForReview('Ivan', 'AC1234AC',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });
        
        const actual = autoService.backlogWork[0];
        const expected = { plateNumber: 'AC1234AC', clientName: "Ivan", carInfo: { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' } };

        assert.deepEqual(actual, expected);
    });

    it('carInfo should return existing client object from workInProgress', () => {

        autoService.signUpForReview('Peter', 'CA1234CA',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });
        
        const actual = autoService.carInfo('CA1234CA', 'Peter');
        const expected = { plateNumber: 'CA1234CA', clientName: "Peter", carInfo: { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' } };

        assert.deepEqual(actual, expected);
    });

    it('carInfo should return existing client object from backlogWork', () => {

        autoService.signUpForReview('Peter', 'CA1234CA',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });

        autoService.signUpForReview('Philip', 'PB4321PB',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });

        autoService.signUpForReview('Ivan', 'AC1234AC',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });
        
        const actual = autoService.carInfo('AC1234AC', 'Ivan');
        const expected = { plateNumber: 'AC1234AC', clientName: "Ivan", carInfo: { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' } };

        assert.deepEqual(actual, expected);
    });

    it('carInfo should return no client when passed unvalid data', () => {

        autoService.signUpForReview('Peter', 'CA1234CA',
            { engine: 'MFRGG23', transmission: 'FF4418ZZ', exaustPipe: 'REMUS' });        
        
        const actual = autoService.carInfo('AC1234AC', 'Ivan');
        const expected = 'There is no car with platenumber AC1234AC and owner Ivan.';

        assert.equal(actual, expected);
    });

    it('repairCar should return message for no clients when workingPlace is empty', () => {
        
        const actual = autoService.repairCar();
        const expected = 'No clients, we are just chilling...';

        assert.equal(actual, expected);
    });

    it('repairCar should return message for repair when broken part exists', () => {

        autoService.signUpForReview('Peter', 'CA1234CA', {'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken'});
        
        const actual = autoService.repairCar();
        const expected = `Your doors were repaired.`;

        assert.equal(actual, expected);
    });

    it('repairCar should return message for no repair when nothing is broken', () => {

        autoService.signUpForReview('Philip', 'PB4321PB', {'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'exaustPipe': 'REMUS'});
        
        const actual = autoService.repairCar();
        const expected = `Your car was fine, nothing was repaired.`;

        assert.equal(actual, expected);
    });    
});