using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyBankApp
{
   public class Customer
    {
        public string Name { get; set; }
        public string email { get; set; }
        public string CustomerId { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        



        public BankAccount Account { get; set; }

        private static int Id = 0001;
       

        public Customer(string name, string email, string username, string password)
        {
            this.Name = name;
            this.email = email;
            this.UserName = username;
            this.Password = password;
            

            
            
            this.CustomerId = Id.ToString();
            Id++;
        }

        public Customer(string name, string email)
        {
            Name = name;
            this.email = email;
        }
    }
}
