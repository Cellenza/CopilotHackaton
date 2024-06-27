package com.training.app;

import java.time.LocalDate;

public class BankingTransactionDTO {
    private LocalDate date;
    private int amount;
    private int balance;

    public BankingTransactionDTO(LocalDate date, int amount, int balance) {
        this.date = date;
        this.amount = amount;
        this.balance = balance;
    }

    public LocalDate getDate() {
        return date;
    }

    public int getAmount() {
        return amount;
    }

    public int getBalance() {
        return balance;
    }
}