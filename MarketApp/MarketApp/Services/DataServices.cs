using MarketApp.Models;
using Newtonsoft.Json;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MarketApp.Helpers;
using Newtonsoft.Json.Linq;
using static MarketApp.Models.data;

namespace MarketApp.Services
{
    class DataServices
    {
        //private const string publicUrl = "http://192.168.225.2:4040/";


        #region User Services with accessToken --------------------------------------------------------------------
        public async Task<List<data.UserT>> GetUsersAsync(string accessToken)
        {
            RestClient<data.UserT> restClient = new RestClient<data.UserT>();
            var userInformation = await restClient.GetAsyncUser(accessToken);

            return userInformation;
        }
        public async Task<data.UserT> SearchUsersAsyncByID(string userapiId, string accessToken)
        {
            RestClient<data.UserT> restClient = new RestClient<data.UserT>();
            var userInformation = await restClient.GetAsyncUserByID(userapiId, accessToken);
            if (userInformation != null)
            {
                return userInformation;
            }
            else { return null; }


        }
        public async Task<string> GetUserApiId(string accessToken)
        {
            RestClient<string> restClient = new RestClient<string>();
            var userApiID = await restClient.GetUserApiId(accessToken);
            //بص يا سيدى عاوزين نحط دالة  تبحث عن الاكسس توكن لو موجود يبقى مضفش الشخص لو مش موجود يبقى تضيف الشخص 


            return userApiID;
        }

        #region Comment
        //public async Task<data.UserT> SearchEmailansPasswordUserAsync(string email, string pasword, string accessToken)
        //{
        //    RestClient<data.UserT> restClient = new RestClient<data.UserT>();
        //    var userInformation = await restClient.SearchEmailandPasswordUser(email, pasword, accessToken);
        //    return userInformation;

        //}
        //public async Task<List<data.UserT>> SearchUsersAsync(string Username, string Password, string accessToken)
        //{
        //    //عاوز اعمل دالتين فى نفس الدالة بحيث يبحث لو فى اميل يبقى يبحث عن الباسورد 
        //    var httpClient = new HttpClient();

        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer ", accessToken);
        //    var json = await httpClient.GetStringAsync(publicUrl + "api/Users/Search/Password/" + Password);

        //    var userInformation = JsonConvert.DeserializeObject<List<data.UserT>>(json);
        //    if (userInformation == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        json = await httpClient.GetStringAsync(publicUrl + "api/Users/Search/Email/" + Username);
        //        userInformation = JsonConvert.DeserializeObject<List<data.UserT>>(json);
        //        return userInformation;
        //    }


        //}


        //public async Task<List<data.UserT>> SearchUsersAsync( string Email,string Password, string accessToken)
        //{
        //    //عاوز اعمل دالتين فى نفس الدالة بحيث يبحث لو فى اميل يبقى يبحث عن الباسورد 
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //    var json = await httpClient.GetStringAsync(publicUrl + "api/Users/Search/Email/" + Email);

        //    var userInformation = JsonConvert.DeserializeObject<List<data.UserT>>(json);
        //    if (userInformation == null)
        //    {
        //        return userInformation;
        //    }
        //    else
        //    {
        //        httpClient = new HttpClient();
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //        json = await httpClient.GetStringAsync(publicUrl + "api/Users/Search/Password/" + Password);

        //        userInformation = JsonConvert.DeserializeObject<List<data.UserT>>(json);
        //        return userInformation;
        //    }


        //}
        #endregion

        public async Task<bool> PostUsersAsync(data.UserT userInformation, string accessToken)
        {
            RestClient<data.UserT> restClient = new RestClient<data.UserT>();
            var userInformationdata = await restClient.PostAsyncUser(userInformation, accessToken);
            return userInformationdata;
        }
        public async Task PutUsersAsync(data.UserT userInformation, string accessToken)
        {
            RestClient<data.UserT> restClient = new RestClient<data.UserT>();
            var result = await restClient.PutAsyncUser(userInformation.UserID, userInformation, accessToken);


        }

        public async Task DeletaUsersAsync(data.UserT userInformation, string accessToken)
        {
            RestClient<data.UserT> restClient = new RestClient<data.UserT>();
            var result = await restClient.DeleteAsyncUser(userInformation.UserID, accessToken);


        }
        #endregion

