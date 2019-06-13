﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);

        void Info(string dateTime, string infoMessage);

        void Fatal(string dateTime, string infoMessage);

        void Critical(string dateTime, string infoMessage);
    }
}
