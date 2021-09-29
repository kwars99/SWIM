using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWIM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfPage : ContentPage
    {
        public PdfPage()
        {
            InitializeComponent();

            //Set Toolbar Items
            pdfViewerControl.Toolbar.SetToolbarItemVisibility("page-view-mode", false);
            pdfViewerControl.Toolbar.SetToolbarItemVisibility("bookmark", false);
            pdfViewerControl.Toolbar.SetToolbarItemVisibility("search", false);
            pdfViewerControl.Toolbar.SetToolbarItemVisibility("undo", false);
            pdfViewerControl.Toolbar.SetToolbarItemVisibility("redo", false);
            pdfViewerControl.Toolbar.SetToolbarItemVisibility("annotation", false);
        }
    }
}