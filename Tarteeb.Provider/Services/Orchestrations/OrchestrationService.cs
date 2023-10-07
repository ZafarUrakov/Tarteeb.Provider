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
        ImporterProcessingService importerProcessingService = new ImporterProcessingService();
        GroupProcessingService groupProcessingService = new GroupProcessingService();
        

        List<Applicant> readyApplicants = new List<Applicant>();
        List<Applicant> fullAplicants = new List<Applicant>();


        public List<Applicant> ProcessImport(string filePath)
        {
            try
            {
                List<Applicant> validApplicants = importerProcessingService.ValidateInvalidApplicants(filePath);

                readyApplicants.AddRange(validApplicants);

                var fullAplicants = groupProcessingService.AllApplicants(readyApplicants);
            }
            catch (Exception exception)
            {
                Console.WriteLine($" Error: {exception.Message}");
            }

            return readyApplicants;
        }
    }
}
