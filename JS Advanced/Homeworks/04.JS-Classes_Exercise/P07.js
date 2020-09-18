class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;

        this.products = [];
    }

    get clientId() {
        return this._cliendId;
    }

    set clientId(clientId) {
        if (clientId.length !== 6 || isNaN(clientId)) {
            throw new TypeError('Client ID must be a 6-digit number');
        }

        this._clientId = clientId;
    }

    get email() {
        return this._email;
    }

    set email(email) {

        const regexEmail = /^([a-z]+@[a-z\.]+)$/i;
        if (!regexEmail.test(email)) {
            throw new TypeError('Invalid e-mail');
        }

        this._email = email;
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(firstName) {
        const regexName = /^[A-Za-z]+$/i;

        if (firstName.length < 3 || firstName.length > 20) {
            throw new TypeError('First name must be between 3 and 20 characters long');
        }

        if (!regexName.test(firstName)) {
            throw new TypeError('First name must contain only Latin characters');
        }
        this._firstName = firstName;
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(lastName) {
        const regexName = /^[A-Za-z]+$/i;

        if (lastName.length < 3 || lastName.length > 20) {
            throw new TypeError('Last name must be between 3 and 20 characters long');
        }

        if (!regexName.test(lastName)) {
            throw new TypeError('Last name must contain only Latin characters');
        }

        this._lastName = lastName;
    }
}

try {
    // let acc = new CheckingAccount('1314', 'ivan@some.com', 'Ivan', 'Petrov');
    // let acc = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov');
    // let acc = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov');    
    let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov');

} catch (error) {
    console.error(error);
}