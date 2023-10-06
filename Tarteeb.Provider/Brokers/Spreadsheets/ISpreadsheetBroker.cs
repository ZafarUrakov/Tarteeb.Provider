//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System.Collections.Generic;
using Tarteeb.Provider.Models.Applicant;

namespace Tarteeb.Provider.Brokers.Spreadsheets
{
    public interface ISpreadsheetBroker
    {
        List<Applicant> ImportApplicantToList(string filePath);
    }
}
