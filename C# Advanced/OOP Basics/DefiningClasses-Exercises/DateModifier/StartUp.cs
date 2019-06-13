using System;

namespace DateModifier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();   
            string date2 = Console.ReadLine();
            DateModifier dateModifier = new DateModifier();

            dateModifier.GetDifference(date1, date2);
            Console.WriteLine(dateModifier.DateDifference);
        }
    }
}
