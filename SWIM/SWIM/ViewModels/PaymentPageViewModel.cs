using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class PaymentPageViewModel : BaseViewModel
    {
        private bool isCardPaymentVisible, isBPAYVisible, isOtherVisisble;

        public ICommand PaymentMethodSelection { get; }

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


        public PaymentPageViewModel()
        {
            PaymentMethodSelection = new Command(OnPaymentSelectionClicked);
            IsCardPaymentVisible = true;
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
    }
}
