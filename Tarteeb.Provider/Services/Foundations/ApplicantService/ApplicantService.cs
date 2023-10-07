//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System.Threading.Tasks;
using Tarteeb.Provider.Brokers.Storages;
using Tarteeb.Provider.Models.Applicant;

namespace Tarteeb.Provider.Services.Foundations.ApplicantService
{
    internal class ApplicantService
    {
        private readonly StorageBroker storageBroker;

        public ApplicantService(StorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        internal Task<Applicant> AddApplicantAsync(Applicant applicant) =>
            this.storageBroker.InsertApplicantAsync(applicant);
    }
}
