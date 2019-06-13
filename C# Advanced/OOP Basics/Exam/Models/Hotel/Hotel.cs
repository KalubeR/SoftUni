using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private const int defaultCapacity = 0;

        private int capacity;

        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.Capacity = defaultCapacity;

            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get { return animals; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.Capacity == 10)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }


            this.animals.Add(animal.Name, animal);
            this.Capacity++;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = null;

            foreach (var item in this.animals)
            {
                if (item.Key == animalName)
                {
                    animal = item.Value;
                }
            }

            animal.Owner = owner;
            animal.IsAdopt = true;
            this.animals.Remove(animalName);
        }
    }
}
