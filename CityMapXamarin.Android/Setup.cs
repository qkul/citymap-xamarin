using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.AppCompat.Target;
using MvvmCross.Logging;

namespace CityMapXamarin.Android
{
    public class Setup : MvxAppCompatSetup<App>
    {
        //public override MvxLogProviderType GetDefaultLogProviderType()
        //    => MvxLogProviderType.Serilog;

    }
}