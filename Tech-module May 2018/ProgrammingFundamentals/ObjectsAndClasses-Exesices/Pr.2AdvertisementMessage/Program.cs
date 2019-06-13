using System;

namespace Pr._2AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random phraseIndex = new Random();
            Random eventIndex = new Random();
            Random authorIndex = new Random();
            Random cityIndex = new Random();

            int randomPhrase = phraseIndex.Next(0, phrases.Length);
            int randomEvent = phraseIndex.Next(0, events.Length);
            int randomAuthor = phraseIndex.Next(0, authors.Length);
            int randomCity = phraseIndex.Next(0, cities.Length);

            Console.WriteLine($"{phrases[randomPhrase]} {events[randomEvent]} {authors[randomAuthor]} – {cities[randomCity]}");
        }
    }
}
