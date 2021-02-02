using System;
using System.Windows;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamd.ImageCarousel.Forms.Plugin.Droid;
using FFImageLoading.Forms.Platform;
using Syncfusion;


namespace MarketApp.Droid
{

    //[Activity(Label = "MarketApp", Icon = "@mipmap/En", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Activity(
        Label = "MarketApp",
        Icon = "@mipmap/En" ,
         Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            CachedImageRenderer.Init(enableFastRenderer: true );
            
            CachedImageRenderer.InitImageViewHandler();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            ImageCarouselRenderer.Init();
            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Syncfusion.XForms.Android.PopupLayout.SfPopupLayoutRenderer.Init();

            LoadApplication(new App());

        }
        private void StoreLogger(object sender, RaiseThrowableEventArgs e)
        {
            Console.WriteLine(e.Exception);
        }
        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                // Do something if there are some pages in the `PopupStack`
            }
            else
            {
                // Do something if there are not any pages in the `PopupStack`
            }
        }
    }
}

