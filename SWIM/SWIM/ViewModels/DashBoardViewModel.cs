using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWIM.Models;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    class DashBoardViewModel : INotifyPropertyChanged
    {
        private List<Bill> billData = new List<Bill>();
        private List<Bill> unpaidBills = new List<Bill>();
        private List<Usage> usageData = new List<Usage>();
        private List<FormattedUsage> billUsage = new List<FormattedUsage>();
        private string dueDate;

        public List<Bill> BillData
        {
            get
            {
                return billData;
            }
            set
            {
                if (billData != value)
                {
                    billData = value;
                    OnPropertyChanged(nameof(BillData));                   
                }
            }
        }

        public List<Usage> UsageData
        {
            get
            {
                return usageData;
            }
            set
            {
                if (usageData != value)
                {
                    usageData = value;
                    OnPropertyChanged(nameof(UsageData));
                }
            }

        }

        public List<FormattedUsage> BillUsage
        {
            get
            {
                return billUsage;
            }
            set
            {
                if (billUsage != value)
                {
                    billUsage = value;
                    OnPropertyChanged(nameof(billUsage));
                }
            }
        }

        public string DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                if (dueDate != value)
                {
                    dueDate = value;
                    OnPropertyChanged(nameof(DueDate));
                }
            }
        }

        public DashBoardViewModel()
        {
            usageData = App.Database.GetUsageAsync();
            usageData.Reverse();

            billData = App.Database.GetBillsAsync();
            FormatBillData();
        }

        private List<FormattedUsage> FormatBillData()
        {

            string billingPeriod = usageData[2].ReadingDate.ToString("MMM \"'\"yy") + "-" +
                                usageData[0].ReadingDate.ToString("MMM \"'\"yy");
            string formatBillingPeriod = "Billing Period: "+ billingPeriod;
            double waterUsage = usageData[0].Amount + usageData[1].Amount + usageData[2].Amount;

            //string usageID1 = usageData[0].UsageID.ToString();
            //string usageID2 = usageData[1].UsageID.ToString();
            //string usageID3 = usageData[2].UsageID.ToString();

            //string IDs = String.Format("{0},{1},{2}", usageID1, usageID2, usageID3);

            unpaidBills = billData.Where(x => x.PaidStatus == "unpaid").ToList();

            double billCost = unpaidBills[0].Amount;

            string formatDueDate = "Due On: ";

            dueDate = unpaidBills[0].DueDate.ToString(formatDueDate + "dd/MMM");


            FormattedUsage formattedUsage = new FormattedUsage(formatBillingPeriod, waterUsage, billCost);


            billUsage.Add(formattedUsage);


            return billUsage;
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
              
}

