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
    public class EnquiriesViewModel : INotifyPropertyChanged
    {
        List<Enquiry> data = new List<Enquiry>();
        List<Enquiry> openEnquiries = new List<Enquiry>();

        public List<Enquiry> Data
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

        public List<Enquiry> OpenEnquiries
        {
            get
            {
                List<Enquiry> open = data.Where(x => x.EnquiryOpen == "open").ToList();
                return open;
            }
            set
            {
                if (openEnquiries != value)
                {
                    openEnquiries = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }

        public EnquiriesViewModel()
        {
            data = App.Database.GetEnquiryAsync();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
