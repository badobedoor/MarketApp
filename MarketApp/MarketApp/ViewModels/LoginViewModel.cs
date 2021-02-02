using MarketApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MarketApp.Helpers;
using Xamarin.Forms;
using static MarketApp.Models.data;
using System.Linq;

namespace MarketApp.ViewModels
{
    class LoginViewModel
    {
        private readonly DataServices _apiServices = new DataServices();

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }

        public List<UserT> ListUser { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    DataServices _apiServices = new DataServices();

                    string accesstoken = await _apiServices.LoginAsyncServices(Email, Password);                    
                    string ApiUserID = await _apiServices.GetUserApiId(accesstoken);
                    Settings.AccessToken = accesstoken;
                    Settings.ApiUserID = ApiUserID;
                    Settings.Email = Email;
                    Settings.Password = Password ;

                    //var accesstokenString = new string(accesstoken.Where(c => !char.IsPunctuation(c)).ToArray());                    
                    //Settings.AccessTokenString = accesstokenString;
                    //من هنا نبدا 
                    //var userSearch = _apiServices.SearchUsersAsync(Settings.ApiUserID, accesstoken);

                    var User = (_apiServices.SearchUsersAsyncByID(ApiUserID,accesstoken)).Result;
                    if (User == null)
                    {
                        var userinformation = new UserT
                        {
                            UserID = ApiUserID,
                            UserName = Settings.Username,
                            Email = Email,
                            Password = Password
                            //UserApiID= ApiUserID,
                        };
                        
                        await _apiServices.PostUsersAsync(userinformation, accesstoken);                        
                        await App.Current.MainPage.Navigation.PushAsync(new views.MasterDetailPageGdG());
                    } 
                    else if (User.UserID == ApiUserID)
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new views.MasterDetailPageGdG());
                    }
                    else { var x = "Error"; }

                    #region Comment
                    //else if(User.Result.UserID == User.Result.UserName)
                    //{
                    //    var userinformation = new UserT
                    //    {                                                                        
                    //        UserApiID = ApiUserID
                    //    };
                    //    Settings.UserData = userinformation;
                    //    await _apiServices.PutUsersAsync(userinformation, accesstoken);
                    //    await App.Current.MainPage.Navigation.PushAsync(new views.MasterDetailPageGdG());
                    //}
                    //else
                    //// كده الشخص دا  عنده حاجه متسجل فى (اليوزر اى دي)بس الحاجة دى مش هى الامسس توكن (يعنى الشخص مسجل فى التطبيق )
                    ////ولا هى بردو بتساوى اليوزر نيم (يعنى الشخص عمل تجيل خروج )يبقى كده هيكون حالتو اى بالظبط ؟؟؟ 
                    ////الحالة الى لقتها ممكن تكون كده هى ان الشخص يكون عندة اكونت وبيحاول يدخل علية من تلفون مختلف بدون ما يعمل لوج اويت من التطبيق فى التلون الاول 
                    //{
                    //    var userinformation = new UserT
                    //    {
                    //        UserApiID = ApiUserID
                    //    };
                    //    Settings.UserData = userinformation;
                    //    await _apiServices.PutUsersAsync(userinformation, accesstoken);
                    //    await App.Current.MainPage.Navigation.PushAsync(new views.MasterDetailPageGdG());

                    //}
                    #endregion



                });
            }
        }

        public LoginViewModel()
        {
            AccessToken = Settings.AccessToken;
            Email = Settings.Email;
            Password = Settings.Password;
        }

    }
}

