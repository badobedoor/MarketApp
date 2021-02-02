using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MarketApp.Helpers;
using MarketApp.Services;
using Xamarin.Forms;



namespace MarketApp.ViewModels
{
    class RegisterViewModel
    {
        private readonly DataServices _apiServices = new DataServices();
        

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isRegistered = await _apiServices.RegisterUserAsyncServices(Email, Password, ConfirmPassword);
                    
                    

                    Settings.Username = Username;
                    Settings.Password = Password;
                    Settings.Email = Email;
                    

                    if (isRegistered)
                     {
                        Message = "Success :)";
                        await App.Current.MainPage.Navigation.PushAsync(new views.loginPage());
                    }
                    else
                    {
                        Message = "Please try again :(";
                    }
                });
            }
        }
    }
}
