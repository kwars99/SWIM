using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Models
{
    public class FormattedUser
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public FormattedUser(string fullname, string email, string address)
        {
            this.Fullname = fullname;
            this.Email = email;
            this.Address = address;
        }
    }
}
