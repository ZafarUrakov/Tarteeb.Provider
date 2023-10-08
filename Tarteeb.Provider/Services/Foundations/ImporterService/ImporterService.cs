﻿//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System.Collections.Generic;
using Bytescout.Spreadsheet;
using System.Reflection.Metadata;
using Tarteeb.Provider.Brokers.Exceptions;
using Tarteeb.Provider.Brokers.Spreadsheets;
using Tarteeb.Provider.Models.Applicant;
using System;

namespace Tarteeb.Provider.Services.Foundatons.ImporterService
{
    internal class ImporterService
    {
        SpreadsheetBroker spreadsheetBroker = new SpreadsheetBroker();

        internal List<Applicant> ValidateApplicantsAndFilter(string filePath)
        {
            List<Applicant> filteredApplicants = new List<Applicant>();

            Spreadsheet document = new Spreadsheet();

            document.LoadFromFile(filePath);

            Worksheet worksheet = document.Workbook.Worksheets[0];

            for (int row = 1; row <= worksheet.UsedRangeRowMax; row++)
            {
                var applicant = spreadsheetBroker.ImportApplicantToList(filePath, row);

                try
                {
                    var notNullApplicant = ValidateAndThrowIfNull(applicant);
                    filteredApplicants.Add(notNullApplicant);
                }
                catch (NullApplicantException exeption)
                {
                    Console.WriteLine($"Null Applicant Exception: {exeption.Message}");

                    continue;
                }
            }
            return filteredApplicants;
        }

        private Applicant ValidateAndThrowIfNull(Applicant applicant)
        {
            if (applicant != null)
            {
                return applicant;
            }
            else
            {
                throw new NullApplicantException();
            }
        }

    }
}
