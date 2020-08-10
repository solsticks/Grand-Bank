using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankApp
{
  public static class Banks
    {
        public static List<BankAccount> accounts { get; set; } = new List<BankAccount>();
        public static List<Customer> customers { get; set; } = new List<Customer>();

        public static List<Transaction> allTransactions = new List<Transaction>();
    }
}
