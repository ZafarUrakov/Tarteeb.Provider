//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using System;

namespace Tarteeb.Provider.Models.Applicant
{
    public class Applicant
    {
        public Guid ApplicantId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string Groupname { get; set; }
        public Guid GroupId { get; set; }
    }
}
