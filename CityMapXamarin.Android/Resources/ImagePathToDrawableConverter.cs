using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;

namespace CityMapXamarin.Android.Resources
{
    public class ImagePathToDrawableConverter : MvxValueConverter<string, Drawable>
    {
        protected override Drawable Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Drawable image = null;
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(value);

                if (imageBytes.Length > 0)
                {
                    var decodedByte = BitmapFactory.DecodeByteArray(imageBytes,0,imageBytes.Length);
                    image = new BitmapDrawable(currentActivity.Resources, decodedByte);
                }          
            }
            return image;
        }
    }
}