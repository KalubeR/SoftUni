using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
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
                double fuel = double.Parse(input[1]);
                double fuelFor1km = double.Parse(input[2]);
                Car car = new Car(model, fuel, fuelFor1km);
                cars.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] inputArgs = input.Split();
                string carToDrive = inputArgs[1];
                double kmToTravel = double.Parse(inputArgs[2]);

                var currentCar = cars.Where(c => c.Model == carToDrive).FirstOrDefault();

                if (currentCar != null)
                {
                    currentCar.MoveCar(kmToTravel);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.KmTravelled}");
            }

        }
    }
}
