using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Models
{
    public class Charge
    {
        public string Description { get; set; }
        public double Cost { get; set; }

        public Charge(string description, double cost)
        {
            this.Description = description;
            this.Cost = cost;
        }
    }
}
