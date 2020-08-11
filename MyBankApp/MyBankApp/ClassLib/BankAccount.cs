using System;
using System.Collections.Generic;
using System.Text;



namespace MyBankApp
{
    public enum AccountType
    {
        Savings,
        Current
    }
   public class BankAccount
    {
        public string Number { get; }
        public Customer Owner { get; set; }
        public AccountType type { get; set; }

        

        public decimal balance 
        {
            get
            {
                decimal balance = 0;
                foreach (var transact in Banks.allTransactions)
                {
                    if(this.Number == transact.account.Number)
                    balance += transact.Amount;
                }
                return balance;
            } 
        }
        
        private static int  AccountNumberSeed = 1013456210;


        public BankAccount()
        {

        }
        public BankAccount(AccountType type, decimal initialBalance, Customer customer)
        {
            this.Owner = customer;
            customer.Account = this;
            MakeDeposit(initialBalance, DateTime.Now, "This is the initial balnce");
            this.Number = AccountNumberSeed.ToString();
            AccountNumberSeed++;
            Banks.accounts.Add(this);
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
            var deposit = new Transaction(amount, date, note, this.Owner, this);
            Banks.allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, AccountType accountType, DateTime date, string note)
        {
            if (accountType == AccountType.Savings && balance - amount < 100) throw new InvalidOperationException("You have Insufficient funds");
                      
            if (accountType == AccountType.Current && balance - amount < 1000) throw new InvalidOperationException("You have Insufficient funds");
            
            var withdrawal = new Transaction(-amount, date, note, this.Owner, this);
            Banks.allTransactions.Add(withdrawal);
        }

        public void Transfer(BankAccount reciverAccount,AccountType type, decimal amount, DateTime date, string note)
        {
            if (reciverAccount.Number == this.Number)
            {
                throw new AccessViolationException("You cannot transfer to yourself");
            }
            reciverAccount.MakeDeposit(amount, date, note);
            this.MakeWithdrawal(amount, type, date, note);        
        }
          public string TransactionHistory()
        {
            var history = new StringBuilder();
            history.AppendLine("Fullname\t\tAccount Number\t\tType\t\tAmount\t\tBalance\t\tNote\t\tDate");
            foreach (var item in Banks.allTransactions)
            {
                _ = history.AppendLine($"{item.Customer.Name}\t\t{item.Customer.Account.Number}\t\t" +
                    $"{item.Customer.Account.type}\t\t{item.Amount}\t\t{item.account.balance}\t\t{item.Notes}\t\t{item.Date.ToShortDateString()}");
            }
            return history.ToString();
        }
    }
}
