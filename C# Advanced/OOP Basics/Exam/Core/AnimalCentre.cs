using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = null;
            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
                default:
                    break;
            }

            hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        private void CheckIfAnimalExists(string name)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }
        Chip chip = new Chip();

        public string Chip(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
          
            IAnimal animal = GetAnimal(name);
            chip.DoService(animal, procedureTime);
            chip.ProcedureHistory.Add(animal);

            return $"{animal.Name} had chip procedure";
        }

        Vaccinate vaccinate = new Vaccinate();

        public string Vaccinate(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = GetAnimal(name);
            vaccinate.DoService(animal, procedureTime);
            vaccinate.ProcedureHistory.Add(animal);

            return $"{animal.Name} had vaccination procedure";
        }
        Fitness fitness = new Fitness();

        public string Fitness(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = GetAnimal(name);
            fitness.DoService(animal, procedureTime);
            fitness.ProcedureHistory.Add(animal);

            return $"{animal.Name} had fitness procedure";
        }
        Play play = new Play();

        public string Play(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = GetAnimal(name);
            play.DoService(animal, procedureTime);
            play.ProcedureHistory.Add(animal);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }
        DentalCare dentalCare = new DentalCare();

        public string DentalCare(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = GetAnimal(name);
            dentalCare.DoService(animal, procedureTime);
            dentalCare.ProcedureHistory.Add(animal);

            return $"{animal.Name} had dental care procedure";
        }
        NailTrim nailTrim = new NailTrim();

        public string NailTrim(string name, int procedureTime)
        {
            CheckIfAnimalExists(name);
            IAnimal animal = GetAnimal(name);
            nailTrim.DoService(animal, procedureTime);
            nailTrim.ProcedureHistory.Add(animal);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            CheckIfAnimalExists(animalName);
            IAnimal animal = GetAnimal(animalName);
            hotel.Adopt(animalName, owner);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            switch (type)
            {
                case "Chip":
                    return chip.History();

                case "DentalCare":
                    return dentalCare.History();

                case "Fitness":
                    return fitness.History();

                case "NailTrim":
                    return nailTrim.History();

                case "Play":
                    return play.History();

                case "Vaccinate":
                    return vaccinate.History();


                default:
                    return "";
            }
        }



        private IAnimal GetAnimal(string name)
        {
            IAnimal animal = null;

            foreach (var item in hotel.Animals)
            {
                if (item.Key == name)
                {
                    animal = item.Value;
                }
            }

            return animal;
        }
    }
}
