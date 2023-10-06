//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System.Collections.Generic;
using Tarteeb.Provider.Brokers.Spreadsheets;
using Tarteeb.Provider.Models.Applicant;

namespace Tarteeb.Provider.Services.Foundatons.ImporterService
{
    internal class ImporterService
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
                
                }
            }

            return filteredApplicants;
        }
    }
}
