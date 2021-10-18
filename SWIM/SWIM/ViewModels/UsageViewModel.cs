using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SWIM.Models;
using SWIM.Views;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class UsageViewModel : INotifyPropertyChanged
    {
        private const int NumOfEntries = 3;

        private List<Usage> data = new List<Usage>();
        private List<FormattedUsage> lastThreeEntries = new List<FormattedUsage>();
        private List<FormattedUsage> quarterlyUsages = new List<FormattedUsage>();

        public ICommand OpenReportUsageCommand { get; set; }

        public List<Usage> Data
        {
            get 
            {
                return data;
            }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }
        
        public List<FormattedUsage> LastThreeEntries
        {
            get 
            {
                return lastThreeEntries;   
            }
            set
            {
                if (lastThreeEntries != null)
                {
                    lastThreeEntries = value;
                    OnPropertyChanged(nameof(LastThreeEntries));
                }
            }
        }

        public List<FormattedUsage> QuarterlyUsages
        {
            get
            {
                return quarterlyUsages;
            }
            set
            {
                if (quarterlyUsages != null)
                {
                    quarterlyUsages = value;
                    OnPropertyChanged(nameof(QuarterlyUsages));
                }
            }
        }

        public UsageViewModel()
        {
            OpenReportUsageCommand = new Command(OnSubmitReadingClicked);

            data = App.Database.GetUsageAsync();
            data.Reverse();
            FormatLastThree();
            ComputeQuarterlyUsage();
        }

        /// <summary>
        /// Formats the usage data to be in correct form for displaying the chart 
        /// and the current quarters usage
        /// </summary>
        /// <returns> List of the mot current three usages </returns>
        private List<FormattedUsage> FormatLastThree()
        {
            for (int i = 0; i < NumOfEntries; i++)
            {
                string month = data[i].ReadingDate.ToString("MMMM");
                double waterUsage = data[i].Amount;
                int numOfDays = DateTime.DaysInMonth(data[i].ReadingDate.Year, 
                                                     data[i].ReadingDate.Month);
                double cost = CalculateCost(waterUsage, numOfDays);

                FormattedUsage usage = new FormattedUsage(month, waterUsage, cost);

                lastThreeEntries.Add(usage);
            }

            return lastThreeEntries;
        }

        /// <summary>
        /// Formats the usage data to be in correct form to display the previous 
        /// quarters' usages.
        /// </summary>
        /// <returns></returns>
        private List<FormattedUsage> ComputeQuarterlyUsage()
        {
            for (int i = 0; i < data.Count; i += 3)
            {
                string period = data[i + 2].ReadingDate.ToString("MMM \"'\"yy") + "-" + 
                                data[i].ReadingDate.ToString("MMM \"'\"yy");

                double totalUsage = data[i].Amount + data[i + 1].Amount + 
                                    data[i + 2].Amount;

                int numOfDays = GetNumberOfDays(data[i].ReadingDate, 
                                                data[i + 1].ReadingDate, 
                                                data[i + 2].ReadingDate);

                double cost = CalculateCost(totalUsage, numOfDays);

                FormattedUsage usage = new FormattedUsage(period, totalUsage, cost);
                quarterlyUsages.Add(usage);
            }

            return quarterlyUsages;
        }

        /// <summary>
        /// Helper method that calculates the cost in a given quarter.
        /// First checks if the total usage if above the threshold and assigns correct 
        /// charges.
        /// </summary>
        /// <param name="totalUsage"></param>
        /// <param name="numOfDays"></param>
        /// <returns>(double) total cost for the quarter</returns>
        private double CalculateCost(double totalUsage, int numOfDays)
        {
            // need to add in logic to calculate cost for both tiers
            // i.e. calculate first cost of up to tier 1 threshold
            // then calculate cost for tier 2
            double cost, tierCharge;

            if (totalUsage >= Constants.Tier1Threshold)
            {
                tierCharge = Constants.Tier2Charge;
            } 
            else
            {
                tierCharge = Constants.Tier1Charge;
            }

            cost = (totalUsage * tierCharge) + 
                   (totalUsage * Constants.StateWaterCharge) +
                   (numOfDays * Constants.WaterAccesCharge) + 
                   (numOfDays * Constants.SewerageAccessCharge);

            return cost;
        }

        /// <summary>
        /// Helper method to calculate the number of days in a quarter.
        /// To assist in calculating the total cost for a quarter
        /// </summary>
        /// <param name="month1"></param>
        /// <param name="month2"></param>
        /// <param name="month3"></param>
        /// <returns>(int) number of days in a quarter</returns>
        private int GetNumberOfDays(DateTime month1, DateTime month2, DateTime month3)
        {
            int numOfDays = DateTime.DaysInMonth(month1.Year, month1.Month) +
                            DateTime.DaysInMonth(month2.Year, month2.Month) +
                            DateTime.DaysInMonth(month3.Year, month3.Month);

            return numOfDays;
        }

        private async void OnSubmitReadingClicked(object obj)
        {
            var route = $"{nameof(ReportUsagePage)}";
            await Shell.Current.GoToAsync(route);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
