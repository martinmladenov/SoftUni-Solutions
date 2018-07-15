namespace P01_BillsPaymentSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
                Seed(context);

                Console.Write("Pay bills of user with id: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                PayBills(userId, amount, context);

                Console.Write("Show info for user with id: ");
                ShowUserInfo(int.Parse(Console.ReadLine()), context);
            }
        }

        private static void PayBills(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            User user = context.Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(m => m.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(m => m.CreditCard)
                .SingleOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            var bankAccounts = user.PaymentMethods
                .Where(x => x.Type == PaymentMethodType.BankAccount)
                .Select(x => x.BankAccount)
                .OrderBy(x => x.BankAccountId)
                .ToArray();

            var creditCards = user.PaymentMethods
                .Where(x => x.Type == PaymentMethodType.CreditCard)
                .Select(x => x.CreditCard)
                .OrderBy(x => x.CreditCardId)
                .ToArray();

            decimal totalAmount = bankAccounts.Sum(x => x.Balance) + creditCards.Sum(x => x.LimitLeft);

            if (totalAmount < amount)
            {
                Console.WriteLine("Insufficient funds!");
                return;
            }

            for (int i = 0; i < bankAccounts.Length && amount > 0; i++)
            {
                BankAccount bankAccount = bankAccounts[i];
                decimal balance = bankAccount.Balance;
                if (balance <= 0) continue;
                bankAccount.Withdraw(Math.Min(amount, balance));
                amount -= balance;
            }

            for (int i = 0; i < creditCards.Length && amount > 0; i++)
            {
                CreditCard creditCard = creditCards[i];
                decimal left = creditCard.LimitLeft;
                creditCard.Withdraw(Math.Min(amount, left));
                amount -= left;
            }

            context.SaveChanges();
        }

        private static void ShowUserInfo(int userId, BillsPaymentSystemContext context)
        {
            User user = context.Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(m => m.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(m => m.CreditCard)
                .SingleOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            var bankAccounts = user.PaymentMethods
                .Where(x => x.Type == PaymentMethodType.BankAccount)
                .Select(x => x.BankAccount);

            var creditCards = user.PaymentMethods
                .Where(x => x.Type == PaymentMethodType.CreditCard)
                .Select(x => x.CreditCard);

            Console.WriteLine($"User: {user.FirstName} {user.LastName}");

            Console.WriteLine("Bank Accounts:");
            foreach (var bankAccount in bankAccounts)
            {
                Console.WriteLine($"-- ID: {bankAccount.BankAccountId}");
                Console.WriteLine($"--- Balance: {bankAccount.Balance}");
                Console.WriteLine($"--- Bank: {bankAccount.BankName}");
                Console.WriteLine($"--- SWIFT: {bankAccount.SwiftCode}");
            }

            Console.WriteLine("Credit Cards:");
            foreach (var creditCard in creditCards)
            {
                Console.WriteLine($"-- ID: {creditCard.CreditCardId}");
                Console.WriteLine($"--- Limit: {creditCard.Limit}");
                Console.WriteLine($"--- Money Owed: {creditCard.MoneyOwed}");
                Console.WriteLine($"--- Limit Left: {creditCard.LimitLeft}");
                Console.WriteLine($"--- Expiration Date: {creditCard.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
            }
        }

        private static void Seed(BillsPaymentSystemContext context)
        {
            var users = new[]
            {
                new User
                {
                    FirstName = "Anton",
                    LastName = "Apostolov",
                    Password = "p@ssw0rd",
                    Email = "a.apostolov@abv.bg"
                },
                new User
                {
                    FirstName = "Zornitsa",
                    LastName = "Orlova",
                    Password = "verysecurepassword",
                    Email = "zornitsa28193@outlook.com"
                },
                new User
                {
                    FirstName = "Kaloyan",
                    LastName = "Minchev",
                    Password = "letmein",
                    Email = "kaloyanisrich@protonmail.ch"
                }
            };

            var creditCards = new[]
            {
                new CreditCard
                (
                    600,
                    230.18m,
                    new DateTime(2019, 11, 30)
                ),
                new CreditCard
                (
                   900,
                    0,
                    new DateTime(2018, 10, 31)
                ),
                new CreditCard
                (
                    3200,
                    120.35m,
                    new DateTime(2020, 05, 31)
                ),
                new CreditCard
                (
                    50000,
                    0,
                    new DateTime(2029, 01, 31)
                )
            };

            var bankAccounts = new[]
            {
                new BankAccount
                (
                    301.18m,
                    "First Investment Bank",
                    "FINVBGSFXXX"
                ),
                new BankAccount
                (
                    540329.85m,
                    "Banque Cantonale De Geneve",
                    "BCGECHGGXXX"
                )
            };

            var paymentMethods = new[]
            {
                new PaymentMethod
                {
                    User = users[0],
                    Type = PaymentMethodType.CreditCard,
                    CreditCard = creditCards[0]
                },
                new PaymentMethod
                {
                    User = users[0],
                    Type = PaymentMethodType.BankAccount,
                    BankAccount = bankAccounts[0]
                },
                new PaymentMethod
                {
                    User = users[1],
                    Type = PaymentMethodType.CreditCard,
                    CreditCard = creditCards[1]
                },
                new PaymentMethod
                {
                    User = users[1],
                    Type = PaymentMethodType.CreditCard,
                    CreditCard = creditCards[2]
                },
                new PaymentMethod
                {
                    User = users[2],
                    Type = PaymentMethodType.BankAccount,
                    BankAccount = bankAccounts[1]
                },
                new PaymentMethod()
                {
                    User = users[2],
                    Type = PaymentMethodType.CreditCard,
                    CreditCard = creditCards[3]
                }
            };

            context.PaymentMethods.AddRange(paymentMethods);

            context.SaveChanges();
        }
    }
}
