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
	public partial class CheckoutPage : ContentPage
	{
		public CheckoutPage ()
		{
			InitializeComponent ();
            ac.ItemsSource = new List<preson>
            {            
                new preson
                {
                    name="Mator",
                    imgclass ="mm_1.jpg"
                },
                new preson
                {
                    name="Baby and Health and Health",
                    imgclass ="mm_3.jpg"
                },
                new preson
                {
                    name="Teravel",
                    imgclass ="mm_2.jpg"
                },
                new preson
                {
                    name="Dring",
                    imgclass ="mm_4.jpg"
                },
                
            };
        }

        private void mnueBTN_Clicked(object sender, EventArgs e)
        {
            var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
            (mainPage as MasterDetailPage).IsPresented = true;
        }
    }
}