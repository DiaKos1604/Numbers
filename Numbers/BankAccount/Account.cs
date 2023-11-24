namespace Basic.BankAccount
{
    public class Account
    {
        private float balance;
        public int AccountNumber { get; internal set; }
        
        public void Withdraw(float amount)
        {
            ValidateAmount(amount);
            if (balance < amount)
            {
                throw new Exception("Niewystarczające środki na koncie.");
            }
            balance -= amount;
        }
        public void Deposit(float amount)
        {
            ValidateAmount(amount);
            balance += amount;
        }

        public float GetBalance()=> balance;
        private void ValidateAmount(float amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Kwota musi być liczbą dodatnią.");
            }
        }

        public void Transfer(Account otherAccount, float amount)
        {
            ValidateAmount(amount);
            if (balance < amount)
            {
                throw new Exception("Niewystarczające środki na koncie.");
            }
            if (otherAccount == null)
            {
                throw new ArgumentNullException(nameof(otherAccount), "Konto docelowe nie istnieje.");
            }

            Withdraw(amount);
            otherAccount.Deposit(amount);

        }

    }
}
