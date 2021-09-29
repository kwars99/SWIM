using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SWIM.Models;
using SWIM.Services;
using Syncfusion.SfPdfViewer.XForms;
using Xamarin.Forms;

namespace SWIM.ViewModels
{
    public class PdfViewerModel : INotifyPropertyChanged
    {
        private Stream m_pdfDocumentStream;
        private Command<object> saveCommand;
        private Command<object> printCommand;

        public Command<object> SaveCommand
        {
            get { return saveCommand; }
            protected set { saveCommand = value; }
        }

        public Command<object> PrintCommand
        {
            get { return printCommand; }
            protected set { printCommand = value; }
        }

        /// <summary>
        /// An event to detect the change in the value of a property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The PDF document stream that is loaded into the instance of the PDF viewer. 
        /// </summary>
        public Stream PdfDocumentStream
        {
            get
            {
                return m_pdfDocumentStream;
            }
            set
            {
                m_pdfDocumentStream = value;
                NotifyPropertyChanged("PdfDocumentStream");
            }
        }

        /// <summary>
        /// Constructor of the view model class
        /// </summary>
        public PdfViewerModel()
        {
            //Accessing the PDF document that is added as embedded resource as stream.
            m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SWIM.Resources.sample_bill.pdf");
            saveCommand = new Command<object>(OnDocumentSaved);
            //printCommand = new Command<object>(OnDocumentPrint);
            
        }

        private void OnDocumentSaved(object obj)
        {
            Stream strm = (obj as DocumentSaveInitiatedEventArgs).SaveStream;
            string filePath = DependencyService.Get<ISave>().Save(strm as MemoryStream);
            string message = "The PDF has been saved to " + filePath;
            DependencyService.Get<IAlertView>().Show(message);
        }

        /*
        private void OnDocumentPrint(object obj)
        {
            Stream stream = //What to put here
            DependencyService.Get<IPrintService>().Print(stream, "sample_bill.pdf");
        }
        */

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
