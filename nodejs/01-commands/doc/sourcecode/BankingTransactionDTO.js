class BankingTransactionDTO {
    constructor(date, amount, balance) {
        this.date = date;
        this.amount = amount;
        this.balance = balance;
    }
}

module.exports = BankingTransactionDTO;