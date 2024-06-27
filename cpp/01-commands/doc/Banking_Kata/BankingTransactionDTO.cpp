#include "pch.h"
#include "BankingTransactionDTO.h"

BankingTransactionDTO::BankingTransactionDTO(timepoint date, long amount, long balance)
    : _date(date), _amount(amount), _balance(balance)
{}

const timepoint& BankingTransactionDTO::getDate() const
{
    return _date;
}

long BankingTransactionDTO::getAmount() const
{
    return _amount;
}

long BankingTransactionDTO::getBalance() const
{
    return _balance;
}
