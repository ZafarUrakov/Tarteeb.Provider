//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System;
using System.Collections.Generic;
using Tarteeb.Provider.Brokers.Spreadsheets;
using Tarteeb.Provider.Models.Applicant;
using Tarteeb.Provider.Services.Foundatons.ImporterService;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\icom\Desktop\.net.xlsx"; 

        SpreadsheetBroker spreadsheetBroker = new SpreadsheetBroker();

        List<Applicant> importedApplicants = spreadsheetBroker.ImportApplicantToList(filePath);

        ImporterService importerService = new ImporterService();
        List<Applicant> processedApplicants = importerService.ValidateApplicantNotNull(importedApplicants);

        foreach (var applicant in processedApplicants)
        {
            Console.WriteLine($"Firstname: {applicant.Firstname} , LastName: {applicant.Lastname}, " +
                $"PhoneNumber: {applicant.PhoneNumber}, Email: {applicant.Email} Groupname: {applicant.Groupname}");
        }
    }
}
