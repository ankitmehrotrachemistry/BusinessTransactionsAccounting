using BusinessTransactionsAccounting.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTransactionsAccounting.Services
{
    public class AccountingService
    {
        private static List<Account> _accounts = new List<Account>
        {
            new Account { Id = 1, AccountName = "Cash", Balance = 1000 },
            new Account { Id = 2, AccountName = "Bank", Balance = 5000 }
        };

        private static List<Transaction> _transactions = new List<Transaction>();

        public List<Account> GetAllAccounts() => _accounts;

        public Account GetAccountById(int id) => _accounts.FirstOrDefault(a => a.Id == id);

        public List<Transaction> GetTransactions(int accountId) =>
            _transactions.Where(t => t.AccountId == accountId).ToList();

        public void AddTransaction(Transaction transaction)
        {
            var account = GetAccountById(transaction.AccountId);
            if (account != null)
            {
                if (transaction.Type == "Credit")
                    account.Balance += transaction.Amount;
                else if (transaction.Type == "Debit")
                    account.Balance -= transaction.Amount;

                _transactions.Add(transaction);
            }
        }
    }
}
