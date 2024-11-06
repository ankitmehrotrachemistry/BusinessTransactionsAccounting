using System;

namespace BusinessTransactionsAccounting.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }  // Positive for credit, negative for debit
        public string Type { get; set; }  // "Credit" or "Debit"
    }
}
