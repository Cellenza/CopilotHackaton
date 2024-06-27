#pragma once
#include "BankingTransactionDTO.h"

class Account
{
public:
    Account() = default;
    long getBalance() const;
    const std::vector<BankingTransactionDTO>& getStatement() const;

    void Deposit(long amount);
    void Withdrawal(long amount);

private:
    long _balance = 0;
    std::vector<BankingTransactionDTO> _statement;
};

