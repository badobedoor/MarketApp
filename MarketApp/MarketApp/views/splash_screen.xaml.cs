using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MarketApp.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class splash_screen : ContentPage
    {
		public splash_screen ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 3000);
            //await splashImage.ScaleTo(0.9, 1000);
            //await splashImage.ScaleTo(150, 1200);

            Application.Current.MainPage = new NavigationPage(new views.MasterDetailPageGdG());
        }
    }
}