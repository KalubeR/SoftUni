using Logger.Layouts.Contracts;
using Logger.Loggers.Enums;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string errorMessage)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, errorMessage));
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}";
        }
    }
}
