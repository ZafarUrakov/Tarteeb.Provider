//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System.Collections.Generic;
using System.Threading.Tasks;
using Tarteeb.Provider.Models.Applicant;
using Tarteeb.Provider.Services.Foundations.ApplicantService;

namespace Tarteeb.Provider.Services.Processings.ImporterProcessingService
{
    internal class ApplicantProcessningService
    {
        private readonly ApplicantService applicantService;

        public ApplicantProcessningService()
        {
            this.applicantService = new ApplicantService();
        }

        public async Task<List<Applicant>> ConvertAndAddApplicantAsync(List<Applicant> applicants)
        {
            foreach (var item in applicants)
            {
                await this.applicantService.AddApplicantAsync(item);
            }
            return applicants;
        }
    }
}
