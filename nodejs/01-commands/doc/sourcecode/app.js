const Account = require('./Account');
const AccountStatementPrint = require('./AccountStatementPrint');

const account = new Account();
account.deposit(100);
account.deposit(200);

const printer = new AccountStatementPrint();
printer.print(account.getStatement());