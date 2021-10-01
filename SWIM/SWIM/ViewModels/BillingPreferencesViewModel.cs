using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class BillingPreferencesViewModel : BaseViewModel
    {
        private bool isEmailChecked, isPostChecked, is1MonthChecked, is2WeeksChecked,
                     is1WeekChecked, isReminderEmailChecked, isSMSChecked, isWeeklyChecked,
                     isFortnightlyChecked;

        private string receivingBillSelection, receivingBillTimeSelection, receivingReminderSelection,
                       reminderTimeSelection;

        public ICommand SavePreferencesCommand { get; }

        public bool IsEmailChecked
        {
            get
            {
                return isEmailChecked;
            }
            set
            {
                if (isEmailChecked != value)
                {
                    isEmailChecked = value;
                    OnPropertyChanged(nameof(IsEmailChecked));
                }
            }
        }

        public bool IsPostChecked
        {
            get
            {
                return isPostChecked;
            }
            set
            {
                if (isPostChecked != value)
                {
                    isPostChecked = value;
                    OnPropertyChanged(nameof(IsPostChecked));
                }
            }
        }

        public bool Is1MonthChecked
        {
            get
            {
                return is1MonthChecked;
            }
            set
            {
                if (is1MonthChecked != value)
                {
                    is1MonthChecked = value;
                    OnPropertyChanged(nameof(Is1MonthChecked));
                }
            }
        }
        
        public bool Is2WeeksChecked
        {
            get
            {
                return is2WeeksChecked;
            }
            set
            {
                if (is2WeeksChecked != value)
                {
                    is2WeeksChecked = value;
                    OnPropertyChanged(nameof(Is2WeeksChecked));
                }
            }
        }

        public bool Is1WeekChecked
        {
            get
            {
                return is1WeekChecked;
            }
            set
            {
                if (is1WeekChecked != value)
                {
                    is1WeekChecked = value;
                    OnPropertyChanged(nameof(Is1WeekChecked));
                }
            }
        }

        public bool IsReminderEmailChecked
        {
            get
            {
                return isReminderEmailChecked;
            }
            set
            {
                if (isReminderEmailChecked != value)
                {
                    isReminderEmailChecked = value;
                    OnPropertyChanged(nameof(IsReminderEmailChecked));
                }
            }
        }

        public bool IsSMSChecked
        {
            get
            {
                return isSMSChecked;
            }
            set
            {
                if (isSMSChecked != value)
                {
                    isSMSChecked = value;
                    OnPropertyChanged(nameof(IsSMSChecked));
                }
            }
        }

        public bool IsWeeklykChecked
        {
            get
            {
                return isWeeklyChecked;
            }
            set
            {
                if (isWeeklyChecked != value)
                {
                    isWeeklyChecked = value;
                    OnPropertyChanged(nameof(IsWeeklykChecked));
                }
            }
        }

        public bool IsFortnightlyChecked
        {
            get
            {
                return isFortnightlyChecked;
            }
            set
            {
                if (isFortnightlyChecked != value)
                {
                    isFortnightlyChecked = value;
                    OnPropertyChanged(nameof(IsFortnightlyChecked));
                }
            }
        }

        public string ReceivingBillSelection
        {
            get
            {
                return receivingBillSelection;
            }
            set
            {
                if (receivingBillSelection != value)
                {
                    receivingBillSelection = value;
                    OnPropertyChanged(nameof(ReceivingBillSelection));
                }
            }
        }

        public string ReceivingBillTimeSelection
        {
            get
            {
                return receivingBillTimeSelection;
            }
            set
            {
                if (receivingBillTimeSelection != value)
                {
                    receivingBillTimeSelection = value;
                    OnPropertyChanged(nameof(ReceivingBillTimeSelection));
                }
            }

        }

        public string ReceivingReminderSelection
        {
            get
            {
                return receivingReminderSelection;
            }
            set
            {
                if (receivingReminderSelection != value)
                {
                    receivingReminderSelection = value;
                    OnPropertyChanged(nameof(ReceivingReminderSelection));
                }
            }

        }

        public string ReminderTimeSelection
        {
            get
            {
                return reminderTimeSelection;
            }
            set
            {
                if (reminderTimeSelection != value)
                {
                    reminderTimeSelection = value;
                    OnPropertyChanged(nameof(ReminderTimeSelection));
                }
            }

        }

        public BillingPreferencesViewModel()
        {
            SavePreferencesCommand = new Command(OnSaveButtonClicked);
            LoadPreferences();
        }
        
        private void OnSaveButtonClicked(object obj)
        {
            Preferences.Set(nameof(ReceivingBillSelection), receivingBillSelection);          
            Preferences.Set(nameof(ReceivingBillTimeSelection), receivingBillTimeSelection);           
            Preferences.Set(nameof(ReceivingReminderSelection), receivingReminderSelection);           
            Preferences.Set(nameof(ReminderTimeSelection), reminderTimeSelection);
        }

        private void LoadPreferences()
        {
            receivingBillSelection = Preferences.Get(nameof(ReceivingBillSelection), "Email");
            receivingBillTimeSelection = Preferences.Get(nameof(ReceivingBillTimeSelection), "1 Month");
            receivingReminderSelection = Preferences.Get(nameof(ReceivingReminderSelection), "Email");
            reminderTimeSelection = Preferences.Get(nameof(ReminderTimeSelection), "Weekly");

            if (receivingBillSelection == "Email")
            {
                IsEmailChecked = true;
            }
            else
            {
                IsPostChecked = true;
            }


            if (receivingBillTimeSelection == "1 Month")
            {
                Is1MonthChecked = true;
            }
            else if (receivingBillTimeSelection == "2 Weeks")
            {
                Is2WeeksChecked = true;
            }
            else
            {
                Is1WeekChecked = true;
            }


            if (receivingReminderSelection == "Email")
            {
                IsReminderEmailChecked = true;
            }
            else
            {
                IsSMSChecked = true;
            }


            if (reminderTimeSelection == "Weekly")
            {
                IsWeeklykChecked = true;
            }
            else
            {
                IsFortnightlyChecked = true;
            }

        }
    }
}
