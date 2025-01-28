const Account = require('./Account');
const BankingTransactionDTO = require('./BankingTransactionDTO');

test('Account initializes with zero balance and empty statement', () => {
    const account = new Account();
    expect(account.getBalance()).toBe(0);
    expect(account.getStatement()).toEqual([]);
});

test('Account deposit updates balance and statement', () => {
    const account = new Account();
    account.deposit(100);
    expect(account.getBalance()).toBe(100);
    expect(account.getStatement()).toHaveLength(1);
    expect(account.getStatement()[0]).toBeInstanceOf(BankingTransactionDTO);
    expect(account.getStatement()[0].amount).toBe(100);
    expect(account.getStatement()[0].balance).toBe(100);
});

test('Multiple deposits update balance and statement correctly', () => {
    const account = new Account();
    account.deposit(100);
    account.deposit(200);
    expect(account.getBalance()).toBe(300);
    expect(account.getStatement()).toHaveLength(2);
    expect(account.getStatement()[1].amount).toBe(200);
    expect(account.getStatement()[1].balance).toBe(300);
});