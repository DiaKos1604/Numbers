using System;

namespace Basic.BankAccount
{
    public class Bank
    {
        private readonly List<Account> accounts = new List<Account>();
        private readonly Random random = new Random();

        public Account GetAccount(int accountNumber) => accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        public List<Account> GetAllAccounts() => new List<Account>(accounts);
        public Account CreateAccountForUser()
        {
            int newAccountNumber = GenerateAccountNumber();
            var newAccount = new Account { AccountNumber = newAccountNumber };
            accounts.Add(newAccount);
            return newAccount;
        }
        public int GenerateAccountNumber()
        {
            string accountNumber;
            do
            {
                accountNumber = string.Concat(Enumerable.Range(0, 10).Select(_ => random.Next(0, 10)));
            }
            while (accounts.Any(a => a.AccountNumber.ToString() == accountNumber));

            return int.Parse(accountNumber);
        }
        public void RemoveAccount(int accountNumber)
        {
            var accountToRemove = GetAccount(accountNumber);
            if (accountToRemove != null)
            {
                accounts.Remove(accountToRemove);
            }
            else
            {
                throw new Exception("Nie znaleziono konta o podanym numerze.");
            }
        }
        public void LoadAccountsFromFile(string accountsFilePath)
        {
            using (var reader = new StreamReader(accountsFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var accountData = line.Split(',');
                    var account = new Account
                    {
                        AccountNumber = int.Parse(accountData[0]),
                    };
                    accounts.Add(account);
                }
            }
        }

        public void SaveAccountsToFile(string filePath)
        {
            using (var write = new StreamWriter(filePath))
            {
                foreach (var account in accounts)
                {
                    var line = $"{account.AccountNumber}";
                    write.WriteLine(line);
                }
            }
        }
        public void CreateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Konto nie może być null.");

            }
            accounts.Add(account);
        }
        
    }
}
