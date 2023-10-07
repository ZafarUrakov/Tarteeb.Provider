//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System.Threading.Tasks;
using Tarteeb.Provider.Brokers.Storages;
using Tarteeb.Provider.Models.Groups;

namespace Tarteeb.Provider.Services.Foundations.GroupService
{
    internal class GroupService
    {
        private readonly StorageBroker storageBroker;

        public GroupService()
        {
            this.storageBroker = new StorageBroker();
        }

        internal Task<Group> AddGroupAsync(Group group)
        {
            return this.storageBroker.InsertGroupAsync(group);
        }

        internal Task<Group> RetrieveByName(string groupName)
        {
            return this.storageBroker.SelectGroupByName(groupName);
        }
    }
}
