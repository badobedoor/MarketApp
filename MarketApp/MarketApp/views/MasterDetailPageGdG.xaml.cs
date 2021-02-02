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
    public partial class MasterDetailPageGdG : MasterDetailPage
    {
        public MasterDetailPageGdG()
        {
            InitializeComponent();

            Detail = new NavigationPage(new views.HomePage());





            //TapGestureRecognizer CategoriesBTNEvent = new TapGestureRecognizer();

            TapGestureRecognizer MyAccountBTNEvent = new TapGestureRecognizer();
            TapGestureRecognizer WishlistBTNEvent = new TapGestureRecognizer();
            TapGestureRecognizer HomeButtonEvent = new TapGestureRecognizer();
            TapGestureRecognizer MyAdressButtonEvent = new TapGestureRecognizer();
            TapGestureRecognizer MyOrderButtonEvent = new TapGestureRecognizer();

            //CategoriesBTNEvent.Tapped += (sender, e) =>
            //{
            //    var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
            //    ((mainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(new views.CategoriesPage());
            //    (mainPage as MasterDetailPage).IsPresented = false;
            //    //Navigation.PushAsync(new views.CategoriesPage());
            //};

            MyAccountBTNEvent.Tapped += (sender, e) =>
            {
                var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
                ((mainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(new views.CustomerProfilePage());
                (mainPage as MasterDetailPage).IsPresented = false;
                // Navigation.PushAsync(new views.CustomerProfilePage());
            };
            WishlistBTNEvent.Tapped += (sender, e) =>
            {
                var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
                ((mainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(new views.WishlistPage());
                (mainPage as MasterDetailPage).IsPresented = false;
                // Navigation.PushAsync(new views.WishlistPage());
            };
            HomeButtonEvent.Tapped += (sender, e) =>
            {
                var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
                ((mainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(new views.HomePage());
                (mainPage as MasterDetailPage).IsPresented = false;
                // Navigation.PushAsync(new views.HomePage());
            };
            MyAdressButtonEvent.Tapped += (sender, e) =>
            {
                var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
                ((mainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(new views.CustomerAddressPage());
                (mainPage as MasterDetailPage).IsPresented = false;
                // Navigation.PushAsync(new views.CustomerAddressPage());
            };
            MyOrderButtonEvent.Tapped += (sender, e) =>
            {
                var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
                ((mainPage as MasterDetailPage).Detail as NavigationPage).Navigation.PushAsync(new views.CartPage());
                (mainPage as MasterDetailPage).IsPresented = false;
                //Navigation.PushAsync(new views.CartPage());
            };

            //CategoriesBTN.GestureRecognizers.Add(CategoriesBTNEvent);

            MyAccountBTN.GestureRecognizers.Add(MyAccountBTNEvent);
            WishlistBTN.GestureRecognizers.Add(WishlistBTNEvent);
            HomeButton.GestureRecognizers.Add(HomeButtonEvent);
            MyAdressButton.GestureRecognizers.Add(MyAdressButtonEvent);
            MyOrderButton.GestureRecognizers.Add(MyOrderButtonEvent);

        }

    }


}
