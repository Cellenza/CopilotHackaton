const BankingTransactionDTO = require('./BankingTransactionDTO');

class Account {
    constructor() {
        this.balance = 0;
        this.statement = [];
    }

    getBalance() {
        return this.balance;
    }

    getStatement() {
        return this.statement;
    }

    deposit(depositAmount) {
        this.balance += depositAmount;
        this.statement.push(new BankingTransactionDTO(new Date(), depositAmount, this.balance));
    }
}

module.exports = Account;