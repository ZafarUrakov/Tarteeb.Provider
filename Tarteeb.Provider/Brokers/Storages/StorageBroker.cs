//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Tarteeb.Provider.Brokers.Storages
{
    internal partial class StorageBroker : EFxceptionsContext
    {
        public StorageBroker() =>
            this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data source=..\\..\\..\\TarteebImporter.db";
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
