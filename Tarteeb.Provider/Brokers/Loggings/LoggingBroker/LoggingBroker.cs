//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System;

namespace Tarteeb.Provider.Brokers.Loggings.LoggingBroker
{
    internal class LoggingBroker
    {
        public void LogError(Exception exception) =>
            Console.WriteLine(exception.Message);
    }
}
