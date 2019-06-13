using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingName;

        private double weight;

        public Topping(string toppingName, double weight)
        {
            this.ToppingName = toppingName;
            this.Weight = weight;
        }

        public string ToppingName
        {
            get { return toppingName; }
            set
            {
                if (value.ToLower() != "meat" && 
                    value.ToLower() != "veggies" && 
                    value.ToLower() != "cheese" && 
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingName = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    string type = Char.ToUpper(this.ToppingName[0]) + this.ToppingName.Substring(1);
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }


        public double ToppingCalories { get => this.CalculateCaloriesFromTopping(); }

        private double CalculateCaloriesFromTopping()
        {
            double multiplier = 0.0;
            switch (ToppingName)
            {
                case "Meat":
                    multiplier = 1.2;
                    break;
                case "Veggies":
                    multiplier = 0.8;
                    break;
                case "Cheese":
                    multiplier = 1.1;
                    break;
                case "Sauce":
                    multiplier = 0.9;
                    break;
            }
            return this.Weight * 2 * multiplier;
        }
    }
}
