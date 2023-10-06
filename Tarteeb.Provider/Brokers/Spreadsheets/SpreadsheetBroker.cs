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

                applicant.Firstname = worksheet.Cell(row, 0).ToString();
                applicant.Groupname = worksheet.Cell(row, 1).ToString();

                Console.WriteLine(applicant.Firstname + " " + applicant.Groupname);

                applicants.Add(applicant);
            }

            document.Close();

            return applicants;
        }
    }
}
