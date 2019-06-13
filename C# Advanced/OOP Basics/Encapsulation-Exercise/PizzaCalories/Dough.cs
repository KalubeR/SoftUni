using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;

        private string bakingTechnique;

        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(" Dough weight should be in the range[1..200]");
                }
                weight = value;
            }
        }

        public double DoughCalories { get => this.GetDoughCalories();}

        public double GetDoughCalories()
        {
            double multiplier1 = 0.0;
            double multiplier2 = 0.0;

            switch (this.FlourType.ToLower())
            {
                case "white":
                    multiplier1 = 1.5;
                    break;
                case "wholegrain":
                    multiplier1 = 1.0;
                    break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    multiplier2 = 0.9;
                    break;
                case "chewy":
                    multiplier2 = 1.1;
                    break;
                case "homemade":
                    multiplier2 = 1.0;
                    break;
                default:
                    break;
            }

            double doughCalories = 2 * this.Weight * multiplier1 * multiplier2;
            return doughCalories;
        }
    }
}
