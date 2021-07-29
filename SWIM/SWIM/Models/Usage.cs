using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SWIM.Models
{
    [Table("Usage")]
    public class Usage
    {
        [PrimaryKey, AutoIncrement]
        [Column("usageID")]
        public int UsageID { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("date")]
        public string Month { get; set; }

        [Column("tier")]
        public string Tier { get; set; }

        [Column("rate")]
        public double Rate { get; set; }
    }
}
