const Account = require('./Account');
const AccountStatementPrint = require('./AccountStatementPrint');

test('App initializes account and prints statement', () => {
    const account = new Account();
    account.deposit(100);
    account.deposit(200);

    const printer = new AccountStatementPrint();
    const consoleSpy = jest.spyOn(console, 'log').mockImplementation(() => {});

    printer.print(account.getStatement());

    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Date:'));
    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Amount: 100'));
    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Balance: 100'));
    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Amount: 200'));
    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Balance: 300'));

    consoleSpy.mockRestore();
});