        #region RegisterUser --------------------------------------------------------------------

        public async Task<bool> RegisterUserAsyncServices(string email, string password, string confirmPassword)
        {
            RestClient<data.RegisterBindingModel> restClient = new RestClient<data.RegisterBindingModel>();
            var response = await restClient.RegisterUserAsync(email, password, confirmPassword);

            return response;


        }
        #endregion

        #region LoginUser --------------------------------------------------------------------
        public async Task<string> LoginAsyncServices(string Email, string password)
        {
            RestClient<data.RegisterBindingModel> restClient = new RestClient<data.RegisterBindingModel>();
            var accessToken = await restClient.LoginAsync(Email, password);


            return accessToken;
        }
        #endregion

        #region Product --------------------------------------------------------------------
        public async Task<List<data.prodectData>> GetProduct(string accessToken)
        {

            RestClient<data.prodectData> restClient = new RestClient<data.prodectData>();
            var prodectslist = await restClient.GetAsyncprodects(accessToken);
            return prodectslist;
        }

        public async Task<List<data.vWProdectTByCategorieT>> SearchProductsByCategorie(int CategID, string accessToken)
        {

            RestClient<data.vWProdectTByCategorieT> restClient = new RestClient<data.vWProdectTByCategorieT>();
            var prodectslist = await restClient.GetAsyncvWProdectTBySelectedCategorieT(CategID, accessToken);
            return prodectslist;
        }

        public async Task<data.vWImageTByProdectT> GetvWImageTByProdectTSelected(int proID, string accessToken)
        {

            RestClient<data.vWImageTByProdectT> restClient = new RestClient<data.vWImageTByProdectT>();
            var prodectslist = await restClient.GetAsyncvWImageTByProdectTSelected(proID, accessToken);
            if (prodectslist != null)
            {
                return prodectslist;
            }
            else
            {
                return null;
            }
            
        }
        #endregion

        #region Categories with accessToken --------------------------------------------------------------------
        public async Task<List<data.Categoriesdata>> GetCategories(string accessToken)
        {
            RestClient<data.Categoriesdata> restClient = new RestClient<data.Categoriesdata>();
            var Categorieslist = await restClient.GetAsyncCategories(accessToken);

            return Categorieslist;
        }
        public async Task PostCategories(data.Categoriesdata Categories, string accessToken)
        {
            RestClient<data.Categoriesdata> restClient = new RestClient<data.Categoriesdata>();
            var result = await restClient.PostAsyncCategories(Categories, accessToken);


        }
        public async Task PutCategories(data.Categoriesdata Categories, string accessToken)
        {
            RestClient<data.Categoriesdata> restClient = new RestClient<data.Categoriesdata>();
            var result = await restClient.PutAsyncCategories(Categories.CategorieID, Categories, accessToken);


        }
        public async Task DeletaCategories(data.Categoriesdata Categories, string accessToken)
        {
            RestClient<data.Categoriesdata> restClient = new RestClient<data.Categoriesdata>();
            var result = await restClient.DeleteAsyncCategories(Categories.CategorieID, accessToken);


        }
        #endregion

        #region vWCategorieByImageData--------------------------------------------------------------------

        public async Task<List<data.vWCategorieByImageData>> GetvWCategorieByImageData(string accessToken)
        {

            RestClient<data.vWCategorieByImageData> restClient = new RestClient<data.vWCategorieByImageData>();
            var vWCategorieByImageDatalist = await restClient.GetAsyncvWCategorieByImage(accessToken);

            return vWCategorieByImageDatalist;
        }
        #endregion

        #region Imagedata --------------------------------------------------------------------
        public async Task<List<data.Imagedata>> GetImagedata(string accessToken)
        {
            RestClient<data.Imagedata> restClient = new RestClient<data.Imagedata>();
            var Imagedatalist = await restClient.GetAsyncImageTs(accessToken);

            return Imagedatalist;
        }
        #endregion
        
