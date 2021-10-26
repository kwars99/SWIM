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

        private List<Usage> data = new List<Usage>();
        private List<FormattedUsage> lastThreeEntries = new List<FormattedUsage>();
        private List<FormattedUsage> quarterlyUsages = new List<FormattedUsage>();
        private List<FormattedUsage> monthlyUsages = new List<FormattedUsage>();
        private List<FormattedUsage> usagesByQuarter = new List<FormattedUsage>();

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
            CalculateMonthlyUsages();
            CalculateQuarterlyUsage();            

            for (int i = 0; i < 3; i++)
            {
                lastThreeEntries.Add(monthlyUsages[i]);
            }
        }

        private void CalculateMonthlyUsages()
        {
            var groupedByMonth = data.GroupBy(usage => new { Year = usage.ReadingDate.Year, Month = usage.ReadingDate.Month });

            var usagesByMonth = groupedByMonth.Select(x => x.ToList()).ToList();

            for (int i = 0; i < usagesByMonth.Count; i++)
            {
                double monthlyUsage = usagesByMonth[i].Sum(y => y.Amount);

                var month = usagesByMonth[i][0].ReadingDate.Month;

                int numOfDays = DateTime.DaysInMonth(usagesByMonth[i][0].ReadingDate.Year,
                                                     usagesByMonth[i][0].ReadingDate.Month);


                FormattedUsage formattedUsage = new FormattedUsage()
                {
                    TimePeriod = usagesByMonth[i][0].ReadingDate.ToString("MMM \"'\"yy"),
                    TotalUsage = monthlyUsage,
                    Cost = CalculateCost(monthlyUsage, numOfDays)
                };
                
                monthlyUsages.Add(formattedUsage);
            }
        }


        private void CalculateQuarterlyUsage()
        {
            for (int i = 0; i < monthlyUsages.Count; i++)
            {
                string month = monthlyUsages[i].TimePeriod;
                int date = DateTime.ParseExact(month, "MMM \"'\"yy", CultureInfo.CurrentCulture).Month;
                int quarter = GetQuarter(date);

                usagesByQuarter.Add(new FormattedUsage
                {
                    TimePeriod = monthlyUsages[i].TimePeriod,
                    TotalUsage = monthlyUsages[i].TotalUsage,
                    Cost = monthlyUsages[i].Cost,
                    Quarter = quarter
                });
            }
            
            var groupedByQuarter = usagesByQuarter.GroupBy(usage => new { Year = DateTime.ParseExact(usage.TimePeriod, "MMM \"'\"yy", CultureInfo.CurrentCulture).Year,
                                                                          Quarter = usage.Quarter});

            var quarterlyUsages = groupedByQuarter.Select(x => x.ToList()).ToList();

            for (int i = 0; i < quarterlyUsages.Count; i++)
            {
                double TotalQuarterUsage = quarterlyUsages[i].Sum(y => y.TotalUsage);
                string beginningMonth, endingMonth;

                switch (quarterlyUsages[i][0].Quarter)
                {
                    case 1:
                        beginningMonth = "Jan";
                        break;

                    case 2:
                        beginningMonth = "Apr";
                        break;

                    case 3:
                        beginningMonth = "Jul";
                        break;

                    case 4:
                        beginningMonth = "Oct";
                        break;

                    default:
                        beginningMonth = "unknown";
                        break;
                }

                //Fixes DateTime.ParseEsact Error on Android
                switch (beginningMonth)
                {
                    case "Jan":
                        endingMonth = "Mar";
                        break;

                    case "Apr":
                        endingMonth = "June";
                        break;

                    case "Jul":
                        endingMonth = "Sept";
                        break;

                    case "Oct":
                        endingMonth = "Dec";
                        break;

                    default:
                        endingMonth = "End";
                        break;
                }

                //DateTime beginningToDateTime = DateTime.ParseExact(beginningMonth, "MMM", CultureInfo.CurrentCulture);

                ///string endingMonth = DateTime.ParseExact(beginningMonth, "MMM", CultureInfo.CurrentCulture).AddMonths(2).ToString("MMM");

                string quarterTimePeriod = beginningMonth + " - " + endingMonth;

                double cost = quarterlyUsages[i].Sum(z => z.Cost);


                FormattedUsage formattedUsage = new FormattedUsage()
                {
                    TimePeriod = quarterTimePeriod,
                    TotalUsage = TotalQuarterUsage,
                    Cost = cost
                };

                QuarterlyUsages.Add(formattedUsage);
            } 
        }


        private int GetQuarter(int date)
        {
            return (date + 2) / 3;
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
