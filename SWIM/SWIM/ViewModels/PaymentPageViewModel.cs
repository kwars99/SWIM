﻿using SWIM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class PaymentPageViewModel : BaseViewModel
    {
        private bool isCardPaymentVisible, isBPAYVisible, isOtherVisisble, displayPopup;

        private List<Bill> unpaidBill = new List<Bill>();

        private List<User> user = new List<User>();

        public ICommand PaymentMethodSelection { get; set; }
        public ICommand OpenPopupCommand { get; set; }

        public bool IsCardPaymentVisible
        {
            get
            {
                return isCardPaymentVisible;
            }
            set
            {
                if (isCardPaymentVisible != value)
                {
                    isCardPaymentVisible = value;
                    OnPropertyChanged(nameof(IsCardPaymentVisible));
                }
            }
        }
        

        public bool IsBPAYVisible
        {
            get
            {
                return isBPAYVisible;
            }
            set
            {
                if (isBPAYVisible != value)
                {
                    isBPAYVisible = value;
                    OnPropertyChanged(nameof(IsBPAYVisible));
                }
            }
        }
        

        public bool IsOtherVisible
        {
            get
            {
                return isOtherVisisble;
            }
            set
            {
                if (isOtherVisisble != value)
                {
                    isOtherVisisble = value;
                    OnPropertyChanged(nameof(IsOtherVisible));
                }
            }
        }

        public bool DisplayPopup
        {
            get
            {
                return displayPopup;
            }
            set
            {
                if (displayPopup != value)
                {
                    displayPopup = value;
                    OnPropertyChanged(nameof(DisplayPopup));
                }
            }
        }

        public List<Bill> UnpaidBill
        {
            get
            {
                return unpaidBill;
            }
            set
            {
                if (unpaidBill != value)
                {
                    unpaidBill = value;
                    OnPropertyChanged(nameof(UnpaidBill));
                }
            }
        }

        public List<User> User
        {
            get
            {
                return user;
            }
            set
            {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }


        public PaymentPageViewModel()
        {
            PaymentMethodSelection = new Command(OnPaymentSelectionClicked);
            OpenPopupCommand = new Command(OnPaymentReviewClicked);
            IsCardPaymentVisible = true;

            unpaidBill = App.Database.GetBillAsync().Where(x => x.PaidStatus == "unpaid").ToList();
            user = App.Database.GetUsersAsync().Where(x => x.FirstName == "John").ToList();
        }

        private void OnPaymentSelectionClicked(object parameter)
        {
            switch(parameter)
            {
                case "Credit Card":
                    IsCardPaymentVisible = true;
                    IsBPAYVisible = false;
                    IsOtherVisible = false;
                    break;

                case "BPAY":
                    IsCardPaymentVisible = false;
                    IsBPAYVisible = true;
                    IsOtherVisible = false;
                    break;

                case "Other":
                    IsCardPaymentVisible = false;
                    IsBPAYVisible = false;
                    IsOtherVisible = true;
                    break;
            }
        }

        private void OnPaymentReviewClicked()
        {
            DisplayPopup = true;
        }
    }
}
