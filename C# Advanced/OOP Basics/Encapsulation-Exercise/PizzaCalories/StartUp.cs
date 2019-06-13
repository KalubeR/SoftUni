using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                string[] name = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string pizzaName = name[1];
                Pizza pizza = new Pizza(pizzaName);
                string[] doughArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string flourType = doughArgs[1];
                string bakingTechnique = doughArgs[2];
                double doughWeight = double.Parse(doughArgs[3]);
                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                pizza.Dough = dough;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    string[] inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string toppingName = inputArgs[1];
                    double toppingWeight = double.Parse(inputArgs[2]);
                    Topping topping = new Topping(toppingName, toppingWeight);
                    pizza.Add(topping);

                }
                if (pizza.Toppings.Count > 10)
                {
                    Console.WriteLine("Number of toppings should be in range [0..10].");
                    return;
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
