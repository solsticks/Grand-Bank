using NUnit.Framework;
using MyBankApp;
using System;

namespace BankAppTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DepositTest()// This test for the amount I am depositing and to ensure the balance reflects the actual amount.
        {
            //Arrange
            var cus = new Customer("David", "david@mail.com");
            var sut = new BankAccount(AccountType.Savings, 2000, cus);
            //Act
            cus.Account.MakeDeposit(1000, DateTime.Now, "I should have 3000 now");
            var see = sut.balance;
            decimal amount = 3000;
            //Assert
            Assert.That(see, Is.EqualTo(amount));
        }

        [Test]
        public void NegativeDepositTest()// This test for the amount I want to deposit. It is suppose to throw an exception if it is negative amount.
        {
            //Arrange
            var cus = new Customer("David", "david@mail.com");
            //Act
            var sut = new BankAccount(AccountType.Savings, 2000, cus);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=> sut.MakeDeposit(-2000, DateTime.Now, "this should an error")
                );
        }

        [Test]
        public void WithdrawalTest()// This test to see if the amount I am withdrawing is the same and the method returns the right figure.
        {
            //Arrange
            var cus = new Customer("David", "david@mail.com");
            var sut = new BankAccount(AccountType.Savings, 2000, cus);
            //Act
            cus.Account.MakeWithdrawal(1000, AccountType.Savings, DateTime.Now, "I should have 1000 left");
            var see = sut.balance;
            decimal amount = 1000;
            //Assert
            Assert.That(see, Is.EqualTo(amount));
        }

        [Test]
        public void TransferTestToTheReceiverAccount()// this is testing to see if the reciever got the funds
        {
            //Arrange
            var cus = new Customer("David", "david@mail.com");
            var sut = new BankAccount(AccountType.Savings, 2000, cus);

            var cus2 = new Customer("Tosin", "tosin@mail.com");
            var sut2 = new BankAccount(AccountType.Current, 2000, cus2);
            
            //Act
            cus.Account.Transfer(cus2.Account, AccountType.Current, 500, DateTime.Now, "Your balance should increade by 500");
            var see = cus2.Account.balance;
            decimal amount = 2500;
            //Assert
            Assert.That(see, Is.EqualTo(amount));
        }

        [Test]
        public void BalanceAfterTransfer()// this is testing to see the balance after the transfer
        {
            //Arrange
            var cus = new Customer("David", "david@mail.com");
            var sut = new BankAccount(AccountType.Savings, 2000, cus);

            var cus2 = new Customer("Tosin", "tosin@mail.com");
            var sut2 = new BankAccount(AccountType.Current, 2000, cus2);

            //Act
            cus.Account.Transfer(cus2.Account, AccountType.Current, 500, DateTime.Now, "Your balance should decreased by 500");
            var see = cus.Account.balance;
            decimal amount = 1500;
            //Assert
            Assert.That(see, Is.EqualTo(amount));
        }

        [Test]
        public void Transfer_Test_To_The_Sending_Account()// This checks if you try to transfer funds to yourself and breaks
        {
            //Arrange
            var cus = new Customer("David", "david@mail.com");
            var sut = new BankAccount(AccountType.Savings, 2000, cus);

            
            //Act
            //cus.Account.Transfer(cus.Account, AccountType.Current, 500, DateTime.Now, "Your balance should increade by 500");

            //Assert
            Assert.Throws<AccessViolationException>(
                ()=> cus.Account.Transfer(cus.Account, AccountType.Current, 500, DateTime.Now, "Your balance should increade by 500")
                );
        }

        [Test]
        public void MinimumBalance_Test_for_savingsAccount()// this is testing to see if this method will throw an error if you try to withdraw below the minimum balance.
        {
            //Arrange
            var cus = new Customer("David", "david@mail.com");
            var sut = new BankAccount(AccountType.Savings, 2000, cus);


            //Act
            //cus.Account.MakeWithdrawal(1910, AccountType.Savings, DateTime.Now, "You should have an error");
            //Assert
            Assert.Throws<InvalidOperationException>(
                ()=> cus.Account.MakeWithdrawal(1910, AccountType.Savings, DateTime.Now, "You should have an error")
                );
        }

        [Test]
        public void MinimumBalance_Test_for_CurrentAccount()// this is testing to see if this method will throw an error if you try to withdraw below the minimum balance.
        {
            //Arrange
            var cus = new Customer("Fred", "fred@mail.com");
            var sut = new BankAccount(AccountType.Current, 2000, cus);


            //Act
            //cus.Account.MakeWithdrawal(1910, AccountType.Savings, DateTime.Now, "You should have an error");
            //Assert
            Assert.Throws<InvalidOperationException>(
                () => cus.Account.MakeWithdrawal(1100, AccountType.Current, DateTime.Now, "You should have an error")
                );
        }

        [Test]
        public void TestForCustomerReg()// this is testing to see if the customer details is collected and accessible.
        {
            //Arrange
            var cus3 = new Customer("David", "david@mail.com");
            var sut = new BankAccount(AccountType.Savings, 2000, cus3);
            //act
            var name = "David";
           
            Assert.That(name, Is.EqualTo(Banks.accounts[0].Owner.Name));
        }

        [Test]
        public void TestforLogging()// testing to see if the the logging is working
        {
            //Arrange
            Session.Register("sola", "sola@mail.com", "sola", "12345", AccountType.Savings, 2000);
            var sut = Session.Login("sola@mail.com", "12345");

            //Assert
            Assert.That(sut, Is.Not.EqualTo(null));
        }

        [Test]
        public void TestforLogout()// testing to see if it returns null after logging out.
        {
            //Arrange
            Session.Register("sola", "sola@mail.com", "sola", "12345", AccountType.Savings, 2000);
            Session.Logout();

            //Assert
            Assert.IsFalse(Equals(LoggingDetails.Email));
        }

        [Test]
        public void Transactions()// this is testing to see if this method will throw an error if you try to withdraw below the minimum balance.
        {
            //Arrange
            var cus = new Customer("David", "david@mail.com");
            var sut = new BankAccount(AccountType.Savings, 2000, cus);

            var cus2 = new Customer("Davidt", "david@mail.com");
            var sut2 = new BankAccount(AccountType.Current, 2000, cus);

            //Act
            var count = Banks.allTransactions.Count;
            //Assert
            Assert.That(count, Is.GreaterThan(1));
        }
    }
}