using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class ComparerForAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Age.CompareTo(y.Age);

            return result;
        }
    }
}
