//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System;
using System.Collections.Generic;
using Tarteeb.Provider.Brokers.Spreadsheets;
using Tarteeb.Provider.Models.Applicant;
using Tarteeb.Provider.Services.Foundatons.ImporterService;
using Tarteeb.Provider.Services.Processings.ImporterProcessingService;

namespace Tarteeb.Provider.Services.Orchestrations
{
    internal class OrchestrationService
    {
        private readonly SpreadsheetBroker spreadsheetBroker;
        private readonly ImporterProcessingService importerProcessingService;
        public List<Applicant> ReadyApplicants { get; private set; } = new List<Applicant>();

        public OrchestrationService(
            SpreadsheetBroker spreadsheetBroker,
            ImporterProcessingService importerProcessingService)
        {
            this.spreadsheetBroker = spreadsheetBroker;
            this.importerProcessingService = importerProcessingService;
        }

        public void ProcessImport(string filePath)
        {
            try
            {
                List<Applicant> applicants = spreadsheetBroker.ImportApplicantToList(filePath);

                List<Applicant> validApplicants = importerProcessingService.ValidateInvalidApplicants(applicants);

                ReadyApplicants.AddRange(validApplicants);

                foreach(var item in validApplicants)
                {
                    Console.WriteLine(item.Firstname + " " + item.Lastname);
                }

                Console.WriteLine("Import and validation successful.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($" Error: {exception.Message}");
            }
        }
    }
}
