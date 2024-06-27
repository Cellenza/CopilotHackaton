namespace Banking_Kata
{
    public class AccountTest
    {
        [Fact]
        public void WhenADepositInMade_BankAccountInceasesByThisAmount()
        {
            //Arrange 
            int depositAmount = 500;
            Account account = new Account();

            //Act
            account.Deposit(depositAmount);

            //Assert
            Assert.Equal(depositAmount, account.balance);
        }

        [Fact]
        public void WhenAWithdrawIsDone_BankAccountDecreasesByThisAmountAndStatementUpdated()
        {
            //Arrange 
            Account account = new Account();
            int withdrawAmount = 500;

            //Act
            account.Withdraw(withdrawAmount);

            //Assert
            Assert.Equal(-withdrawAmount, account.balance);
        }

        [Fact]
        public void WhenAWithdrawAfterDepositIsDone_BankAccountShouldBeUpdated()
        {
            //Arrange 
            Account account = new Account();
            int depositAmount = 500;
            int withdrawAmount = 500;

            //Act
            account.Deposit(depositAmount);
            account.Withdraw(withdrawAmount);

            //Assert
            Assert.Equal(depositAmount -withdrawAmount, account.balance);
        }

        [Fact]
        public void WhenADepositInMade_BankIsUpdatedByThisAmount()
        {
            //Arrange 
            int depositAmount = 500;
            Account account = new Account();
            List<BankingTransactionDTO> expectedStatement = new List<BankingTransactionDTO>();
            expectedStatement.Add(new BankingTransactionDTO(DateTime.Today, depositAmount, depositAmount));

            //Act
            account.Deposit(depositAmount);

            //Assert
            Assert.Equal(expectedStatement, account.statement);
        }

        [Fact]
        public void WhenAWithdrawIsMade_BankIsUpdatedByThisAmount()
        {
            //Arrange 
            int withdrawAmount = 500;
            Account account = new Account();
            List<BankingTransactionDTO> expectedStatement = new List<BankingTransactionDTO>();
            expectedStatement.Add(new BankingTransactionDTO(DateTime.Today, -withdrawAmount, -withdrawAmount));

            //Act
            account.Withdraw(withdrawAmount);

            //Assert
            Assert.Equal(expectedStatement, account.statement);
        }
    }
}