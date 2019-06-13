using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunbarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>();
            Stack<int> bullets = new Stack<int>();

            int counter = 0;

            foreach (var item in bulletsArr)
            {
                bullets.Push(item);
            }

            foreach (var item in locksArr)
            {
                locks.Enqueue(item);
            }

            while (true)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                //bullets.Pop(); i tova e vqrno
                counter++;

                if (currentLock >= currentBullet)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }

                else
                {
                    Console.WriteLine("Ping!");
                }

                if (counter == gunbarrelSize && bullets.Count != 0)
                {
                    counter = 0;
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (bulletsArr.Count() - bullets.Count) * bulletPrice}");
                    break;
                }

                else if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }

            }
        }
    }
}
