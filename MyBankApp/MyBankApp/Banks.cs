using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankApp
{
    class Banks
    {
        public List<BankAccount> accounts = new List<BankAccount>();
        public List<Customer> customers = new List<Customer>();
        public int Pin { get; set; }

        public Customer MakeAccount(string name, string email, AccountType type, int initialBalance, int pin)
        {
            Customer customer = new Customer(name, email);
            BankAccount bankAccount = new BankAccount(type, initialBalance, customer);
            this.Pin = pin;
            this.customers.Add(customer);
            this.accounts.Add(bankAccount);
            return customer;
    }

    }
}
