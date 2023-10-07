//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System.Collections.Generic;
using Tarteeb.Provider.Brokers.Exceptions;
using Tarteeb.Provider.Brokers.Spreadsheets;
using Tarteeb.Provider.Models.Applicant;

namespace Tarteeb.Provider.Services.Foundatons.ImporterService
{
    internal class ImporterService
    {
        private readonly SpreadsheetBroker spreadSheetBroker;

        public ImporterService(SpreadsheetBroker spreadSheetBroker)
        {
            this.spreadSheetBroker = spreadSheetBroker;
        }

        internal List<Applicant> ValidateApplicantNotNull(string filePath)
        {
            var applicants = this.spreadSheetBroker.ImportApplicantToList(filePath);
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
