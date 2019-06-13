using Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => "<log>\n" +
                                "   <date>{0}</date>" + Environment.NewLine +
                                "   <level>{1}</level>\n" + Environment.NewLine +
                                "   <message>{2}</message>\n" + Environment.NewLine +
                                "</log>";
    }
}
