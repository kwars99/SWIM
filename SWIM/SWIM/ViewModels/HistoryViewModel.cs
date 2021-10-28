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
    public class HistoryViewModel : BaseViewModel
    {
        private List<Transaction> data = new List<Transaction>();

        public List<Transaction> Data
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

        public HistoryViewModel()
        {
            data = App.Database.GetTransactionAsync();
            data.Reverse();
            
        }
    }
}
