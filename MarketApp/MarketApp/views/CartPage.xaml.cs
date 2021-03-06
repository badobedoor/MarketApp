﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketApp.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentPage
	{
		public CartPage ()
		{
			InitializeComponent ();

           
        }


        private void CheckoutBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new views.CheckoutPage());
        }

        private void mnueBTN_Clicked(object sender, EventArgs e)
        {
            var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
            (mainPage as MasterDetailPage).IsPresented = true;
        }
    }
}