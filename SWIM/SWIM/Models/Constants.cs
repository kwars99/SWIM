using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.Models
{
    public class Constants
    {
        public const string APIKey = "NDc4ODkyQDMxMzkyZTMyMmUzMGtSWmFjN1ptS1NwOU5FQXBtQUY0MlNYMy9BaXR0SmlZaDI5cGZhL3lYcXM9";
        public const string Email = "swim";
        public const string Password = "password";
        public const string UserKey = "user_token";
        public const string PwdKey = "pwd_token";

        // Below rates are based on Urban Utilities 
        public const double WaterAccesCharge = 0.637; //per day
        public const double SewerageAccessCharge = 1.534; //per day
        public const double StateWaterCharge = 3.122; //per kL
        public const int Tier1Threshold = 74;
        public const double Tier1Charge = 0.818; //per kL
        public const double Tier2Charge = 1.649; //per kL
    }
}
