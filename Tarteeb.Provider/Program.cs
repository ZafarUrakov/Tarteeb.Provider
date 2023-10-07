//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System;
using Tarteeb.Provider.Services.Orchestrations;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\icom\Desktop\.net.xlsx";

        OrchestrationService orchestrationService = new OrchestrationService();

        var processedApplicants = orchestrationService.ProcessImport(filePath);

        foreach (var applicant in processedApplicants)
        {
            Console.WriteLine($"Firstname: {applicant.Firstname} , LastName: {applicant.Lastname}, " +
                $"PhoneNumber: {applicant.PhoneNumber}, Email: {applicant.Email} Groupname: {applicant.Groupname}");
        }
    }
}
