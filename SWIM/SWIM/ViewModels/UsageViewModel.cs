using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using SWIM.Models;

namespace SWIM.ViewModels
{
    public class UsageViewModel : INotifyPropertyChanged
    {
        
        private List<Usage> data = new List<Usage>();
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
