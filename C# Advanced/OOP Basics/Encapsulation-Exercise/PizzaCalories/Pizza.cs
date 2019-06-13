using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        private Dough dough;

        private List<Topping> toppings;

        public double Calories { get => GetTotalCalories();}

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            set
            {
                toppings = value;
            }
        }

        public void Add(Topping topping)
        {
            this.Toppings.Add(topping);
        }

        private double GetTotalCalories()
        {
            double toppingCalories = this.Toppings.Sum(x => x.ToppingCalories);
            double doughCalories = this.Dough.DoughCalories;
            return doughCalories + toppingCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():f2} Calories.";
        }
    }
}
