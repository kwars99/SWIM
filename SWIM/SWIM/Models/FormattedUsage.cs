using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Models
{
    public class FormattedUsage
    {
        public string TimePeriod { get; set; }
        public double TotalUsage { get; set; }
        public double Cost { get; set; }

        public int Quarter { get; set; }
        
        public FormattedUsage(string timePeriod, double totalUsage, double cost)
        {
            this.TimePeriod = timePeriod;
            this.TotalUsage = totalUsage;
            this.Cost = cost;
        }

        public FormattedUsage()
        {
            
        }

    }
}
