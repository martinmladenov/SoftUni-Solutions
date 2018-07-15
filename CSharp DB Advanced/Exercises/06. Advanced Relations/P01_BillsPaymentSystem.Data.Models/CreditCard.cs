namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class CreditCard
    {
        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {
            Limit = limit;
            MoneyOwed = moneyOwed;
            ExpirationDate = expirationDate;
        }

        public int CreditCardId { get; set; }

        public decimal Limit { get; private set; }

        public decimal MoneyOwed { get; private set; }

        public decimal LimitLeft => Limit - MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException();
            }

            if (LimitLeft < amount)
            {
                throw new InvalidOperationException();
            }

            MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException();
            }

            MoneyOwed -= amount;
        }
    }
}
