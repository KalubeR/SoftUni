using System;
using System.Collections.Generic;
using System.Text;

namespace Mordor_sCruelPlan.Foods
{
    public class Melon : Food
    {
        private const int happiness = 1;

        public Melon() 
            : base(happiness)
        {
        }
    }
}
