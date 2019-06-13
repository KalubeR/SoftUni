using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class ComparerForName : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);

            if (result == 0)
            {
                char firstChar = Char.ToLower(x.Name[0]);
                char secondChar = Char.ToLower(y.Name[0]);

                result = firstChar.CompareTo(secondChar);
            }

            return result;
        }
    }
}
