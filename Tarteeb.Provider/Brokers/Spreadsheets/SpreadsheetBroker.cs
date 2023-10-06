//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using Bytescout.Spreadsheet;
using System;
using System.Collections.Generic;
using Tarteeb.Provider.Models.Applicant;

namespace Tarteeb.Provider.Brokers.Spreadsheets
{
    public class SpreadsheetBroker : ISpreadsheetBroker
    {
        public List<Applicant> applicants = new List<Applicant>();

        public List<Applicant> ImportApplicantToList(string filePath)
        {
            Spreadsheet document = new Spreadsheet();

            document.LoadFromFile(filePath);

            Worksheet worksheet = document.Workbook.Worksheets[0];

            for (int row = 1; row <= worksheet.UsedRangeRowMax; row++)
            {
                Applicant applicant = new Applicant();

                string applicantIdString = worksheet.Cell(row, 0).ToString();
                if (Guid.TryParse(applicantIdString, out Guid applicantId))
                {
                    // Преобразование успешно, присваиваем значение applicantId
                    applicant.ApplicantId = applicantId;
                }
                applicant.Firstname = worksheet.Cell(row, 1).ToString();
                applicant.Lastname = worksheet.Cell(row, 2).ToString();
                applicant.PhoneNumber = worksheet.Cell(row, 3).ToString();
                applicant.Email = worksheet.Cell(row, 4).ToString();
                applicant.Groupname = worksheet.Cell(row, 5).ToString();

                applicants.Add(applicant);
            }

            document.Close();

            return applicants;
        }
    }
}
