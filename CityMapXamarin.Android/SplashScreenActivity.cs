
using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace CityMapXamarin.Android
{
    [Activity(MainLauncher = true, Icon = "@mipmap/ic_launcher_round", Theme = "@style/SplashTheme")]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
        public SplashScreenActivity() : base(Resource.Layout.activity_splash_screen)
        {
        }
    }
}