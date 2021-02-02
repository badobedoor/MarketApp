using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarketApp.Helpers;
using MarketApp.ViewModels;
using MarketApp.views;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MarketApp
{
	public partial class App : Application
	{

        public App ()
		{
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc0MjkwQDMxMzgyZTMxMmUzMFhSaXlmOXZnVzYxcW1hU09Fb2dLMG1GYlBhdWlPYW1SYUVKQkoyWGJ0dmM9");
            InitializeComponent();
                      
            SetMainPage();

            // MainPage = new NavigationPage(new Page1()); 
            // MainPage = new NavigationPage(new views.sinUpPage());
            //MainPage = new views.MasterDetailPageGdG();

        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                //MainPage = new NavigationPage(new sinUpPage()); 
                
                MainPage = new NavigationPage(new views.HomePage());
                //MainViewModel model = new MainViewModel();
                //BindingContext = model;
                //model.changeIconecolor("Home");
                //MainPage = new NavigationPage(new loginPage());
            }
            else if (!string.IsNullOrEmpty(Settings.Email)&& !string.IsNullOrEmpty(Settings.Password))
            {
                //MainPage = new NavigationPage(new sinUpPage()); 
                MainPage = new NavigationPage(new loginPage());
            }
            else
            {
                MainPage = new NavigationPage(new sinUpPage());
            }
        }
        //if (Settings.AccessTokenExpirationDate < DateTime.UtcNow.AddHours(1))
        //{
        //    var loginViewModel = new LoginViewModel();
        //    loginViewModel.LoginCommand.Execute(null);
        //}
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
