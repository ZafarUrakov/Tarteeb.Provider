//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarteeb.Provider.Models.Applicant;
using Tarteeb.Provider.Models.Groups;
using Tarteeb.Provider.Services.Foundations.GroupService;

namespace Tarteeb.Provider.Services.Processings.ImporterProcessingService
{
    internal class GroupProcessingService
    {
        private readonly GroupService groupService;
        
        public GroupProcessingService()
        {
            this.groupService = new GroupService();
        }

        public async Task<Guid> EnsureGroupExistsAsync(string groupName)
        {
            var groupFromService = await this.groupService.RetrieveByName(groupName);

            if (groupFromService == null)
            {
                var newGroup = new Group { GroupName = groupName };
                var createdGroup = await this.groupService.AddGroupAsync(newGroup);

                return createdGroup.GroupId;
            }
            else
            {
                return groupFromService.GroupId;
            }
        }

        public async Task<List<Applicant>> AllApplicants(List<Applicant> applicants)
        {
            foreach (var item in applicants)
            {
                var id = await EnsureGroupExistsAsync(item.Groupname);
                item.GroupId = id;
            }

            return applicants;
        }
    }
}
