//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using Tarteeb.Provider.Services.Orchestrations;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\icom\Desktop\.net.xlsx";

        OrchestrationService orchestrationService = new OrchestrationService();

        orchestrationService.ProcessImport(filePath);
    }
}
