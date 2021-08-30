using System;
using System.Collections.Generic;
using System.Text;

namespace SWIM.ViewModels
{
    public class PaymentExtensionViewModel
    {
        private DateTime currentDate, maximumDate;

        public DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime MaximumDate
        {
            get
            {
                return DateTime.Now.AddDays(31);
            }
        }
        
        public PaymentExtensionViewModel()
        {

        }
    }
}
