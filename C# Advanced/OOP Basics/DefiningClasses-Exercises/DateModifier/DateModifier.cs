using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public int DateDifference { get; set; }

        public void GetDifference(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);
            int dateDifference = (int)Math.Abs((dateOne - dateTwo).TotalDays);
            this.DateDifference = dateDifference;
        }
    }
}
