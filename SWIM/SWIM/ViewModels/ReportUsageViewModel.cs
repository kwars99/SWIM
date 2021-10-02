using SWIM.Models;
using SWIM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class ReportUsageViewModel : BaseViewModel
    {
        private DateTime dateReported, minimumDate, currentDate;
        private double meterReading;

        public ICommand SubmitReadingCommand { get; set; }

        public DateTime DateReported
        {
            get
            {
                return dateReported;
            }
            set
            {
                if (dateReported != value)
                {
                    dateReported = value;
                    OnPropertyChanged(nameof(DateReported));                
                }
            }
        }

        public DateTime MinimumDate
        {
            get
            {
                minimumDate = CurrentDate.AddDays(-7);
                return minimumDate;
            }
            set
            {
                if (minimumDate != value)
                {
                    minimumDate = value;
                    OnPropertyChanged(nameof(MinimumDate));                
                }
            }
        }

        public DateTime CurrentDate
        {
            get
            {
                currentDate = DateTime.Now;
                return currentDate;
            }
            set
            {
                if (currentDate != value)
                {
                    currentDate = value;
                    OnPropertyChanged(nameof(CurrentDate));                
                }
            }
        }

        public double MeterReading
        {
            get
            {
                return meterReading;
            }
            set
            {
                if (meterReading != value)
                {
                    meterReading = value;
                    OnPropertyChanged(nameof(MeterReading));                
                }
            }
        }

        public ReportUsageViewModel()
        {
            SubmitReadingCommand = new Command(OnSubmitReadingClicked);
        }

        private async void OnSubmitReadingClicked(object obj)
        {
            Usage selfReading = new Usage()
            {
                Amount = meterReading,
                ReadingDate = dateReported
            };

            await App.Database.InsertUsageAsync(selfReading);

            var route = $"///{nameof(UsagePage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
