package com.training.app;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class Account {
    private int balance;
    private List<BankingTransactionDTO> statement;

    public Account() {
        statement = new ArrayList<>();
    }

    public int getBalance() {
        return balance;
    }

    public List<BankingTransactionDTO> getStatement() {
        return statement;
    }

    public void deposit(int depositAmount) {
        balance += depositAmount;
        statement.add(new BankingTransactionDTO(LocalDate.now(), depositAmount, balance));
    }

    public void withdraw(int withdrawAmount) {
        balance -= withdrawAmount;
        statement.add(new BankingTransactionDTO(LocalDate.now(), -withdrawAmount, balance));
    }
}