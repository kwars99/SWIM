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
    public class UpdateDetailsViewModel : INotifyPropertyChanged
    {
        private List<User> data = new List<User>();
        private List<FormattedUser> formattedUsers = new List<FormattedUser>();

        public List<User> Data
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

        public List<FormattedUser> FormattedUsers
        {
            get
            {
                return formattedUsers;
            }
            set
            {
                if(formattedUsers != null)
                {
                    formattedUsers = value;
                    OnPropertyChanged(nameof(FormattedUser));
                }
            }
        }

        public UpdateDetailsViewModel()
        {
            data = App.Database.GetUserDetailsAsync();
            FormatUsers();
        }

        private List<FormattedUser> FormatUsers()
        {          
            string fullname = data[0].FirstName + " " + data[0].LastName;
            string email = data[0].Email;
            string address = data[0].Address;

            FormattedUser user = new FormattedUser(fullname, email, address);
               
            formattedUsers.Add(user);        

            return formattedUsers;
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
