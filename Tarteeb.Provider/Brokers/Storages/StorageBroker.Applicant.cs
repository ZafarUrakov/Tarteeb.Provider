//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using Microsoft.EntityFrameworkCore;
using Tarteeb.Provider.Models.Applicant;

namespace Tarteeb.Provider.Brokers.Storages
{
    internal partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }
    }
}
