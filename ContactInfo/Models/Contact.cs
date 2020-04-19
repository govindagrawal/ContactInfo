using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactInfo.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
    }
}