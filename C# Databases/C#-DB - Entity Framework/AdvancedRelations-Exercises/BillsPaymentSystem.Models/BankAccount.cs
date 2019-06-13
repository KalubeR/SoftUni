using System;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string BankName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string SWIFTCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal money)
        {
            if (money > Balance)
            {
                throw new ArgumentException("Insufficient funds!");
            }
            this.Balance -= money;
        }

        public void Deposit(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Value cannot be negative !");
            }
            this.Balance += money;
        }
    }
}