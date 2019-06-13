using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputPersons = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (var item in inputPersons)
            {
                string[] personArgs = item.Split("=");
                string personName = personArgs[0];
                int personMoney = int.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);
                persons.Add(person);
            }

            foreach (var item in inputProducts)
            {
                string[] productArgs = item.Split("=");
                string productName = productArgs[0];
                int productCost = int.Parse(productArgs[1]);

                Product product = new Product(productName, productCost);
                products.Add(product);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string person = tokens[0];
                string product = tokens[1];

                Person personToFind = persons.First(x => x.Name == person);
                Product productToFind = products.First(x => x.Name == product);

                if (productToFind.Cost > personToFind.Money)
                {
                    Console.WriteLine($"{personToFind.Name} can't afford {productToFind.Name}");
                }
                else
                {
                    Console.WriteLine($"{personToFind.Name} bought {productToFind.Name}");
                    personToFind.Products.Add(productToFind);
                    personToFind.Money -= productToFind.Cost;
                }
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
