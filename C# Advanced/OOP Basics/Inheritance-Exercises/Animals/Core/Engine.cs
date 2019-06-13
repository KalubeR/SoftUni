using Animals.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Core
{
    public class Engine
    {
        private AnimalFactory animalFactory;
        private List<Animal> animals;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Beast!")
                {
                    break;
                }

                try
                {
                    string type = input;
                    string[] data = Console.ReadLine().Split();

                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];

                    Animal animal = animalFactory.CreateAnimal(type, name, age, gender);
                    animals.Add(animal);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Print();
        }

        private void Print()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                animal.ProduceSound();
            }
        }
    }
}
