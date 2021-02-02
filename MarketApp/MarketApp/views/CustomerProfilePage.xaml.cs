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
	public partial class CustomerProfilePage : ContentPage
	{
		public CustomerProfilePage ()
		{
			InitializeComponent ();
            //BindingContext = new ViewModels.MainViewModel();
            TapGestureRecognizer AdressNavgtionBTNevent = new TapGestureRecognizer();
            AdressNavgtionBTNevent.Tapped += (sender, e) =>
            {
                Navigation.PushAsync(new views.CustomerAddressPage());
            };
            AdressNavgation.GestureRecognizers.Add(AdressNavgtionBTNevent);
        }

        private void mnueBTN_Clicked(object sender, EventArgs e)
        {
            var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
            (mainPage as MasterDetailPage).IsPresented = true;
        }
    }
}