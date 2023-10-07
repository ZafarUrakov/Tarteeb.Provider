using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Tarteeb.Provider.Models.Groups;

namespace Tarteeb.Provider.Brokers.Storages
{
    internal partial class StorageBroker
    {
        DbSet<Group> Groups { get; set; }

        public async Task<Group> InsertGroupAsync(Group group)
        {
            await this.Groups.AddAsync(group);
            await this.SaveChangesAsync();

            return group;
        }

        public async Task<Group> SelectGroupByName(string groupName) =>
            await this.Groups.FindAsync(groupName);

        public IQueryable<Group> SelectAllGroup() =>
            this.Groups.AsQueryable();

        public async Task<Group> UpdateGroupAsync(Group group)
        {
            this.Groups.Update(group);
            await this.SaveChangesAsync();

            return group;
        }

        public async Task<bool> DeleteGroupAsync(Guid userId)
        {
            var groupToDelete = await this.Groups.FindAsync(userId);

            if (groupToDelete == null)
                return false;

            this.Groups.Remove(groupToDelete);
            await this.SaveChangesAsync();

            return true;
        }
    }
}
