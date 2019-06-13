using System;

namespace Pr._19TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPictures = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int goodPicturesPercentage = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            double goodPictures = Math.Ceiling((goodPicturesPercentage / 100d) * totalPictures);
            double allFilteredPictures = totalPictures * filterTime;
            double uploadedPictures = goodPictures * uploadTime;

            double totalTime = allFilteredPictures + uploadedPictures;

            TimeSpan t = TimeSpan.FromSeconds(totalTime);
            string printTime = string.Format($"{t.Days}:{t.Hours:d2}:{t.Minutes:d2}:{t.Seconds:d2}");
            Console.WriteLine(printTime);
        }
    }
}
