using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCentre;
        private Dictionary<string, List<string>> adoptedAnimals;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
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

                string[] args = input.Split();
                string command = args[0];

                string result = string.Empty;
                try
                {
                    switch (command)
                    {

                        case "RegisterAnimal":
                            string type = args[1];
                            string name = args[2];
                            int energy = int.Parse(args[3]);
                            int happiness = int.Parse(args[4]);
                            int procedureTime = int.Parse(args[5]);
                            result = animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                            break;
                        case "Chip":
                            string namechip = args[1];
                            int procedureTimeChip = int.Parse(args[2]);
                            result = animalCentre.Chip(namechip, procedureTimeChip);
                            break;
                        case "Vaccinate":
                            string nameVaccinate = args[1];
                            int procedureTimeVaccinate = int.Parse(args[2]);
                            result = animalCentre.Vaccinate(nameVaccinate, procedureTimeVaccinate);
                            break;
                        case "Fitness":
                            string nameFitness = args[1];
                            int procedureTimeFitness = int.Parse(args[2]);
                            result = animalCentre.Fitness(nameFitness, procedureTimeFitness);
                            break;
                        case "Play":
                            string namePlay = args[1];
                            int procedureTimePlay = int.Parse(args[2]);
                            result = animalCentre.Play(namePlay, procedureTimePlay);
                            break;
                        case "DentalCare":
                            string nameDentalCare = args[1];
                            int procedureTimeDentalCare = int.Parse(args[2]);
                            result = animalCentre.DentalCare(nameDentalCare, procedureTimeDentalCare);
                            break;
                        case "NailTrim":
                            string nameNailTrim = args[1];
                            int procedureTimeNailTrim = int.Parse(args[2]);
                            result = animalCentre.NailTrim(nameNailTrim, procedureTimeNailTrim);
                            break;

                        case "Adopt":
                            string animalName = args[1];
                            string owner = args[2];
                            result = animalCentre.Adopt(animalName, owner);
                            if (!adoptedAnimals.ContainsKey(owner))
                            {
                                adoptedAnimals.Add(owner, new List<string>());
                                adoptedAnimals[owner].Add(animalName);
                            }
                            else
                            {
                                adoptedAnimals[owner].Add(animalName);
                            }
                            break;
                        case "History":
                            string procedureType = args[1];
                            result = animalCentre.History(procedureType);
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);

                }
                catch (InvalidOperationException x)
                {
                    Console.WriteLine("InvalidOperationException: " + x.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("ArgumentException: " + ae.Message);
                }

            }

            foreach (var item in adoptedAnimals.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"--Owner: {item.Key}");

                Console.WriteLine($"    - Adopted animals: {string.Join(" ", item.Value)}");

            }
        }
    }
}
