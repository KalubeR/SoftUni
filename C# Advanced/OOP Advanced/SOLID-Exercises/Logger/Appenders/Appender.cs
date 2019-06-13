using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        protected ILayout Layout => this.layout;

        abstract public void Append(string dateTime, ReportLevel reportLevel, string errorMessage);

        
    }
}
