using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> products;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception ex = new ArgumentException("Name cannot be empty");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                name = value;
            }
        }


        public int Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    Exception ex = new ArgumentException("Money cannot be negative");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                money = value;
            }
        }


        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public override string ToString()
        {
            if (products.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            else
            {
                return $"{Name} - {string.Join(", ", products.Select(x => x.ToString()))}";
            }
        }
    }
}
