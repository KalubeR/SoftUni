using System;

namespace Pr._7CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while (true)
            {
                string ingredient = Console.ReadLine();
                if (ingredient == "Bake!")
                {
                    Console.WriteLine($"Preparing cake with {counter} ingredients.");
                    break;
                }
                Console.WriteLine($"Adding ingredient {ingredient}.");
                counter++;
            }
        }
    }
}
