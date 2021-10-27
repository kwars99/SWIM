using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SWIM.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SavePDFUsingNative.Droid.SaveAndroid))]

namespace SavePDFUsingNative.Droid
{
    public class SaveAndroid : ISave
    {
        public string Save(MemoryStream stream)
        {
            string root = null;
            string fileName = "SavedDocument.pdf";
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                //root = Android.OS.Environment.ExternalStorageDirectory.ToString();
                root = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
            }
            Java.IO.File file = new Java.IO.File(root, fileName);
            string filePath = file.Path;
            if (file.Exists()) file.Delete();
            Java.IO.FileOutputStream outs = new Java.IO.FileOutputStream(file);
            outs.Write(stream.ToArray());
            var ab = file.Path;
            outs.Flush();
            outs.Close();
            return filePath;
        }
    }
}