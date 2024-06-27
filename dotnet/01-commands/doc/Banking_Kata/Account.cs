
namespace Banking_Kata
{
    /// <summary>
    /// The 'Account' class represents a bank account with capabilities to track balance and transactions.
    /// </summary>
    internal class Account
    {
        public int balance { get; private set; }
        public List<BankingTransactionDTO> statement { get; private set; }

        public Account()
        {
            statement = new List<BankingTransactionDTO>();
        }

        public void Deposit(int depositAmount)
        {
            balance += depositAmount;
            statement.Add(new BankingTransactionDTO(DateTime.Today, +depositAmount, balance));
        }

        public void Withdraw(int withdrawAmount)
        {
            balance -= withdrawAmount;
            statement.Add(new BankingTransactionDTO(DateTime.Today, -withdrawAmount, balance));
        }
    }
}