using SWIM.Models;
using SWIM.Views;
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

        private string cardHolder, cardNumber, cardExpiry, cardCVV;

        private List<Bill> unpaidBill = new List<Bill>();

        private List<User> user = new List<User>();

        public ICommand PaymentMethodSelection { get; set; }
        public ICommand OpenPopupCommand { get; set; }

        public ICommand ClosePopupCommand { get; set; }

        public ICommand MakePaymentCommand { get; set; }

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

        public string CardHolder
        {
            get
            {
                return cardHolder;
            }
            set
            {
                if (cardHolder != value)
                {
                    cardHolder = value;
                    OnPropertyChanged(nameof(CardHolder));
                }
            }
        }

        public string CardNumber
        {
            get
            {
                return cardNumber;
            }
            set
            {
                if (cardNumber != value)
                {
                    cardNumber = value;
                    OnPropertyChanged(nameof(CardNumber));
                }
            }
        }
        public string CardExpiry
        {
            get
            {
                return cardExpiry;
            }
            set
            {
                if (cardExpiry != value)
                {
                    cardExpiry = value;
                    OnPropertyChanged(nameof(CardExpiry));
                }
            }
        }
        public string CardCVV
        {
            get
            {
                return cardCVV;
            }
            set
            {
                if (cardCVV != value)
                {
                    cardCVV = value;
                    OnPropertyChanged(nameof(CardCVV));
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
            ClosePopupCommand = new Command(OnCancelButtonClicked);
            MakePaymentCommand = new Command(OnPayBillButtonClicked);

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
            //if all card details are valid, display payment review popup
            if (!(string.IsNullOrEmpty(cardNumber)))
            {
                DisplayPopup = true;
            }
            // display incorrect details
            // how to get the incorrect entry
            else
            {
                return;
            }
        }

        private void OnCancelButtonClicked()
        {
            DisplayPopup = false;
        }

        
        private async void OnPayBillButtonClicked()
        {
            int newTransactionID = App.Database.GetTransactionAsync().Count + 1;

            Bill bill = unpaidBill[0];

            DateTime paymentTime = DateTime.Now;

            Transaction newTransaction = new Transaction()
            {
                TransactionID = newTransactionID,
                Amount = bill.Amount,
                DatePaid = paymentTime
            };

            await App.Database.InsertTransactionAsync(newTransaction);
                
            bill.PaidStatus = "paid";
                
            await App.Database.UpdateBillAsync(bill);

            DisplayPopup = false;

            await Shell.Current.GoToAsync($"///{nameof(BillsPage)}");
        }       
    }
}
