using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
        private const int NumOfHistory = 12;

        private List<Usage> data = new List<Usage>();
        private List<FormattedUsage> lastThreeEntries = new List<FormattedUsage>();
        private List<FormattedUsage> quarterlyUsages = new List<FormattedUsage>();
        private List<FormattedUsage> monthlyUsages = new List<FormattedUsage>();

        private List<Usage> byMonthlyUsages = new List<Usage>();

        public ICommand OpenReportUsageCommand { get; set; }

        public List<Usage> ByMonthlyUsages
        {
            get
            {
                return byMonthlyUsages;
            }
            set
            {
                if (byMonthlyUsages != value)
                {
                    byMonthlyUsages = value;
                    OnPropertyChanged(nameof(ByMonthlyUsages));
                }
            }
        }

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

        public List<FormattedUsage> MonthlyUsages
        {
            get
            {
                return monthlyUsages;
            }
            set
            {
                if (monthlyUsages != value)
                {
                    monthlyUsages = value;
                    OnPropertyChanged(nameof(MonthlyUsages));
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
            GetMonthlyUsages();
            FormatLastThree();
            ComputeQuarterlyUsage();
            
        }

        private async void OnSubmitReadingClicked(object obj)
        {
            var route = $"{nameof(ReportUsagePage)}";
            await Shell.Current.GoToAsync(route);
        }

        private List<FormattedUsage> GetMonthlyUsages()
        {
            var groupedByMonth = data.GroupBy(x => x.ReadingDate.Month);

            var usagesByMonth = groupedByMonth.Select(x => x.ToList()).ToList();

            for (int i = 0; i < usagesByMonth.Count; i++)
            {
                for (int j = 0; j < usagesByMonth[i].Count; j++)
                {
                    byMonthlyUsages.Add(usagesByMonth[i][j]);
                }
            }

            for (int i = 0; i < usagesByMonth.Count; i++)
            {
                double monthlyUsage = usagesByMonth[i].Sum(y => y.Amount);

                int monthIndex = usagesByMonth[i][0].ReadingDate.Month;

                string month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(monthIndex);

                string readingDate = usagesByMonth[i][0].ReadingDate.ToString("MMM \"'\"yy");

                int numOfDays = DateTime.DaysInMonth(usagesByMonth[i][0].ReadingDate.Year, 
                                                     usagesByMonth[i][0].ReadingDate.Month);

                double cost = CalculateCost(monthlyUsage, numOfDays);

                FormattedUsage formattedUsage = new FormattedUsage(readingDate, monthlyUsage, cost);

                monthlyUsages.Add(formattedUsage);
            }

            return monthlyUsages;
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
                lastThreeEntries.Add(monthlyUsages[i]);
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
            for (int i = 0; i < NumOfHistory; i += 3)
            {
                string period = monthlyUsages[i + 2].TimePeriod + "-" + monthlyUsages[i].TimePeriod;

                double totalUsage = monthlyUsages[i].TotalUsage + monthlyUsages[i + 1].TotalUsage +
                                    monthlyUsages[i + 2].TotalUsage;

                double cost = monthlyUsages[i].Cost + monthlyUsages[i + 1].Cost + monthlyUsages[i].Cost;

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
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
