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

        public ApplicantService()
        {
            this.storageBroker = new StorageBroker();
        }

        internal Task<Applicant> AddApplicantAsync(Applicant applicant) =>
            this.storageBroker.InsertApplicantAsync(applicant);
    }
}
