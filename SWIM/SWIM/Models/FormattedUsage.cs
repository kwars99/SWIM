using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Models
{
    public class FormattedUsage
    {
        public string Quarter { get; set; }
        public double TotalUsage { get; set; }
        public double Cost { get; set; }

        public FormattedUsage(string quarter, double totalUsage, double cost)
        {
            this.Quarter = quarter;
            this.TotalUsage = totalUsage;
            this.Cost = cost;
        }
    }
}
