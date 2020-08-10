using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankApp
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }
        
        public Customer Customer { get; }
        public BankAccount account { get; }
       
        


        public Transaction(decimal amount, DateTime date, string notes, Customer customer, BankAccount account)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = notes;
            this.Customer = customer;
            this.account = account;
        }
    }
}
