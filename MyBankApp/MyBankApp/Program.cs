﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Dynamic;

namespace MyBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool response = true;
            while (response)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Welcome to Grand Bank");
                Console.WriteLine("-------------------------------");
                Console.WriteLine();
                Console.WriteLine("To Create an Account Press 1:");
                Console.WriteLine();
                Console.WriteLine("To Sign in press 2:");
                var reply = Int32.Parse(Console.ReadLine());

                if (reply == 1)
                {

                    Console.WriteLine("Enter Your Full Name: ");
                    var userName = Console.ReadLine();
                    Console.WriteLine("Enter your Email Address: ");
                    var email = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter you preferred password: '123456' ");
                    var pWord = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Choose Your Account Type");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("To Open a Savings Account 1: ");
                    Console.WriteLine();
                    Console.WriteLine("To Open a Current Account 2: ");
                    var typeOfAccount = Int32.Parse(Console.ReadLine());
                    if (typeOfAccount == 1)
                    {
                        var customer = new Customer(userName, email);
                        var loging1 = new LoggingDetails();
                        
                        Console.WriteLine("To activate your account you need to make a deposit: ");
                        Decimal money;
                        var input = Decimal.TryParse(Console.ReadLine(), out money);
                       
                     
                        if (input && money > 100)
                        {

                            var account = new BankAccount(AccountType.Savings, money, customer);

                        }
                        if (!input || money < 100)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That operation is not allowed!");

                            Console.ForegroundColor = ConsoleColor.White;
                           
                        }

                        Console.WriteLine($"Welcome to Grand Bank {customer.Name}, your account number is {customer.Account.Number} Your opening balance is {customer.Account.balance}");

                    }
                    if (typeOfAccount == 2)
                    {
                       //var customer = new Customer(userName, email);
                        Console.WriteLine("To activate your account you need to make a deposit: ");
                        Decimal money;
                        var input = Decimal.TryParse(Console.ReadLine(), out money);
                        if (input && money >= 1000)
                        {
                            var account = new BankAccount(AccountType.Current, money, customer);
                            
                        }
                           
                        if (!input || money < 1000)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That operation is not allowed!");

                            Console.ForegroundColor = ConsoleColor.White;
                           
                        }

                        Console.WriteLine($"Welcome to Grand Bank {customer.Name} Your opening balance is {customer.Account.balance} your balance is {customer.Account.balance}");
                    }
                    
                }
                if (reply == 2)
                {
                    bool loggedIn = false;
                    var loging = new LoggingDetails();
                    
                    Console.WriteLine(" Enter userName (Your name is also your username) : ");
                    var email = Console.ReadLine();
                    Console.WriteLine("Enter your email: ");
                    var mail = Console.ReadLine();
                    Console.WriteLine("Enter your Pin code: ");
                    var pinCode = Int32.Parse(Console.ReadLine());
                   
                }
                

                response = false;

            }
           


            

        }
    }
}