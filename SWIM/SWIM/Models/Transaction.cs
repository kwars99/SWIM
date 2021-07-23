using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SWIM.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        [Column("transactionID")]
        public int TransactionID { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("datePaid")]
        public DateTime DatePaid { get; set; }
    }
}
