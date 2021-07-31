using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using SWIM.Models;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class UsageViewModel : INotifyPropertyChanged
    {
        
        private List<Usage> data = new List<Usage>();
        private List<Usage> lastThreeEntries = new List<Usage>();

        public List<Usage> Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }
        
        public List<Usage> ChartEntries
        {
            get { return lastThreeEntries; }
            set
            {
                if (lastThreeEntries != null)
                {
                    lastThreeEntries = value;
                    OnPropertyChanged(nameof(ChartEntries));
                }
            }
        }


        public UsageViewModel()
        { 
        
        }   

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