        #region View_Favoriteproducts --------------------------------------------------------------------
        public async Task<List<data.vWFavoriteProduct>> GetFavoriteproductsData(string userId,string accessToken)
        {

            RestClient<data.vWFavoriteProduct> restClient = new RestClient<data.vWFavoriteProduct>();
            var Favoriteproduct = await restClient.GetAsyncFavoriteproducts(userId, accessToken);

            if (Favoriteproduct != null)
            {                
                return Favoriteproduct;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<bool> PostFavoriteproductsAsync(data.FavoriteProduct Favoriteproducts, string accessToken)
        {

            RestClient<data.FavoriteProduct> restClient = new RestClient<data.FavoriteProduct>();
            var userInformationdata = await restClient.PostAsyncFavoriteproducts(Favoriteproducts, accessToken);
            return userInformationdata;
        }
        public async Task DeleteFavoriteproducts(int prodectid, string userid, string accessToken)
        {
            RestClient<data.FavoriteProduct> restClient = new RestClient<data.FavoriteProduct>();
            var result = await restClient.DeleteAsyncFavoriteproducts(prodectid, userid, accessToken);


        }

        #endregion

        #region Cart --------------------------------------------------------------------
        public async Task<List<data.vWCart>> GetCartsData(string userId, string accessToken)
        {

            RestClient<data.vWCart> restClient = new RestClient<data.vWCart>();
            var Cart = await restClient.GetAsyncCarts(userId, accessToken);

            if (Cart != null)
            {
                return Cart;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> PostCartsAsync(data.Cart cartdata, string accessToken)
        {

            RestClient<data.Cart> restClient = new RestClient<data.Cart>();
            var userInformationdata = await restClient.PostAsyncCarts(cartdata, accessToken);
            return userInformationdata;
        }
        public async Task DeleteCarts(int prodectid, string userid, string accessToken)
        {
            RestClient<data.Cart> restClient = new RestClient<data.Cart>();
            var result = await restClient.DeleteAsyncCarts(prodectid, userid, accessToken);


        }
        public async Task PutCarts(int prodectid, string userid, data.Cart cartdata, string accessToken)
        {
            RestClient<data.Cart> restClient = new RestClient<data.Cart>();
            var result = await restClient.PutAsyncCarts(prodectid, userid, cartdata, accessToken);


        }

        #endregion





        #region data with  accessToken --------------------------------------------------------------------
        //   public async Task<List<Idea>> SearchIdeasAsync(string keyword, string accessToken)
        //   {
        //       var client = new HttpClient();
        //       client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        //           "Bearer", accessToken);
        //       var json = await client.GetStringAsync(
        //Constants.BaseApiAddress + "api/ideas/Search/" + keyword);

        //       var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);

        //       return ideas;
        //   }
        #endregion

        //public async Task<bool> RegisterUserAsyncServices(string email, string password, string confirmPassword)
        //{
        //    RestClient<data.RegisterBindingModel> restClient = new RestClient<data.RegisterBindingModel>();
        //    var result = await restClient.RegisterUserAsync(email,  password,  confirmPassword);

        //    return result;

        //}


    }
}

#region comment Old Page
//using MarketApp.Models;
//using Newtonsoft.Json;
//using Plugin.RestClient;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using MarketApp.Helpers;
//using Newtonsoft.Json.Linq;

//namespace MarketApp.Services
//{
//    class DataServices         
//    {
//        private const string publicUrl = "http://192.168.1.5:4040/";
//        #region Product
//        public async Task<List<data.prodectData>> GetProduct(string accessToken)
//        {

//            RestClient<data.prodectData> restClient = new RestClient<data.prodectData>();
//            var prodectslist = await restClient.GetAsyncprodects(accessToken);
//            return prodectslist;
//        }
//        #endregion

//        #region Categories with accessToken
//        public async Task<List<data.Categoriesdata>> GetCategories(string accessToken)
//        {
//            RestClient<data.Categoriesdata> restClient = new RestClient<data.Categoriesdata>();
//            var Categorieslist = await restClient.GetAsyncCategories(accessToken);

//            return Categorieslist;
//        }
//        public async Task PostCategories(data.Categoriesdata Categories, string accessToken)
//        {
//            RestClient<data.Categoriesdata> restClient = new RestClient<data.Categoriesdata>();
//            var result = await restClient.PostAsyncCategories(Categories,accessToken);


//        }


//        public async Task PutCategories(data.Categoriesdata Categories, string accessToken)
//        {
//            RestClient<data.Categoriesdata> restClient = new RestClient<data.Categoriesdata>();
//            var result = await restClient.PutAsyncCategories(Categories.CategorieID, Categories, accessToken);


//        }

//        public async Task DeletaCategories(data.Categoriesdata Categories, string accessToken)
//        {
//            RestClient<data.Categoriesdata> restClient = new RestClient<data.Categoriesdata>();
//            var result = await restClient.DeleteAsyncCategories(Categories.CategorieID, accessToken);


//        }
//        #endregion
//        #region Imagedata
//        public async Task<List<data.Imagedata>> GetImagedata(string accessToken)
//        {
//            RestClient<data.Imagedata> restClient = new RestClient<data.Imagedata>();
//            var Imagedatalist = await restClient.GetAsyncImageTs(accessToken);

//            return Imagedatalist;
//        }
//        #endregion
//        #region vWCategorieByImageData

//        public async Task<List<data.vWCategorieByImageData>> GetvWCategorieByImageData(string accessToken)
//        {

//            RestClient<data.vWCategorieByImageData> restClient = new RestClient<data.vWCategorieByImageData>();
//            var vWCategorieByImageDatalist = await restClient.GetAsyncvWCategorieByImage(accessToken);            

//            return vWCategorieByImageDatalist;
//        }
//        #endregion

//        #region Sinpup&User
//        public async Task<List<data.UserT>> GetAllUserData(string accessToken)
//        {

//            RestClient<data.UserT> restClient = new RestClient<data.UserT>();
//            var AllUserDatalist = await restClient.GetAsyncUser(accessToken);
//            return AllUserDatalist;
//        }

//        public async Task postUser(data.UserT userD)
//        {

//            RestClient<data.UserT> restClient = new RestClient<data.UserT>();
//            var UserTDatalist = await restClient.PostAsyncUser(userD);

//        }

//        public async Task postsinupAsync(string email, string userName, string password)
//        {

//            RestClient<data.UserT> restClient = new RestClient<data.UserT>();
//            var userSinUp = await restClient.PostAsyncSinupUser(email, userName, password);
//        }
//        #endregion
//        #region data with  accessToken
//        //   public async Task<List<Idea>> SearchIdeasAsync(string keyword, string accessToken)
//        //   {
//        //       var client = new HttpClient();
//        //       client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
//        //           "Bearer", accessToken);
//        //       var json = await client.GetStringAsync(
//        //Constants.BaseApiAddress + "api/ideas/Search/" + keyword);

//        //       var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);

//        //       return ideas;
//        //   }
//        #endregion

//        //public async Task<bool> RegisterUserAsyncServices(string email, string password, string confirmPassword)
//        //{
//        //    RestClient<data.RegisterBindingModel> restClient = new RestClient<data.RegisterBindingModel>();
//        //    var result = await restClient.RegisterUserAsync(email,  password,  confirmPassword);

//        //    return result;

//        //}
//        private const string RegisterUserWebServiceUrl = publicUrl + "api/Account/Register";
//        private const string NewUserWebServiceUrl = publicUrl + "api/users/";        
//        public async Task<bool> RegisterUserAsyncServices(string email, string password, string confirmPassword)
//        {
//            #region Register-User-in-Account-Control
//            var client = new HttpClient();
//            var model = new data.RegisterBindingModel
//            {
//                Email = email,
//                Password = password,
//                ConfirmPassword = confirmPassword
//            };

//            var json = JsonConvert.SerializeObject(model);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var response = await client.PostAsync(RegisterUserWebServiceUrl, httpContent);
//            #endregion



//            if (response.IsSuccessStatusCode)
//            {
//                //var LoginUser = ListUser.Find(x => x.Email.ToString().Contains(email));                
//                //var pas = ListUser.Find(x => x.Password.ToString().Contains(password));

//                #region Register-User-in-users-Control
//                var user = new data.UserT
//                {
//                    Email = email,
//                    Password = password
//                };

//                json = JsonConvert.SerializeObject(user);

//                httpContent = new StringContent(json);

//                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//                response = await client.PostAsync(NewUserWebServiceUrl, httpContent);
//                #endregion

//                return true;

//            }

//            return false;

//        }
//        public async Task<string> LoginAsyncServices(string Email, string password)
//        {
//            RestClient<data.RegisterBindingModel> restClient = new RestClient<data.RegisterBindingModel>();
//            var accessToken = await restClient.LoginAsync(Email, password);

//            return accessToken;

//        }
//    }
//}
#endregion

