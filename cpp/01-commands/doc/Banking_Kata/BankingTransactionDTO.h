#pragma once

class BankingTransactionDTO
{
public:
    BankingTransactionDTO(timepoint date, long amount, long balance);

    const timepoint& getDate() const;
    long getAmount() const;
    long getBalance() const;

private:
    timepoint _date; // Date of the transation.
    long _amount;    // Amount of the transaction.
    long _balance;   // Balance of the account after the transaction.
};

