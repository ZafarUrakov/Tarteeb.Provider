//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System.Collections.Generic;
using Tarteeb.Provider.Brokers.Exceptions;
using Tarteeb.Provider.Models.Applicant;
using Tarteeb.Provider.Services.Foundations.ImporterService;

namespace Tarteeb.Provider.Services.Foundatons.ImporterService
{
    internal class ImporterService : IImporterService
    {
        internal List<Applicant> ValidateApplicantNotNull(List<Applicant> applicants)
        {
            List<Applicant> filteredApplicants = new List<Applicant>();

            foreach (var applicant in applicants)
            {
                if (applicant != null)
                {
                    filteredApplicants.Add(applicant);
                }
                else
                {
                    throw new NullApplicantException();
                }
            }

            return filteredApplicants;
        }
    }
}
