namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class BankAccount
    {
        public BankAccount(decimal balance, string bankName, string swiftCode)
        {
            Balance = balance;
            BankName = bankName;
            SwiftCode = swiftCode;
        }

        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException();
            }

            if (Balance < amount)
            {
                throw new InvalidOperationException();
            }

            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException();
            }

            Balance += amount;
        }
    }
}
