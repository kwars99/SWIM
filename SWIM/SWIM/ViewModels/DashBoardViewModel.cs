using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using SWIM.Models;
using SWIM.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    class DashBoardViewModel : INotifyPropertyChanged
    {
        private List<Bill> billData = new List<Bill>();
        private List<Bill> unpaidBills = new List<Bill>();
        private List<Usage> usageData = new List<Usage>();
        private List<FormattedUsage> billUsage = new List<FormattedUsage>();
        private List<WaterSavingTips> waterSavingTips = new List<WaterSavingTips>();
        private List<NewsItem> newsItems = new List<NewsItem>();

        private bool isErrorVisible;
        private bool isReminderVisible, isLabelVisible;

        private string error, dueDate, link;

        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        

        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                if (error != value)
                {
                    error = value;
                    OnPropertyChanged(nameof(Error));
                }
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                return isErrorVisible;
            }
            set
            {
                if (isErrorVisible != value)
                {
                    isErrorVisible = value;
                    OnPropertyChanged(nameof(IsErrorVisible));
                }
            }
        }

        public bool IsReminderVisible
        {
            get
            {
                return isReminderVisible;
            }
            set
            {
                if (isReminderVisible != value)
                {
                    isReminderVisible = value;
                    OnPropertyChanged(nameof(IsReminderVisible));
                }
            }
        }

        public bool IsLabelVisible
        {
            get
            {
                return isLabelVisible;
            }
            set
            {
                if (isLabelVisible != value)
                {
                    isLabelVisible = value;
                    OnPropertyChanged(nameof(IsLabelVisible));
                }
            }
        }


        public int ItemCount
        {
            get
            {
                return newsItems.Count;
            }
        }

        public List<Bill> BillData
        {
            get
            {
                return billData;
            }
            set
            {
                if (billData != value)
                {
                    billData = value;
                    OnPropertyChanged(nameof(BillData));                   
                }
            }
        }

        public List<Usage> UsageData
        {
            get
            {
                return usageData;
            }
            set
            {
                if (usageData != value)
                {
                    usageData = value;
                    OnPropertyChanged(nameof(UsageData));
                }
            }

        }

        public List<FormattedUsage> BillUsage
        {
            get
            {
                return billUsage;
            }
            set
            {
                if (billUsage != value)
                {
                    billUsage = value;
                    OnPropertyChanged(nameof(billUsage));
                }
            }
        }

        public List<WaterSavingTips> WaterSavingTips
        {
            get
            {
                return waterSavingTips;
            }
            set
            {
                if (waterSavingTips != value)
                {
                    waterSavingTips = value;
                    OnPropertyChanged(nameof(WaterSavingTips));
                }
            }
        }

        public List<NewsItem> NewsItems
        {
            get
            {
                return newsItems;
            }
            set
            {
                if (newsItems != value)
                {
                    newsItems = value;
                    OnPropertyChanged(nameof(NewsItems));
                }
            }
        }

        public string Link
        {
            get
            {
                return link;
            }
            set { }
        }

        public string DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                if (dueDate != value)
                {
                    dueDate = value;
                    OnPropertyChanged(nameof(DueDate));
                }
            }
        }

        public DashBoardViewModel()
        {
            usageData = App.Database.GetUsageAsync();
            billData = App.Database.GetBillAsync();
            usageData.Reverse();

            billData = App.Database.GetBillAsync();

            //For testing the payment function
            //adds in an unpaid bill
            //Also in bills page
            //--------------------------------------------------------------
            //billData[billData.Count - 1].PaidStatus = "unpaid";
            //App.Database.UpdateBillAsync(billData[billData.Count - 1]);
            //---------------------------------------------------------------

            unpaidBills = billData.Where(x => x.PaidStatus == "unpaid").ToList();

            if (unpaidBills.Count == 0)
            {
                IsLabelVisible = true;
                IsReminderVisible = false;
            }
            else
            {
                FormatBillData();
                IsReminderVisible = true;
                IsLabelVisible = false;
            }

            InitialiseTips();

            ParseRSS();
        }

        private List<FormattedUsage> FormatBillData()
        {

            string billingPeriod = usageData[2].ReadingDate.ToString("MMM \"'\"yy") + "-" +
                                usageData[0].ReadingDate.ToString("MMM \"'\"yy");

            string formatBillingPeriod = "Billing Period: "+ billingPeriod;

            double waterUsage = usageData[0].Amount + usageData[1].Amount + usageData[2].Amount;

            double billCost = unpaidBills[0].Amount;

            string formatDueDate = "Due On: ";

            dueDate = unpaidBills[0].DueDate.ToString(formatDueDate + "dd-MMM");


            FormattedUsage formattedUsage = new FormattedUsage(formatBillingPeriod, waterUsage, billCost);


            billUsage.Add(formattedUsage);


            return billUsage;
        }

        private void InitialiseTips()
        {
            /* Tips taken from: https://www.qld.gov.au/environment/water/residence/use/home */
            WaterSavingTips Tip1 = new WaterSavingTips()
            {
                TipID = 1,
                Title = "Laundry",
                Description = "Try not to use your washing machine every day. " +
                              "Instead, sort clothes and wash bigger loads less frequently.",
                ImageSource = ""
            };
            WaterSavingTips Tip2 = new WaterSavingTips()
            {
                TipID = 1,
                Title = "Kitchen",
                Description = "Use the dishwasher with a full load. Running a full load in a water-efficient " +
                               "dishwasher uses less water than washing dishes by hand.",

                ImageSource = ""
            };
            WaterSavingTips Tip3 = new WaterSavingTips()
            {
                TipID = 1,
                Title = "Bathroom",
                Description = "Install a water-efficient shower head. A WELS Scheme 3-star rated shower " +
                              "head will use no more than 9 litres of water per minute.",

                ImageSource = ""
            };
            WaterSavingTips Tip4 = new WaterSavingTips()
            {
                TipID = 1,
                Title = "Pool & Outdoors",
                Description = "Use a pool cover.A properly fitted pool cover can stop up to 97 % " +
                              "of evaporation and reduce the amount of chemicals required to treat the water.",

                ImageSource = ""
            };
            WaterSavingTips Tip5 = new WaterSavingTips()
            {
                TipID = 1,
                Title = "Leaks",
                Description = "A large amount of water around can be lost due to leaking pipes and dripping taps. " +
                              "One slowly dripping tap can waste 9,000 litres of water a year, while a visibly " +
                              "leaking toilet can waste more than 60,000 litres.",

                ImageSource = ""
            };

            waterSavingTips.Add(Tip1);
            waterSavingTips.Add(Tip2);
            waterSavingTips.Add(Tip3);
            waterSavingTips.Add(Tip4);
            waterSavingTips.Add(Tip5);
        }

        private void ParseRSS()
        {            
            SyndicationFeed feed = null;

            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("SWIM.Resources.rss_water.xml");

            try
            {
                using (var reader = XmlReader.Create(stream))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch (Exception) //Catch when feed is not available
            {
                error = "Could not fetch feed at this time. Visit: https://www.awe.gov.au/about/news to see the latest news.";
                IsErrorVisible = true;
            }

            if (feed != null)
            {

                foreach (var element in feed.Items)
                {
                    NewsItem newsItem = new NewsItem()
                    {
                        Title = element.Title.Text,
                        Description = element.Summary.Text,
                        Link = element.Links[0].Uri.ToString()                       
                    };

                    link = element.Links[0].Uri.ToString();

                    newsItems.Add(newsItem);
                }
            }         
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
              
}

