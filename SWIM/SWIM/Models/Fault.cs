using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SWIM.Models
{
    [Table("Faults")]
    public class Fault
    {
        [PrimaryKey, AutoIncrement]
        [Column("faultID")]
        public int FaultID { get; set; }

        [Column("description")]
        public string Desciption { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("dateSubmitted")]
        public DateTime DateSubmitted { get; set; }

        [Column("estimatedFixDate")]
        public DateTime EstimatedFixDate { get; set; }
    }
}
