using MyBankApp;
using MyBankApp.ClassLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppTest
{
    public static class Session
    {
        public static bool status { get; set; }

        public static BankAccount Register (string name, string email, string username, string pass, AccountType type, decimal bal)
        {
            // initialize customer and account to null
            Customer cus = null;
            BankAccount acc = null;

            // create customer
            cus = new Customer(name, email, username, pass);

            // create Account
            acc = new BankAccount(type, bal, cus);

            Banks.customers.Add(cus);
            Banks.accounts.Add(acc);

            var trans = new Transaction(bal, DateTime.Now, "opening balance", cus, cus.Account);

            //update transaction lists
            Banks.allTransactions.Add(trans);

            new utility().createSession(cus.CustomerId, cus.Name, cus.email, cus.Password);
            status = true;

            return acc;
        }

        public static BankAccount Login(string email, string pass)
        {
            string Id = null;
            string Email = null;
            string Name = null;
            string password = null;
            string AccNum = null;
            BankAccount acc = null;

            for (int i = 0; i < Banks.customers.Count; i++)
            {
                if (Banks.customers[i].email == email)
                {
                    Id = Banks.customers[i].CustomerId;
                    Email = Banks.customers[i].email;
                    Name = Banks.customers[i].Name;
                    password = Banks.customers[i].Password;
                    break;
                }
            }

            if (Email == null)
            {
                return null;
            }
            if (password != pass)
            {
                return null;
            }

            for (int i = 0; i < Banks.accounts.Count; i++)
            {
                if (Banks.accounts[i].Owner.CustomerId == Id)
                {
                    acc = new BankAccount
                    {
                        type = Banks.accounts[i].type,                        
                        Owner = Banks.accounts[i].Owner
                        
                    };
                    AccNum = Banks.accounts[i].Number;
                }
            }

            new utility().createSession(Id, Name, Email, AccNum);
            status = true;

            return acc;

        }

        // create the logout method
        public static void Logout()
        {
            LoggingDetails.Email = null;
            LoggingDetails.Id = null;
            LoggingDetails.Password = null;
            status = false;
        }
    }
}
