using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MarketApp.Models;
using Newtonsoft.Json;
using Plugin.RestClient;
using System.Collections.ObjectModel;
using System.Text;
using System.Diagnostics;
using MarketApp.Helpers;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using ModernHttpClient;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T> : INotifyPropertyChanged
    {
        private const string publicUrl = "http://192.168.1.4:4444/";



        #region prodects -----------------------------------------------------------------------------------
        private const string prodectsWebServiceUrl = publicUrl + "api/prodects/";
        public async Task<List<T>> GetAsyncprodects(string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = httpClient.GetStringAsync(prodectsWebServiceUrl).GetAwaiter().GetResult(); 

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;

        }

        public async Task<bool> PostAsyncprodects(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(prodectsWebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsyncprodects(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(prodectsWebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsyncprodects(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(prodectsWebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }
        #endregion

        #region Categories ----------------------------------------------------------------------------------- 
        //Start Categories RestClient
        private const string CategoriesWebServiceUrl = publicUrl + "api/Categories/";

        public async Task<List<T>> GetAsyncCategories(string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json =  httpClient.GetStringAsync(CategoriesWebServiceUrl).GetAwaiter().GetResult(); ;

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<bool> PostAsyncCategories(T t, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(CategoriesWebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsyncCategories(int id, T t, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(CategoriesWebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsyncCategories(int id, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await httpClient.DeleteAsync(CategoriesWebServiceUrl + id);
            return response.IsSuccessStatusCode;
        }

        #endregion


        #region Images -----------------------------------------------------------------------------------


        //Start Images RestClient
        private const string ImageTsWebServiceUrl = publicUrl + "api/ImageTs/";

        public async Task<List<T>> GetAsyncImageTs(string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json =  httpClient.GetStringAsync(ImageTsWebServiceUrl).GetAwaiter().GetResult(); ;

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<bool> PostAsyncImageTs(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(ImageTsWebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsyncImageTs(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(ImageTsWebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsyncImageTs(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(ImageTsWebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }


        #endregion


        #region ProdectT_By_CategorieT -----------------------------------------------------------------------------------

        //Start vWProdectTByCategorieT RestClient
        private const string vWProdectTByCategorieTWebServiceUrl = publicUrl + "api/vWProdectTByCategorieT/";

        public async Task<List<T>> GetAsyncvWProdectTByCategorieT(string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json =  httpClient.GetStringAsync(vWProdectTByCategorieTWebServiceUrl).GetAwaiter().GetResult(); ;

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }
        public async Task<List<T>> GetAsyncvWProdectTBySelectedCategorieT(int CategID, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = httpClient.GetStringAsync(publicUrl + "api/SearchProductsByCategorie/" + CategID).GetAwaiter().GetResult(); ;

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<data.vWImageTByProdectT> GetAsyncvWImageTByProdectTSelected(int proID, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = httpClient.GetAsync(publicUrl + "api/vWImageTByProdectT/" + proID).GetAwaiter().GetResult(); ;
            if (json.IsSuccessStatusCode)
            {                
                var taskModels = JsonConvert.DeserializeObject<data.vWImageTByProdectT>(json.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                return taskModels;

            }
            else
            {
                return null;
            }

        }



        #region Comment ---------------------
        //public async Task<bool> PostAsyncvWProdectTByCategorieT(T t)
        //{
        //    var httpClient = new HttpClient();

        //    var json = JsonConvert.SerializeObject(t);

        //    HttpContent httpContent = new StringContent(json);

        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var result = await httpClient.PostAsync(vWProdectTByCategorieTWebServiceUrl, httpContent);

        //    return result.IsSuccessStatusCode;
        //}

        //public async Task<bool> PutAsyncvWProdectTByCategorieT(int id, T t)
        //{
        //    var httpClient = new HttpClient();

        //    var json = JsonConvert.SerializeObject(t);

        //    HttpContent httpContent = new StringContent(json);

        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var result = await httpClient.PutAsync(vWProdectTByCategorieTWebServiceUrl + id, httpContent);

        //    return result.IsSuccessStatusCode;
        //}

        //public async Task<bool> DeleteAsyncvWProdectTByCategorieT(int id, T t)
        //{
        //    var httpClient = new HttpClient();

        //    var response = await httpClient.DeleteAsync(vWProdectTByCategorieTWebServiceUrl + id);

        //    return response.IsSuccessStatusCode;
        //}
        #endregion

        #endregion

        #region Categorie_By_Image -----------------------------------------------------------------------------------
        //Start vWCategorieByImage RestClient
        private const string vWCategorieByImageWebServiceUrl = publicUrl + "api/vWCategorieByImage/";

        public async Task<List<T>> GetAsyncvWCategorieByImage(string accessToken)
        {            
            HttpClient httpClient = new HttpClient(new NativeMessageHandler());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = httpClient.GetStringAsync(vWCategorieByImageWebServiceUrl).GetAwaiter().GetResult();

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }


        public async Task<bool> PutAsyncvWCategorieByImage(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result =  httpClient.PutAsync(vWCategorieByImageWebServiceUrl + id, httpContent).GetAwaiter().GetResult(); ;

            return result.IsSuccessStatusCode;
        }

        #endregion


        #region User -----------------------------------------------------------------------------------
        //Start Categories RestClient
        private const string UserWebServiceUrl = publicUrl + "api/Users/";

        public async Task<List<T>> GetAsyncUser(string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json =  httpClient.GetStringAsync(UserWebServiceUrl).GetAwaiter().GetResult(); ;

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;

        }
        public async Task<data.UserT> GetAsyncUserByID(string id,string accessToken)
        {
           // id = "1024";
            //var e = DeleteAsyncUser( id,  accessToken);

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json =  httpClient.GetAsync(UserWebServiceUrl + id).GetAwaiter().GetResult();            //السطر دا الى كان بيعمل الالرور بس حاليا لما بتكتب بالطريقة دى مش هيكون في اى ارورو منه             
            //هنا بيضرب زى كل مرة والضرب بيكون عشان الاستقبال غلط  
            var taskModels = JsonConvert.DeserializeObject<data.UserT>(json.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            if (json.IsSuccessStatusCode)
            {
                return taskModels;
               
            }
            else
            {
                return null;
            }
            

        }
        #region false search fontions
        //public async Task<T> SearchAsyncUser(string keyword, string accessToken)
        //{
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //    try
        //    {
        //        var json = await httpClient.GetStringAsync(publicUrl + "api/UserCredentials/UserApiID=" + keyword);//التطبيق بيقفل هنا 
        //        var taskModels = JsonConvert.DeserializeObject<T>(json);
        //        return taskModels;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("ERROR!" + ex.ToString());
        //        var json = await httpClient.GetStringAsync(publicUrl + "api/UserCredentials/UserApiID/" + keyword);
        //        var taskModels = JsonConvert.DeserializeObject<T>(json);
        //        return taskModels;
        //    }
        //}
        //public async Task<T> SearchEmailandPasswordUser(string email, string pasword, string accessToken)
        //{
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //    var json = await httpClient.GetAsync(publicUrl + "api/UserCredentials/email=" + "ans@gmail.com" + "/pasword=" + "18527");//code crashes her 
        //    var x = "jbvhj";
        //    var taskModels = JsonConvert.DeserializeObject<T>(json.Content.ToString());
        //    return taskModels;
        //}
        #endregion


        public async Task<bool> PostAsyncUser(T t, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(t);
            try
            {
                var result = await client.PostAsync(publicUrl + "api/Users", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                return result.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }
            
            //return result.IsSuccessStatusCode;            
        }

        public async Task<bool> PutAsyncUser(string id, T t, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(t);
            var result = await httpClient.PutAsync(UserWebServiceUrl + id, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;


        }

        public async Task<bool> DeleteAsyncUser(string id, string accessToken)
        {
            HttpClient httpClient = new HttpClient(new NativeMessageHandler());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await httpClient.DeleteAsync(UserWebServiceUrl + id);

            return response.IsSuccessStatusCode;


        }
        #endregion

        #region View_Favoriteproducts -----------------------------------------------------------------------------------
        //Start View_Favoriteproducts RestClient
        private const string FavoriteproductsWebServiceUrl = publicUrl + "api/FavoriteProducts/";

        public async Task<List<T>> GetAsyncFavoriteproducts(string userid ,string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = httpClient.GetStringAsync(publicUrl + "api/vWFavoriteProductsController/" + userid).GetAwaiter().GetResult();

            if (json!=null)
            {

                var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

                return taskModels;
            }
            else
            {
                return null;
            }


        }
    

        public async Task<bool> PostAsyncFavoriteproducts(T t, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(t);
            try
            {
                var result = await client.PostAsync(FavoriteproductsWebServiceUrl, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                return result.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }

            //return result.IsSuccessStatusCode;            
        }


        public async Task<bool> DeleteAsyncFavoriteproducts(int prodectid,string userid, string accessToken)
        {
            HttpClient httpClient = new HttpClient(new NativeMessageHandler());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await httpClient.DeleteAsync(publicUrl +"api/FavoriteProductscontroller/"+ prodectid +"/"+ userid);

            return response.IsSuccessStatusCode;


        }

        #region comment
        //public async Task<data.vWFavoriteProduct> GetAsyncFavoriteproductsID(string id, string accessToken)
        //{

        //    HttpClient httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //    var json = httpClient.GetAsync(publicUrl+ "api/vWFavoriteProductsController/"+ id).GetAwaiter().GetResult();            //السطر دا الى كان بيعمل الالرور بس حاليا لما بتكتب بالطريقة دى مش هيكون في اى ارورو منه             
        //    //هنا بيضرب زى كل مرة والضرب بيكون عشان الاستقبال غلط  
        //    var taskModels = JsonConvert.DeserializeObject<data.vWFavoriteProduct>(json.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        //    if (json.IsSuccessStatusCode)
        //    {
        //        return taskModels;

        //    }
        //    else
        //    {
        //        return null;
        //    }


        //}      
        #endregion
        #endregion

        #region Cart -----------------------------------------------------------------------------------
        //Start View_Favoriteproducts RestClient
        private const string CartWebServiceUrl = publicUrl + "api/Carts/";

        public async Task<List<T>> GetAsyncCarts(string userid, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = httpClient.GetStringAsync(publicUrl + "api/vWCartsController/" + userid).GetAwaiter().GetResult();

            if (json != null)
            {

                var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

                return taskModels;
            }
            else
            {
                return null;
            }


        }


        public async Task<bool> PostAsyncCarts(T t, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(t);
            try
            {
                var result = await client.PostAsync(CartWebServiceUrl, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                return result.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }

            //return result.IsSuccessStatusCode;            
        }


        public async Task<bool> DeleteAsyncCarts(int prodectid, string userid, string accessToken)
        {
            HttpClient httpClient = new HttpClient(new NativeMessageHandler());
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await httpClient.DeleteAsync(publicUrl + "api/Cartscontroller/" + prodectid + "/" + userid);

            return response.IsSuccessStatusCode;


        }
        public async Task<bool> PutAsyncCarts(int prodectid, string userid,T t, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(t);
            var result = await httpClient.PutAsync(publicUrl + "api/PutCartscontroller/" + prodectid + "/" + userid, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;


        }
        #endregion

        #region UserSinup -----------------------------------------------------------------------------------
        private const string UserSinupWebServiceUrl = publicUrl + "api/users/";
        public async Task<bool> PostAsyncSinupUser(string ID, string email, string userName, string password)
        {
            var httpClient = new HttpClient();

            var user = new data.UserT
            {
                UserID =ID,
                Email = email,
                Password = password,
                UserName = userName,
            };
            var json = JsonConvert.SerializeObject(user);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(UserSinupWebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;

        }

        #endregion


        #region RegisterUserAsync-----------------------------------------------------------------------------------
        private const string RegisterUserWebServiceUrl = publicUrl + "api/Account/Register";
        private const string NewUserWebServiceUrl = publicUrl + "api/users/";
        private List<data.RegisterBindingModel> _listuser;
        public async Task<bool> RegisterUserAsync(string email, string password, string confirmPassword)
        {
            #region Register-User-in-Account-Control
            var client = new HttpClient();
            var model = new data.RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(RegisterUserWebServiceUrl, httpContent);
            #endregion



            if (response.IsSuccessStatusCode)
            {
                //var LoginUser = ListUser.Find(x => x.Email.ToString().Contains(email));                
                //var pas = ListUser.Find(x => x.Password.ToString().Contains(password));

                #region Register-User-in-users-Control

                #endregion

                return true;

            }

            return false;

        }
        public event PropertyChangedEventHandler PropertyChanged;


        #endregion
        #region LoginAsync
        public async Task<string> LoginAsync(string Email, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", Email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, publicUrl + "Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            var accessToken = jwtDynamic.Value<string>("access_token");

            //Settings.AccessTokenExpirationDate = accessTokenExpiration;

            // Debug.WriteLine(accessTokenExpiration);

            //Debug.WriteLine(content);

            return accessToken;
        }


        #endregion

        #region data with  accessToken

        #endregion
        public async Task<string> GetUserApiId(string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await httpClient.GetStringAsync(publicUrl + "api/GetUserApiId/");

            var UserApiID = JsonConvert.DeserializeObject<string>(json);

            return UserApiID;
        }
        
    }
}


#region comment Old Page
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using MarketApp.Models;
//using Newtonsoft.Json;
//using Plugin.RestClient;
//using System.Collections.ObjectModel;
//using System.Text;
//using System.Diagnostics;
//using MarketApp.Helpers;
//using Newtonsoft.Json.Linq;
//using System.ComponentModel;



//namespace Plugin.RestClient
//{
//    /// <summary>
//    /// RestClient implements methods for calling CRUD operations
//    /// using HTTP.
//    /// </summary>
//    public class RestClient<T> : INotifyPropertyChanged
//    {
//        private const string publicUrl = "http://192.168.1.5:4040/"; 



//        #region prodects 
//        private const string prodectsWebServiceUrl = publicUrl + "api/prodects/";
//        public async Task<List<T>> GetAsyncprodects(string accessToken)
//        {
//            var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

//            var json = await httpClient.GetStringAsync(prodectsWebServiceUrl);

//            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

//            return taskModels;

//        }

//        public async Task<bool> PostAsyncprodects(T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PostAsync(prodectsWebServiceUrl, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> PutAsyncprodects(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PutAsync(prodectsWebServiceUrl + id, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> DeleteAsyncprodects(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var response = await httpClient.DeleteAsync(prodectsWebServiceUrl + id);

//            return response.IsSuccessStatusCode;
//        }
//        #endregion

//        #region Categories 
//        //Start Categories RestClient
//        private const string CategoriesWebServiceUrl = publicUrl + "api/Categories/";

//        public async Task<List<T>> GetAsyncCategories(string accessToken)
//        {
//           var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var json = await httpClient.GetStringAsync(CategoriesWebServiceUrl);

//            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

//            return taskModels;
//        }

//        public async Task<bool> PostAsyncCategories(T t, string accessToken)
//        {            
//                var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PostAsync(CategoriesWebServiceUrl, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> PutAsyncCategories(int id, T t,string accessToken)
//        {
//            var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PutAsync(CategoriesWebServiceUrl + id, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> DeleteAsyncCategories(int id,string accessToken)
//        {
//            var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var response = await httpClient.DeleteAsync(CategoriesWebServiceUrl + id);            
//            return response.IsSuccessStatusCode;
//        }

//        #endregion


//        #region Images 


//        //Start Images RestClient
//        private const string ImageTsWebServiceUrl = publicUrl + "api/ImageTs/";

//        public async Task<List<T>> GetAsyncImageTs(string accessToken)
//        {
//            var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var json = await httpClient.GetStringAsync(ImageTsWebServiceUrl);

//            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

//            return taskModels;
//        }

//        public async Task<bool> PostAsyncImageTs(T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PostAsync(ImageTsWebServiceUrl, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> PutAsyncImageTs(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PutAsync(ImageTsWebServiceUrl + id, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> DeleteAsyncImageTs(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var response = await httpClient.DeleteAsync(ImageTsWebServiceUrl + id);

//            return response.IsSuccessStatusCode;
//        }


//        #endregion


//        #region ProdectT_By_CategorieT 

//        //Start vWProdectTByCategorieT RestClient
//        private const string vWProdectTByCategorieTWebServiceUrl = publicUrl + "api/vWProdectTByCategorieT/";

//        public async Task<List<T>> GetAsyncvWProdectTByCategorieT(string accessToken)
//        {
//            var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var json = await httpClient.GetStringAsync(vWProdectTByCategorieTWebServiceUrl);

//            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

//            return taskModels;
//        }

//        public async Task<bool> PostAsyncvWProdectTByCategorieT(T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PostAsync(vWProdectTByCategorieTWebServiceUrl, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> PutAsyncvWProdectTByCategorieT(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PutAsync(vWProdectTByCategorieTWebServiceUrl + id, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> DeleteAsyncvWProdectTByCategorieT(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var response = await httpClient.DeleteAsync(vWProdectTByCategorieTWebServiceUrl + id);

//            return response.IsSuccessStatusCode;
//        }



//        #endregion

//        #region Categorie_By_Image
//        //Start vWCategorieByImage RestClient
//        private const string vWCategorieByImageWebServiceUrl = publicUrl + "api/vWCategorieByImage/";

//        public async Task<List<T>> GetAsyncvWCategorieByImage(string accessToken)
//        {
//            var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var json = await httpClient.GetStringAsync(vWCategorieByImageWebServiceUrl);

//            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

//            return taskModels;
//        }


//        public async Task<bool> PutAsyncvWCategorieByImage(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PutAsync(vWCategorieByImageWebServiceUrl + id, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        #endregion


//        #region User 
//        //Start Categories RestClient
//        private const string UserWebServiceUrl = publicUrl + "api/users/";

//        public async Task<List<T>> GetAsyncUser(string accessToken)
//        {
//            var httpClient = new HttpClient();
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var json = await httpClient.GetStringAsync(UserWebServiceUrl);

//            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

//            return taskModels;
//        }

//        public async Task<bool> PostAsyncUser(T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PostAsync(UserWebServiceUrl, httpContent);

//            return result.IsSuccessStatusCode;

//        }

//        public async Task<bool> PutAsyncUser(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var json = JsonConvert.SerializeObject(t);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PutAsync(UserWebServiceUrl + id, httpContent);

//            return result.IsSuccessStatusCode;
//        }

//        public async Task<bool> DeleteAsyncUser(int id, T t)
//        {
//            var httpClient = new HttpClient();

//            var response = await httpClient.DeleteAsync(UserWebServiceUrl + id);

//            return response.IsSuccessStatusCode;
//        }
//        #endregion
//        #region UserSinup 
//        private const string UserSinupWebServiceUrl = publicUrl + "api/users/";
//        public async Task<bool> PostAsyncSinupUser(string email, string userName, string password)
//        {
//            var httpClient = new HttpClient();

//            var user = new data.UserT
//            {
//                Email = email,
//                Password = password,
//                UserName = userName,
//            };
//            var json = JsonConvert.SerializeObject(user);

//            HttpContent httpContent = new StringContent(json);

//            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var result = await httpClient.PostAsync(UserSinupWebServiceUrl, httpContent);

//            return result.IsSuccessStatusCode;

//        }

//        #endregion


//        #region RegisterUserAsync
//        private const string RegisterUserWebServiceUrl = publicUrl + "api/Account/Register";
//        private const string NewUserWebServiceUrl = publicUrl + "api/users/";
//        private List<data.RegisterBindingModel> _listuser;


//        public async Task<bool> RegisterUserAsync(string email, string password, string confirmPassword)
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
//        public event PropertyChangedEventHandler PropertyChanged;


//        #endregion
//        #region LoginAsync
//        public async Task<string> LoginAsync(string Email, string password)
//        {
//            var keyValues = new List<KeyValuePair<string, string>>
//            {
//                new KeyValuePair<string, string>("username", Email),
//                new KeyValuePair<string, string>("password", password),
//                new KeyValuePair<string, string>("grant_type", "password")
//            };

//            var request = new HttpRequestMessage(
//                HttpMethod.Post, publicUrl + "/Token");

//            request.Content = new FormUrlEncodedContent(keyValues);

//            var client = new HttpClient();
//            var response = await client.SendAsync(request);

//            var content = await response.Content.ReadAsStringAsync();

//            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

//            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
//            var accessToken = jwtDynamic.Value<string>("access_token");

//            //Settings.AccessTokenExpirationDate = accessTokenExpiration;

//            Debug.WriteLine(accessTokenExpiration);

//            Debug.WriteLine(content);

//            return accessToken;
//        }
//        #endregion

//        #region data with  accessToken

//        #endregion

//    }
//}
#endregion


