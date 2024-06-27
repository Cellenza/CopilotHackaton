namespace Banking_Kata
{
    public record BankingTransactionDTO
    {
        public DateTime date { get; private set; }
        public int amount { get; private set; }
        public int balance { get; private set; }

        public BankingTransactionDTO(DateTime date, int amount, int balance)
        {
            this.date = date;
            this.amount = amount;
            this.balance = balance;
        }
    }
}