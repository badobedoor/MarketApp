using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketApp.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        
        
        public HomePage ()
		{
			InitializeComponent ();

           

            var i = 1;



            imagerrtt.Source = (String.Format("img_{0}.jpg", i));
            Device.StartTimer(TimeSpan.FromSeconds(7), () =>
            {
               if (i == 4)
               {
                    i = 1;
                    imagerrtt.Source = (String.Format("img_{0}.jpg", i));
               }
                imagerrtt.Source = (String.Format("img_{0}.jpg", i));
                                
                i++;
                
                return true;
            });



           // this.BindingContext = new ViewModels.MainViewModel();
        }

        private void mnueBTN_Clicked(object sender, EventArgs e)
        {
            
            var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
            (mainPage as MasterDetailPage).IsPresented = true;
            //(App.Current.MainPage as MasterDetailPage).IsPresented = true;            
        }

        private void wishlistBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new views.WishlistPage());
        }

        private void cartBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new views.CartPage());
        }


    }
}