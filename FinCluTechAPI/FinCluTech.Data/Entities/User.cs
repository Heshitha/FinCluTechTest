using FinCluTech.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinCluTech.Data.Entities
{
    public class User : DomainCommon
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
