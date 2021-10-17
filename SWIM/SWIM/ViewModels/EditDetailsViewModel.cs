using SWIM.Models;
using SWIM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class EditDetailsViewModel : BaseViewModel
    {
        private string streetAddress, cityOrTown, state, postcode, email, phoneNumber;

        private List<User> data { get; set; }

        public ICommand UpdateDetailsCommand { get; set; }

        public INavigation Navigation { get; set; }

        public string StreetAddress
        {
            get
            {
                return streetAddress;
            }
            set
            {
                if (streetAddress != value)
                {
                    streetAddress = value;
                    OnPropertyChanged(nameof(StreetAddress));
                }
            }
        }

        public string CityOrTown
        {
            get
            {
                return cityOrTown;
            }
            set
            {
                if (cityOrTown != value)
                {
                    cityOrTown = value;
                    OnPropertyChanged(nameof(CityOrTown));
                }
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (state != value)
                {
                    state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        public string Postcode
        {
            get
            {
                return postcode;
            }
            set
            {
                if (postcode != value)
                {
                    postcode = value;
                    OnPropertyChanged(nameof(Postcode));
                }
            }
        }
        
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public EditDetailsViewModel(List<User> userData, INavigation navigation)
        {
            this.Navigation = navigation;

            data = userData;

            UpdateDetailsCommand = new Command(OnUpdateDetailsClicked);

            //splitting the address into appropriate sub parts for entry binding
            string[] addressSubs = userData[0].Address.Split(',');
            streetAddress = addressSubs[0];
            cityOrTown = addressSubs[1];

            //splitting the state and postcode for separate entry binding
            string[] postcodeSplit = addressSubs[2].Split(' ');

            // postcodeSplit[0] == space
            state = postcodeSplit[0];
            postcode = postcodeSplit[1];
            
            email = data[0].Email;
            phoneNumber = data[0].PhoneNumber;
        }

        //Deafult constructor
        public EditDetailsViewModel()
        {

        }

        private async void OnUpdateDetailsClicked(object obj)
        {
            data[0].Address = StreetAddress + "," + CityOrTown + "," + State + " " + Postcode;
            data[0].Email = Email;
            data[0].PhoneNumber = PhoneNumber;

            await App.Database.UpdateUserAsync(data[0]);

            Application.Current.MainPage = new AppShell();
            var route = $"{nameof(MyAccountPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
