using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using Tarteeb.Provider.Models.Applicant;
using Tarteeb.Provider.Models.Exceptions;
using Tarteeb.Provider.Services.Foundatons.ImporterService;

namespace Tarteeb.Provider.Services.Processings.ImporterProcessingService
{
    internal class ImporterProcessingService
    {

        InvalidApplicantException invalidApplicantException = new InvalidApplicantException();
        ImporterService importerService = new ImporterService();

        public List<Applicant> ValidateInvalidApplicants(string filePath)
        {
            var notNullApplicants = this.importerService.ValidateApplicantsAndFilter(filePath);
            var validApplicants = new List<Applicant>();
            foreach (var applicant in notNullApplicants)
            {

                try
                {
                    Validate(
                        (Rule: IsInvalid(applicant.ApplicantId), Parameter: nameof(Applicant.ApplicantId)),
                        (Rule: IsInvalid(applicant.Firstname), Parameter: nameof(Applicant.Firstname)),
                        (Rule: IsInvalid(applicant.Lastname), Parameter: nameof(Applicant.Lastname)),
                        (Rule: IsInvalid(applicant.Email), Parameter: nameof(Applicant.Email)),
                        (Rule: IsInvalid(applicant.PhoneNumber), Parameter: nameof(Applicant.PhoneNumber)),
                        (Rule: IsInvalid(applicant.BirthDate), Parameter: nameof(Applicant.BirthDate)),
                        (Rule: IsInvalid(applicant.Groupname), Parameter: nameof(Applicant.Groupname)),
                        (Rule: IsInvalid(applicant.GroupId), Parameter: nameof(Applicant.GroupId)));

                    if (invalidApplicantException.Data.Count == 0)
                    {
                        Console.WriteLine($"{applicant.Firstname} is Validated");

                        validApplicants.Add(applicant);
                    }
                }
                catch(InvalidApplicantException ex)
                {
                    Console.WriteLine(ex.Message);
                    invalidApplicantException.Data.Clear();
                    continue;
                }
            }

            return validApplicants;
        }

        private dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidApplicantException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidApplicantException.ThrowIfContainsErrors();
        }
    }
}
