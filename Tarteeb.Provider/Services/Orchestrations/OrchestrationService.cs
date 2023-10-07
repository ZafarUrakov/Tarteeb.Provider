//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System;
using System.Collections.Generic;
using Tarteeb.Provider.Models.Applicant;
using Tarteeb.Provider.Services.Processings.ImporterProcessingService;

namespace Tarteeb.Provider.Services.Orchestrations
{
    internal class OrchestrationService
    {
        private readonly ImporterProcessingService importerProcessingService;
        public List<Applicant> readyApplicants { get; private set; } = new List<Applicant>();

        public List<Applicant> ProcessImport(string filePath)
        {
            try
            {
                List<Applicant> validApplicants = importerProcessingService.ValidateInvalidApplicants(filePath);

                readyApplicants.AddRange(validApplicants);

                foreach (var item in validApplicants)
                {
                    Console.WriteLine(item.Firstname + " " + item.Lastname);
                }

                Console.WriteLine("Import and validation successful.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($" Error: {exception.Message}");
            }

            return readyApplicants;
        }
    }
}
