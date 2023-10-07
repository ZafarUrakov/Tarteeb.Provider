//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tarteeb.Provider.Models.Applicant;

namespace Tarteeb.Provider.Brokers.Storages
{
    internal partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }

        public async Task<Applicant> InsertApplicantAsync(Applicant applicant)
        {
            await this.Applicants.AddAsync(applicant);
            await SaveChangesAsync();

            return applicant;
        }

        public async Task<Applicant> SelectApplicantById(Guid applicantId) =>
            await this.Applicants.FindAsync(applicantId);

        public IQueryable<Applicant> SelectAll() =>
            this.Applicants.AsQueryable();

        public async Task<Applicant> UpdateApplicantAsync(Applicant applicant)
        {
            this.Applicants.Update(applicant);
            await SaveChangesAsync();

            return applicant;
        }

        public async Task<bool> DeleteApplicantAsync(Guid applicantId)
        {
            var applicantToDelete = await this.Applicants.FindAsync(applicantId);

            if (applicantToDelete == null)
                return false;

            this.Applicants.Remove(applicantToDelete);
            await this.SaveChangesAsync();

            return true;
        }
    }
}
