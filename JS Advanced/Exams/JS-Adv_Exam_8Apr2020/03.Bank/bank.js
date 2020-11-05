class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
        this.count = 0;
    }

    newCustomer(customer) {
        let customerExist = this.allCustomers.find(s => s.personalId == customer.personalId);

        if (customerExist) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        customerExist = {
            firstName: customer.firstName,
            lastName: customer.lastName,
            personalId: customer.personalId,
            totalMoney: 0,
            transactions: []
        };

        this.allCustomers.push(customerExist);
        return customer;
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find(s => s.personalId == personalId);

        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }

        this.count++;
        customer.transactions.push({ id: this.count, firstName: customer.firstName, lastName: customer.lastName, operation: 'deposit', amount: amount });
        customer.totalMoney += +amount;
        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find(s => s.personalId == personalId);

        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }

        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        this.count++;
        customer.transactions.push({ id: this.count, firstName: customer.firstName, lastName: customer.lastName, operation: 'withdraw', amount: amount });
        customer.totalMoney -= +amount;
        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let customer = this.allCustomers.find(s => s.personalId == personalId);

        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }

        let result = '';

        result += `Bank name: ${this._bankName}\n`;
        result += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
        result += `Customer ID: ${customer.personalId}\n`;
        result += `Total Money: ${customer.totalMoney}$\n`;
        result += 'Transactions:\n';

        customer.transactions.sort((a, b) => {
            return b.id - a.id
        });

        for (const transaction of customer.transactions) {
            let isDeposit = transaction.operation === 'withdraw' ? 'withdrew' : 'made depostit of';
            result += `${transaction.id}. ${transaction.firstName} ${transaction.lastName} ${isDeposit} ${transaction.amount}$!\n`;
        }

        return result;
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
// console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
// bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
