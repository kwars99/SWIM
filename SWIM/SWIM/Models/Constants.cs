using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Models
{
    public class Constants
    {
        public static string APIKey = "NDc4ODkyQDMxMzkyZTMyMmUzMGtSWmFjN1ptS1NwOU5FQXBtQUY0MlNYMy9BaXR0SmlZaDI5cGZhL3lYcXM9";
        public static string Email = "swim";
        public static string Passwword = "password";

        // Below rates are based on Urban Utilities 
        public static double WaterAccesCharge = 0.637; //per day
        public static double SewerageAccessCharge = 1.534; //per day
        public static double StateWaterCharge = 3.122; //per kL
        public static int Tier1Threshold = 74;
        public static double Tier1Charge = 0.818; //per kL
        public static double Tier2Charge = 1.649; //per kL
    }
}
