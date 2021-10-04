using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SWIM.Models
{
    [Table("Enquiries")]
    public class Enquiry
    {
        [PrimaryKey, AutoIncrement]
        [Column("enquiryID")]
        public int EnquiryID { get; set; }

        [Column("category")]
        public string Cateogry { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("enquiryDate")]
        public DateTime EnquiryDate { get; set; }
        
        [Column("status")]
        public string EnquiryOpen { get; set; }
    }
}
