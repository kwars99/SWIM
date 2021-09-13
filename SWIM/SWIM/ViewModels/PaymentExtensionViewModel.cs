using SWIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWIM.ViewModels
{
    public class PaymentExtensionViewModel : BaseViewModel
    {
        private List<Bill> billData = new List<Bill>();
        private List<Bill> unpaidBill = new List<Bill>();
        private DateTime currentDate, maximumDate, selectedDate, dueDate;

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
                dueDate = billData[0].DueDate;
                return dueDate;
            }
        }
        public DateTime CurrentDate
        {
            get
            {
                currentDate = DateTime.Now;
                return currentDate;
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

        
        public DateTime MaximumDate
        {
            get
            {
                return maximumDate;
            }
            set
            {
                if (maximumDate != value)
                {
                    maximumDate = value;
                    OnPropertyChanged(nameof(MaximumDate));
                }
            }
        }

        public PaymentExtensionViewModel()
        {
            billData = App.Database.GetBillAsync();
            unpaidBill = billData.Where(x => x.PaidStatus == "unpaid").ToList();
            maximumDate = unpaidBill[0].DueDate.AddDays(31);
        }
    }
}
