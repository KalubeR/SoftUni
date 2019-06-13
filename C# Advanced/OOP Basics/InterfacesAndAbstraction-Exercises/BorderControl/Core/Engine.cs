using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifiable> creatures;

        public Engine()
        {
            this.creatures = new List<IIdentifiable>();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] inputArgs = input.Split();
                if (inputArgs.Contains("Citizen"))
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthdate = inputArgs[4];

                    IIdentifiable citizen = new Citizen(name, age, id, birthdate);
                    creatures.Add(citizen);
                }
                else if (inputArgs.Contains("Pet"))
                {
                    string name = inputArgs[1];
                    string birthdate = inputArgs[2];

                    Pet pet = new Pet(name, birthdate);
                    creatures.Add(pet);
                }
                else
                {
                    string model = inputArgs[0];
                    string id = inputArgs[1];

                    Robot robot = new Robot(model, id, "0/0/0");
                    creatures.Add(robot);
                }
            }

            string year = Console.ReadLine();

            creatures = creatures.Where(x => x.Birthdate.Contains(year)).ToList();

            foreach (var item in creatures)
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}
