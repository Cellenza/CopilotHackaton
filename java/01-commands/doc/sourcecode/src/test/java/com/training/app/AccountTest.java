package com.training.app;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class AccountTest {

    @Test
    public void whenADepositInMade_BankAccountIncreasesByThisAmount() {
        // Arrange
        int depositAmount = 500;
        Account account = new Account();

        // Act
        account.deposit(depositAmount);

        // Assert
        assertEquals(depositAmount, account.getBalance());
    }

    @Test
    public void whenAWithdrawIsDone_BankAccountDecreasesByThisAmountAndStatementUpdated() {
        // Arrange
        Account account = new Account();
        int withdrawAmount = 500;

        // Act
        account.withdraw(withdrawAmount);

        // Assert
        assertEquals(-withdrawAmount, account.getBalance());
    }

    @Test
    public void whenAWithdrawAfterDepositIsDone_BankAccountShouldBeEqualToDepositMinusWithdrawAndStatementUpdated() {
        // Arrange
        Account account = new Account();
        int depositAmount = 500;
        int withdrawAmount = 500;

        // Act
        account.deposit(depositAmount);
        account.withdraw(withdrawAmount);

        // Assert
        assertEquals(depositAmount - withdrawAmount, account.getBalance());
    }

    @Test
    public void whenADepositInMade_BankIsUpdatedByThisAmount() {
        // Arrange
        int depositAmount = 500;
        Account account = new Account();
        List<BankingTransactionDTO> expectedStatement = new ArrayList<>();
        expectedStatement.add(new BankingTransactionDTO(LocalDate.now(), depositAmount, depositAmount));

        // Act
        account.deposit(depositAmount);

        // Assert
        List<BankingTransactionDTO> statement = account.getStatement();
        assertEquals(expectedStatement.size(), statement.size());
        for (int i = 0; i < statement.size(); i++){
            assertEquals(statement.get(i), statement.get(i));
        }
    }

    @Test
    public void whenAWithdrawIsMade_BankIsUpdatedByThisAmount() {
        // Arrange
        int withdrawAmount = 500;
        Account account = new Account();
        List<BankingTransactionDTO> expectedStatement = new ArrayList<>();
        expectedStatement.add(new BankingTransactionDTO(LocalDate.now(), -withdrawAmount, -withdrawAmount));

        // Act
        account.withdraw(withdrawAmount);

        // Assert
        List<BankingTransactionDTO> statement = account.getStatement();
        assertEquals(expectedStatement.size(), statement.size());
        for (int i = 0; i < statement.size(); i++){
            assertEquals(statement.get(i), statement.get(i));
        }
    }
}