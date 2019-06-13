using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<Rectangle> rectangles = new List<Rectangle>();

            int rectanglesCount = input[0];
            int checks = input[1];

            for (int i = 0; i < rectanglesCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string id = inputArgs[0];
                int width = int.Parse(inputArgs[1]);
                int height = int.Parse(inputArgs[2]);
                double x = double.Parse(inputArgs[3]);
                double y = double.Parse(inputArgs[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (int j = 0; j < checks; j++)
            {
                string[] pairOfIds = Console.ReadLine().Split();

                string firstId = pairOfIds[0];
                string secondId = pairOfIds[1];

                Rectangle firstRectangle = rectangles.FirstOrDefault(x => x.Id == firstId);
                Rectangle secondRectangle = rectangles.FirstOrDefault(x => x.Id == secondId);

                if (firstRectangle.Intersect(secondRectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
