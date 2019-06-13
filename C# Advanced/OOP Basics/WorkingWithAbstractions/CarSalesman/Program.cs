using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);

                Engine engine = new Engine(model, power);

                if (input.Length == 4)
                {
                    string displacement = input[2];
                    string efficiency = input[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                else if (input.Length == 3)
                {
                    bool trparse = int.TryParse(input[2], out int result);
                    if (trparse)
                    {
                        string displacement = input[2];
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = input[2];
                        engine.Efficiency = efficiency;
                    }
                }
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engineToFind = input[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineToFind);

                Car car = new Car(model, engine);
                if (input.Length == 4)
                {
                    string weight = input[2];
                    string color = input[3];
                    car.Weight = weight;
                    car.Color = color;
                }
                else if (input.Length == 3)
                {
                    bool tryParse = int.TryParse(input[2], out int result);
                    if (tryParse)
                    {
                        string weight = input[2];
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = input[2];
                        car.Color = color;
                    }
                }
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                //FordFocus:
                //V4 - 33:
                //Power: 140
                //Displacement: 28
                //Efficiency: B
                //Weight: 1300
                //Color: Silver

                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
