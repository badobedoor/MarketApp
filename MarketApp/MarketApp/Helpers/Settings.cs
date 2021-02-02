// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using MarketApp.Models;

namespace MarketApp.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        
            public static string ApiUserID
        {
            get
            {

                return AppSettings.GetValueOrDefault<string>("ApiUserID");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("ApiUserID", value);
            }
        }
        //public static data.UserT UserData
        //{
        //    get
        //    {

        //        return AppSettings.GetValueOrDefault<data.UserT>("UserData");
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue<data.UserT>("UserData", value);
        //    }
        //}
        public static int CategorieID
        {
            get
            {

                return AppSettings.GetValueOrDefault<int>("CategorieID",1);
            }
            set
            {
                AppSettings.AddOrUpdateValue<int>("CategorieID", value);
            }
        }
        public static int ProdectID
        {
            get
            {

                return AppSettings.GetValueOrDefault<int>("ProdectID", 1);
            }
            set
            {
                AppSettings.AddOrUpdateValue<int>("ProdectID", value);
            }
        }
        public static string Username
        {
            get
            {
               
               return AppSettings.GetValueOrDefault<string>("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("Username", value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("Password", value);
            }
        }
        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("AccessToken", value);
            }
        }
        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("Email", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("Email", value);
            }
        }
        public static string AccessTokenString
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("AccessTokenString", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("AccessTokenString", value);
            }
        }
        
        public static DateTime AccessTokenExpirationDate
        {
            get
            {
                return AppSettings.GetValueOrDefault<DateTime>("AccessTokenExpirationDate", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue<DateTime>("AccessTokenExpirationDate", value);
            }
        }
        public static string PageIconColor
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>("PageIconColor", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>("PageIconColor", value);
            }
        }
    }
}