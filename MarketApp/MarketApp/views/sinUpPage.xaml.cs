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
	public partial class sinUpPage : ContentPage
	{
		public sinUpPage ()
		{
			InitializeComponent ();
		}

        private void Nav_To_LogInPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new views.loginPage());
        }
    }
}