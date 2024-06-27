package com.training.app;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class AccountStatementPrintTest {

    @Test
    public void whenAPrintStatementIsAskedAfterTheFirstDeposit_DateAmountAndBalanceArePrinted() {
        // Arrange 
        List<BankingTransactionDTO> statement = new ArrayList<>();
        String expectedOutput = "Date Amount Balance\n" +
        LocalDate.now().toString() + " +500 500\n";
        
        // Act
        statement.add(new BankingTransactionDTO(LocalDate.now(), 500, 500));

        // Assert
        assertEquals(expectedOutput, AccountStatementPrint.printStatement(statement));
    }

    @Test
    public void whenAPrintStatementIsAskedAfterADepositAndAWithdraw_DateAmoutAndBalanceArePrinted() {
        // Arrange 
        List<BankingTransactionDTO> statement = new ArrayList<>();
        String expectedOutput = "Date Amount Balance\n" +
        LocalDate.now().toString() + " +500 500\n" +
        LocalDate.now().toString() + " -100 400\n";

        // Act
        statement.add(new BankingTransactionDTO(LocalDate.now(), 500, 500));
        statement.add(new BankingTransactionDTO(LocalDate.now(), -100, 400));

        // Assert
        assertEquals(expectedOutput, AccountStatementPrint.printStatement(statement));
    }
}
