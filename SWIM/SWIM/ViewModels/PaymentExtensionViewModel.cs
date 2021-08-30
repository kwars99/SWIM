using System;
using System.Collections.Generic;
using SWIM.Models;
using System.Linq;
using System.Text;

namespace SWIM.ViewModels
{
    public class PaymentExtensionViewModel : BaseViewModel
    {
        private List<Bill> billData = new List<Bill>();
        private List<Bill> unpaidBill = new List<Bill>();
        private DateTime currentDate, maximumDate, selectedDate;

        public double BillAmount
        {
            get
            {
                return billData[0].Amount;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return billData[0].DueDate;
            }
        }

        public DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        /*
        public DateTime MaximumDate
        {
            get
            {
                maximumDate = DueDate.AddDays(31);
                return maximumDate;
            }            
        }
        */


        public PaymentExtensionViewModel()
        {
            billData = App.Database.GetBillAsync();
            unpaidBill = billData.Where(x => x.PaidStatus == "unpaid").ToList();
        }
    }
}
