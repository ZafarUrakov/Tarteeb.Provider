//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//===============================

using Xeptions;

namespace Tarteeb.Provider.Brokers.Exceptions
{
    internal class NullApplicantException : Xeption
    {
        public NullApplicantException()
            : base(message: "Applicant is null")
        { }
    }
}
