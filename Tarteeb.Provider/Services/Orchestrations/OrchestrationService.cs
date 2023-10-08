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
        ApplicantProcessningService applicantProcessningService = new ApplicantProcessningService();

        List<Applicant> readyApplicants = new List<Applicant>();
        List<Applicant> fullAplicants = new List<Applicant>();

        public async void ProcessImport(string filePath)
        {
            List<Applicant> validApplicants = importerProcessingService.ValidateInvalidApplicants(filePath);

            readyApplicants.AddRange(validApplicants);

            fullAplicants = await groupProcessingService.AllApplicants(readyApplicants);

            var persistedApplicants = await applicantProcessningService.ConvertAndAddApplicantAsync(fullAplicants);

            Console.WriteLine(persistedApplicants);
        }
    }
}
