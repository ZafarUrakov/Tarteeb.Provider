using Microsoft.EntityFrameworkCore;
using Tarteeb.Provider.Models.Groups;

namespace Tarteeb.Provider.Brokers.Storages
{
    internal partial class StorageBroker
    {
        DbSet<Group> Groups { get; set; }
    }
}
