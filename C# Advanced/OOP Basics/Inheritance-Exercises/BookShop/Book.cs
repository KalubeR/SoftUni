using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                string[] input = value.Split();
                if (input.Length == 2)
                {
                    string secondName = input[1];
                    if (char.IsDigit(secondName[0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                
                author = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
