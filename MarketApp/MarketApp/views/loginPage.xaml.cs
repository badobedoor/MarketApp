using Rg.Plugins.Popup.Services;
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
	public partial class loginPage : ContentPage
	{
		public loginPage ()
		{
			InitializeComponent ();

            //TapGestureRecognizer SignUpButtonEvent = new TapGestureRecognizer();
            //TapGestureRecognizer GoBttonEvent = new TapGestureRecognizer();

            //SignUpButtonEvent.Tapped += (sender, e) =>
            //{
            //    Navigation.PushAsync(new views.sinUpPage());
            //};
            //GoBttonEvent.Tapped += (sender, e) =>
            //{
            //    Navigation.PushAsync(new views.MasterDetailPageGdG());
            //};

            //SignUpButton.GestureRecognizers.Add(SignUpButtonEvent);
           // GoBtton.GestureRecognizers.Add(GoBttonEvent);
        }


        private void Nav_To_SignUpPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new views.sinUpPage());
        }
    }
}