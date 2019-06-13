using System;
using System.ComponentModel.DataAnnotations;
using BillsPaymentSystem.Models.Attributes;

namespace BillsPaymentSystem.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Limit { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft
            => this.Limit - this.MoneyOwed;

        [ExpirationDate]
        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal money)
        {
            if (money > Limit)
            {
                throw new ArgumentException("Insufficient funds!");
            }
            this.MoneyOwed += money;
        }

        public void Deposit(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Value cannot be negative!");
            }
            this.MoneyOwed -= money;
        }
    }
}