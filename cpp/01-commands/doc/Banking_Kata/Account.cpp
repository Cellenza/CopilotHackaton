#include "pch.h"
#include "Account.h"

long Account::getBalance() const
{
    return _balance;
}

const std::vector<BankingTransactionDTO>& Account::getStatement() const
{
    return _statement;
}

void Account::Deposit(long amount)
{
    _balance += amount;
    _statement.push_back(BankingTransactionDTO(std::chrono::system_clock::now(), +amount, _balance));
}

void Account::Withdrawal(long amount)
{
    _balance -= amount;
    _statement.push_back(BankingTransactionDTO(std::chrono::system_clock::now(), -amount, _balance));
}
