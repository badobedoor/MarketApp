using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarketApp.ViewModels;
using static MarketApp.Models.data;
using MarketApp.Services;
using MarketApp.Models;

namespace MarketApp.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPagexaml : ContentPage
	{


        
        public SearchPagexaml ()
		{
            
            
			InitializeComponent ();
           


        }
        

       
            private void mnueBTN_Clicked(object sender, EventArgs e)
        {
            var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
            (mainPage as MasterDetailPage).IsPresented = true;
        }
    }
}