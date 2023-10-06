//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System;
using System.Collections.Generic;
using Tarteeb.Provider.Brokers.Spreadsheets;
using Tarteeb.Provider.Models.Applicant;
using Tarteeb.Provider.Services.Foundatons.ImporterService;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\icom\Desktop\.net.xlsx"; // Замените на путь к вашему файлу

        // Создаем объект SpreadsheetBroker
        SpreadsheetBroker spreadsheetBroker = new SpreadsheetBroker();

        // Импортируем список заявителей
        List<Applicant> importedApplicants = spreadsheetBroker.ImportApplicantToList(filePath);

        // Создаем объект ApplicantProcessor

        ImporterService importerService = new ImporterService();
        // Фильтруем и сортируем заявителей
        List<Applicant> processedApplicants = importerService.ValidateApplicantNotNull(importedApplicants);

        // Выводим данные заявителей на консоль
        foreach (var applicant in processedApplicants)
        {
            Console.WriteLine($"Firstname: {applicant.Firstname} , LastName: {applicant.Lastname}, " +
                $"PhoneNumber: {applicant.PhoneNumber}, Email: {applicant.Email} Groupname: {applicant.Groupname}");
        }
    }
}
