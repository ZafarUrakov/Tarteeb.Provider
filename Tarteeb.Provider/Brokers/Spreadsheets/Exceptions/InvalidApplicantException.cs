//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.Provider.Models.Exceptions
{
    internal class InvalidApplicantException : Xeption
    {
        public InvalidApplicantException()
            : base(message: "Applicant is invalid")
        { }
    }
}
