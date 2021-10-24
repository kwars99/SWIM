using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SWIM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWIM.Droid.CustomRenderer
{
    public class DisplayInfo : IDisplayInfo
    {
        public int GetDisplayWidth()
        {
            return (int)Android.App.Application.Context.Resources.DisplayMetrics.WidthPixels;
        }

        public int GetDisplayHeight()
        {
            return (int)Android.App.Application.Context.Resources.DisplayMetrics.HeightPixels;
        }

        public int GetDisplayDpi()
        {
            return (int)Android.App.Application.Context.Resources.DisplayMetrics.DensityDpi;
        }
    }
}