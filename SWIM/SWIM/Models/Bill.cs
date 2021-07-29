using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SWIM.Models
{
    [Table("Bills")]
    public class Bill
    {
        [PrimaryKey, AutoIncrement]
        [Column("billID")]
        public int BillID { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("dueDate")]
        public DateTime DueDate { get; set; }

        [Column("status")]
        public bool PaidStatus { get; set; }

        [Column("usage")]
        public string UsageIDs { get; set; }
    }
}
