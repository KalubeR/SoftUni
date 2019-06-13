using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models.Enums;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class UserDetailsCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserDetailsCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            var user = this.context.Users
                .Where(x => x.UserId == userId)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    BankAccounts = x.PaymentMethods.Where(y => y.Type == PaymentType.BankAccount)
                        .Select(b => b.BankAccount).ToList(),
                    CreditCards = x.PaymentMethods
                        .Where(a => a.Type == PaymentType.CreditCard)
                        .Select(n => n.CreditCard).ToList()
                }).FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentNullException("User not found!");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"User: {user.FirstName} {user.LastName}");

            if (user.BankAccounts.Any())
            {
                Console.WriteLine("Bank Accounts:");
                foreach (var item in user.BankAccounts)
                {
                    sb.AppendLine($"-- ID: {item.BankAccountId}");
                    sb.AppendLine($"--- Balance: {item.Balance:f2}");
                    sb.AppendLine($"--- Bank: {item.BankName}");
                    sb.AppendLine($"--- SWIFT: {item.SWIFTCode}");
                }
            }

            if (user.CreditCards.Any())
            {
                Console.WriteLine("Credit Cards:");
                foreach (var item in user.CreditCards)
                {
                    sb.AppendLine($"-- ID: {item.CreditCardId}");
                    sb.AppendLine($"--- Limit: {item.Limit:f2}");
                    sb.AppendLine($"--- Money Owed: {item.MoneyOwed:f2}");
                    sb.AppendLine($"--- Limit Left: {item.LimitLeft}");
                    sb.AppendLine($"--- Expiration Date: {item.ExpirationDate.ToString(@"yyyy/MM", CultureInfo.InvariantCulture)}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}