using System;
using System.Collections.Generic;
using System.Linq;
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
            var decodedByte = BitmapFactory.DecodeFile($"{currentActivity.FilesDir}/{value}");
            image = new BitmapDrawable(currentActivity.Resources, decodedByte);

            return image;
        }
    }
}