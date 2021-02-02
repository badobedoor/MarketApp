using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using Foundation;
using UIKit;
using Xamd.ImageCarousel.Forms.Plugin.iOS;

namespace MarketApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.

            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();
            ImageCarouselRenderer.Init();
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
