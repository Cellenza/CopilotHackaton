namespace Banking_Kata
{
    public class AccountStatementPrintTest
    {

        [Fact]
        public void WhenAPrintStatementIsAskedAfterTheFirstDeposit_DateAmountAndBalanceArePrinted()
        {
            //Arrange 
            List<BankingTransactionDTO> statement = new List<BankingTransactionDTO>();
            string expectedOutput = "Date Amount Balance\n" +
                                    $"{DateTime.Today.ToString("d")} +500 500\n";
            
            //Act
            statement.Add(new BankingTransactionDTO(DateTime.Today, 500, 500));


            //Assert
            Assert.Equal(expectedOutput, AccountStatementPrint.PrintStatement(statement));
        }

        [Fact]
        public void WhenAPrintStatementIsAskedAfterADepositAndAWithdraw_DateAmoutAndBalanceArePrinted()
        {
            //Arrange 
            List<BankingTransactionDTO> statement = new List<BankingTransactionDTO>();
            string expectedOutput = "Date Amount Balance\n" +
                                    $"{DateTime.Today.ToString("d")} +500 500\n" +
                                    $"{DateTime.Today.ToString("d")} -100 400\n";

            //Act
            statement.Add(new BankingTransactionDTO(DateTime.Today, 500, 500));
            statement.Add(new BankingTransactionDTO(DateTime.Today, -100, 400));

            //Assert
            Assert.Equal(expectedOutput, AccountStatementPrint.PrintStatement(statement));
        }
    }
}