using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuel;
        private double fuelFor1km;
        private int kmTravelled;

        public Car(string model, double fuel, double fuelFor1km)
        {
            this.Model = model;
            this.Fuel = fuel;
            this.FuelFor1km = fuelFor1km;
            this.KmTravelled = 0;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public double FuelFor1km
        {
            get { return fuelFor1km; }
            set { fuelFor1km = value; }
        }

        public int KmTravelled
        {
            get { return kmTravelled; }
            set { kmTravelled = value; }
        }

        public void MoveCar(double kmToTravel)
        {
            if (kmToTravel * this.FuelFor1km <= this.Fuel)
            {
                this.Fuel -= kmToTravel * this.FuelFor1km;
                this.KmTravelled += (int)kmToTravel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
