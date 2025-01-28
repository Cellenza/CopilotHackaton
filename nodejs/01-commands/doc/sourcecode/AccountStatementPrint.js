class AccountStatementPrint {
    print(statement) {
        statement.forEach(transaction => {
            console.log(`Date: ${transaction.date}, Amount: ${transaction.amount}, Balance: ${transaction.balance}`);
        });
    }
}

module.exports = AccountStatementPrint;