using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Models
{
    public class FormattedBill
    {
        public string BillPeriod { get; set; }
        public double Amount { get; set; }

        public FormattedBill(string billPeriod, double amount)
        {
            this.BillPeriod = billPeriod;
            this.Amount = amount;
        }
    }
}
