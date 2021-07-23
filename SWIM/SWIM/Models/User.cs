using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SWIM.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [Column("userID")]
        public int UserID { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }


        [MaxLength(10)]
        [Column("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("hasBill")]
        public bool HasBill { get; set; }

        [Column("usages")]
        public string UsageIDs { get; set; }

        [Column("enquiries")]
        public string EnquiryIDs { get; set; }

        [Column("transactions")]
        public string TransactionIDs { get; set; }

        [Column("bills")]
        public string BillIDs { get; set; }
    }
}