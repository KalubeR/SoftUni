using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse()
        {
            return "Browsing: ";
        }

        public string Call()
        {
            return "Calling... ";
        }
    }
}
