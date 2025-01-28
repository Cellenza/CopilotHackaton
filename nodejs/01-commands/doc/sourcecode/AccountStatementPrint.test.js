const AccountStatementPrint = require('./AccountStatementPrint');
const BankingTransactionDTO = require('./BankingTransactionDTO');

test('AccountStatementPrint prints the statement correctly', () => {
    const statement = [
        new BankingTransactionDTO(new Date('2023-01-01'), 100, 100),
        new BankingTransactionDTO(new Date('2023-01-02'), 200, 300)
    ];

    const printer = new AccountStatementPrint();
    const consoleSpy = jest.spyOn(console, 'log').mockImplementation(() => {});

    printer.print(statement);

    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Date:'));
    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Amount: 100'));
    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Balance: 100'));
    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Amount: 200'));
    expect(consoleSpy).toHaveBeenCalledWith(expect.stringContaining('Balance: 300'));

    consoleSpy.mockRestore();
});