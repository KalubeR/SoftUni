using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                List<Tire> tires = new List<Tire>();

                for (int j = 0; j < 4; j+= 2)
                {
                    double tirePressure = double.Parse(input[5 + j]);
                    int tireAge = int.Parse(input[6 + j]);
                    Tire tire = new Tire(tirePressure, tireAge);
                    tires.Add(tire);
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var carsFragile = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1)).ToList();
                foreach (Car car in carsFragile)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                var carsFlamable = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
                foreach (var car in carsFlamable)
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}
