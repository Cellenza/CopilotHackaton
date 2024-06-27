package com.training.app;

import java.util.List;

public class AccountStatementPrint {
    public static String printStatement(List<BankingTransactionDTO> transactionList) {
        String printedStatement = "Date Amount Balance\n";
        for (BankingTransactionDTO transaction : transactionList) {
            printedStatement += transaction.getDate().toString() + " " +
                    (transaction.getAmount() >= 0 ? "+" : "") + 
                    transaction.getAmount() + " " +
                    transaction.getBalance() + "\n";
        }

        return printedStatement;
    }
}
