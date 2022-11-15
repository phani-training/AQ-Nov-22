/*
 * Methods of the base class can be created but need not be implemented. The derived class will implement those methods as per their requirement. 
 * Those methods should be marked with a modifier called abstract. If a class has one or more abstract methods, then the class should have abstract keyword at its declaration. 
 * Abstract classes cannot be instantiated, as one or more methods of the class are not implemented and it becomes an incomplete class.
 * override modifier is required when the derived class implements an abstract method.
 * If the derived class fails to implement any abstract method, then the class should also be marked as abstract. 
 */
using System;

namespace SampleConsoleApp
{
    abstract class Account
    {
        public Account(int amount = 5000)
        {
            Balance = amount;//Initialization
        }
        public int AccountNo { get; set; }
        public string AccountHolder { get; set; }
        public double Balance { get; private set; }
        public void Credit(double amount) => Balance += amount;
        public void Debit(double amount)
        {
            if (amount < Balance)
                throw new Exception("Insufficient Funds");
            Balance -= amount;
        }
        public abstract void CalculateInterest();
    }

    class SBAccount : Account
    {
        public override void CalculateInterest()
        {
            double principal = Balance;
            double rateOfInterest = 6.5/100;
            double term = 0.25;
            double interest = principal * rateOfInterest * term;
            Credit(interest);
        }
    }

    class AbstractClassDemo
    {
        static void Main(string[] args)
        {
            Account acc = new SBAccount();
            acc.Credit(5000);
            acc.CalculateInterest();
            Console.WriteLine("The current balance: " + acc.Balance);
        }
    }
}