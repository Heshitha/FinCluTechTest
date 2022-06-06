using System;
using System.Collections.Generic;
using System.Text;

namespace FinCluTech.BusinessObject.Models
{
    public class CustomerBo : BOCommon
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string StudentStatus { get; set; }
        public string Major { get; set; }
        public string Country { get; set; }
        public string Age { get; set; }
        public string SAT { get; set; }
        public string Grade { get; set; }
        public string Height { get; set; }
    }
}
