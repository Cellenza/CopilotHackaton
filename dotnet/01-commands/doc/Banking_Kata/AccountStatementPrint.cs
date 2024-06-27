namespace Banking_Kata
{
    internal static class AccountStatementPrint
    {
        public static string PrintStatement(List<BankingTransactionDTO> transactiontList)
        {
            // Initialize the printed statement with the header
            string printedStatement = "Date Amount Balance\n";

            // Iterate over each transaction in the list
            foreach (BankingTransactionDTO transaction in transactiontList)
            {
                // Format each transaction's details and append to the printed statement
                printedStatement += $"{transaction.date.ToString("d")} " +
                    $"{(transaction.amount >= 0 ? "+" : "")}{transaction.amount} " +
                    $"{transaction.balance}\n";
            }

            // Return the final formatted statement
            return printedStatement;
        }

    }
}