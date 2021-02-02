using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MarketApp.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Windows.Input;
using MarketApp.Services;
using System.Runtime.CompilerServices;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using FacebookLogin.Views;
using MarketApp.Helpers;
using static MarketApp.Models.data;

namespace MarketApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Log Out Command -------------------------------------------------------------------------------------
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Settings.AccessToken = string.Empty;
                    // navigate to LoginPage
                    await App.Current.MainPage.Navigation.PushAsync(new views.loginPage());
                });
            }
        }
        #endregion


        #region User information ViewModel ---------------------------------------------------------------------------
        private readonly DataServices _apiServices = new DataServices();
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string AddressDital { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string FullName { get; set; }
        public bool AdressBoxItemShow { get; set; }

        //public UserT userinformationT { get; set; }

        public ICommand PutUserInformationCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userinformationT = new UserT
                    {
                        UserID = Settings.ApiUserID,
                        fullName = FullName,
                        Phone = phone,
                        Email = Email,
                        Address = AddressDital,
                        City = City,
                        Country = Country,
                        State = State,
                    };

                    await _apiServices.PutUsersAsync(userinformationT, Settings.AccessToken);
                    await App.Current.MainPage.Navigation.PushAsync(new views.CustomerProfilePage());
                });
            }
        }


        #endregion



        #region Single Properties --------------------------------------------------------------------------
        public string UserName { get; set; }


        public string Password { get; set; }

        public string LoginUserEmail { get; set; }

        public string LoginPassword { get; set; }

        public string ConfirmPassword { get; set; }


        public string EroorMsg { get; set; }




        #endregion


        #region Properties --------------------------------------------------------------------------
        private ObservableCollection<string> _color;

        public ObservableCollection<string> Colors

        {

            get { return _color; }

            set { _color = value; }

        }

        private string _sortby;

        public string Sortby
        {
            get { return _sortby; }

            set
            {
                _sortby = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Sortby"));
                    OnPropertyChanged();
                }
            }


        }



        #region User --------------------------------------------------------------------------
        private data.UserT _user;

        public data.UserT User
        {
            get { return _user; }

            set
            {
                _user = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("User"));
                    OnPropertyChanged();
                }
            }


        }
        #endregion


        #region EroorMsgProp --------------------------------------------------------------------------
        private data.EroorMsg _eroorMsgProp = new data.EroorMsg();
        public data.EroorMsg EroorMsgProp
        {
            get { return _eroorMsgProp; }

            set
            {
                _eroorMsgProp = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EroorMsgProp"));
                    //OnPropertyChanged();
                }
            }


        }
        #endregion


        #region Favoriteproducts --------------------------------------------------------------------------

        private List<data.vWFavoriteProduct> _Favoriteproducts;

        public List<data.vWFavoriteProduct> Favoriteproducts
        {
            get { return _Favoriteproducts; }

            set
            {
                _Favoriteproducts = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Favoriteproducts"));
                    OnPropertyChanged();
                }
            }


        }
        #endregion


        #region carts --------------------------------------------------------------------------

        private List<data.vWCart> _CartsP;

        public List<data.vWCart> CartsP
        {
            get { return _CartsP; }

            set
            {
                _CartsP = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CartsP"));
                    OnPropertyChanged();
                }
            }


        }
        private string _CarttotalPrice;

        public string CarttotalPrice
        {
            get { return _CarttotalPrice; }

            set
            {
                _CarttotalPrice = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CarttotalPrice"));
                    OnPropertyChanged();
                }
            }


        }


        #endregion


        #region vWCategorieByImageProp --------------------------------------------------------------------------
        private List<data.vWCategorieByImageData> smal_vWCategorieByImageProp;

        public List<data.vWCategorieByImageData> captialvWCategorieByImageProp
        {
            set
            {
                smal_vWCategorieByImageProp = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("captialvWCategorieByImageProp"));

                }
            }
            get => smal_vWCategorieByImageProp;

        }
        #endregion



        #region ProductList --------------------------------------------------------------------------
        private int _productIDList;
        public int ProductIDList
        {
            set
            {
                _productIDList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductIDList"));
                }
            }
            get => _productIDList;

        }
        private List<data.prodectData> _productList;
        public List<data.prodectData> ProductList
        {
            set
            {
                _productList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductList"));
                }
            }
            get => _productList;

        }

        private List<data.vWProdectTByCategorieT> _ProdectTByCategorieList;
        public List<data.vWProdectTByCategorieT> ProdectTByCategorieList
        {
            set
            {
                _ProdectTByCategorieList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProdectTByCategorieList"));
                }
            }
            get => _ProdectTByCategorieList;

        }

        private data.prodectData _produestsByCategorie;

        public data.prodectData ProduestsByCategorie
        {
            set
            {
                _produestsByCategorie = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProduestsByCategorie"));
                }
            }
            get => _produestsByCategorie;

        }


        private data.vWImageTByProdectT _prodectByImage;

        public data.vWImageTByProdectT ProdectByImage
        {
            set
            {
                _prodectByImage = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProdectByImage"));
                }
            }
            get => _prodectByImage;

        }

        #region Colores..............................
        private Color _myaccount_icon_color;

        public Color myaccount_icon_color
        {
            set
            {
                _myaccount_icon_color = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("myaccount_icon_color"));
                }
            }
            get => _myaccount_icon_color;

        }
        private Color _Cart_icon_color;

        public Color Cart_icon_color
        {
            set
            {
                _Cart_icon_color = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Cart_icon_color"));
                }
            }
            get => _Cart_icon_color;

        }

        private Color _Home_icon_color;

        public Color Home_icon_color
        {
            set
            {
                _Home_icon_color = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Home_icon_color"));
                }
            }
            get => _Home_icon_color;

        }


        private Color _Categories_icon_color;

        public Color Categories_icon_color
        {
            set
            {
                _Categories_icon_color = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Categories_icon_color"));
                }
            }
            get => _Categories_icon_color;

        }

        private Color _wishlist_icon_color;

        public Color wishlist_icon_color
        {
            set
            {
                _wishlist_icon_color = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("wishlist_icon_color"));
                }
            }
            get => _wishlist_icon_color;

        }
        #endregion


        #endregion


        #region IsPresentedprop --------------------------------------------------------------------------
        bool isPresentedprop;
        public bool IsPresentedprop
        {
            set
            {
                isPresentedprop = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsPresentedprop"));
                }
            }
            get => isPresentedprop;

        }
        #endregion


        #region ChangeText --------------------------------------------------------------------------
        string changeText;
        public string ChangeText
        {
            set
            {
                changeText = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChangeText"));
                }
            }
            get => changeText;

        }

        // public string PageIconColor { get; set; }
        #endregion


        #region Change List view --------------------------------------------------------------------------
        bool _oneItemListView;
        public bool OneItemListView
        {
            set
            {
                _oneItemListView = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("OneItemListView"));
                }
            }
            get => _oneItemListView;

        }

        bool _twoItemListView;
        public bool TwoItemListView
        {
            set
            {
                _twoItemListView = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TwoItemListView"));
                }
            }
            get => _twoItemListView;

        }

        Color _colortwoItemListView;
        public Color ColorTwoItemListView
        {
            set
            {
                _colortwoItemListView = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ColorTwoItemListView"));
                }
            }
            get => _colortwoItemListView;

        }

        Color _coloroneItemListView;
        public Color ColoroneItemListView
        {
            set
            {
                _coloroneItemListView = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ColoroneItemListView"));
                }
            }
            get => _coloroneItemListView;

        }

        public Command Change_To_OneItemlistview_Command
        {
            get { return new Command( () => {  Change_To_OneItemlistview(); }); }
        }

        public Command Change_To_twoItemlistview_Command
        {
            get { return new Command( () => { Change_To_twoItemlistview(); }); }
        }
        #endregion

        #region Comment..........................
        //private List<data.UserT> _listuser;

        //public List<data.UserT> ListUser
        //{
        //    get { return _listuser; }

        //    set
        //    {
        //        _listuser = value;
        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("ListUser"));

        //        }
        //    }


        //}


        //private ObservableCollection<ProductInfo> _productListttt;

        //public ObservableCollection<ProductInfo> ProductListttt
        //{
        //    set
        //    {
        //        _productList = value;
        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("ProductListttt"));
        //        }
        //    }
        //    get => _productList;

        //}

        //private List<data.prodectData> smal_produestProp;

        //public List<data.prodectData> captialproduestProp
        //{
        //    set
        //    {
        //        smal_produestProp = value;
        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("captialproduestProp"));

        //        }
        //    }
        //    get => smal_produestProp;

        //}

        //private List<data.prodectData> produestsVrep;

        //public List<data.prodectData> ProduestsProp
        //{
        //    set
        //    {
        //        produestsVrep = value;
        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("ProduestsProp"));
        //        }
        //    }
        //    get => produestsVrep;

        //}


        //#region User information ViewModel                
        //public int Favoriteproducts_ProdectID { get; set; }
        //public string Favoriteproducts_ProdectName { get; set; }
        //public string Favoriteproducts_ProdectNameAR { get; set; }
        //public string Favoriteproducts_Descriotion { get; set; }
        //public string Favoriteproducts_DescriotionAR { get; set; }
        //public decimal Favoriteproducts_Price { get; set; }
        //public Nullable<decimal> Favoriteproducts_Rating { get; set; }
        //public Nullable<int> Favoriteproducts_CategorieID { get; set; }
        //public Nullable<int> Favoriteproducts_ProductsAvailableNum { get; set; }
        ////public string Favoriteproducts_UserID { get; set; }
        //public string Favoriteproducts_Email { get; set; }
        ////public UserT userinformationT { get; set; }




        //#endregion

        #endregion
        #endregion



        #region Command --------------------------------------------------------------------------
        public ICommand BIsPresented { get; protected set; }
        public ICommand ItemTapped { get; protected set; }
        public ICommand CategorieItemTapped { get; protected set; }
        public ICommand ProductItemTapped { get; protected set; }
        public ICommand FavoriteproductsComand { get; protected set; }

        public ICommand DeleteFavoriteproductsComand { get; protected set; }

        public ICommand PostCartsComand { get; protected set; }

        public ICommand DeleteCartsComand { get; protected set; }

        public ICommand PlusNumberofproductComand { get; protected set; }
        public ICommand minusNumberofproductsComand { get; protected set; }

        public ICommand logcIcommand { get; protected set; }
        // public ICommand PostUserData { get; protected set; }
        public ICommand BchangeText { get; protected set; }

        public ICommand TappedCommand { get; protected set; }

        public ICommand Nav_To_PopupPage_Command { get; protected set; }

        //public ICommand Nav_To_HomePage_Command { get; protected set; }
        //public ICommand Nav_To_CategoriesPage_Command { get; protected set; }
        //public ICommand Nav_To_CustomerProfilePage_Command { get; protected set; }
        //public ICommand Nav_To_WishlistPage_Command { get; protected set; }
        //public ICommand Nav_To_CartPage_Command { get; protected set; }

        #endregion

        #region Navigation Command --------------------------------------------------------------------------

        public Command Nav_To_LogInPage_Command
        {
            get { return new Command(async () => { await App.Current.MainPage.Navigation.PushAsync(new views.loginPage()); }); }
        }
        public Command Nav_To_FacebookPage_Command
        {
            get { return new Command(async () => { await App.Current.MainPage.Navigation.PushAsync(new FacebookProfileCsPage()); }); }
        }
        public Command Nav_To_GooglePage_Command
        {
            get { return new Command(async () => { await App.Current.MainPage.Navigation.PushAsync(new views.loginPage()); }); }

        }

        public Command Nav_To_SignUpPage_Command
        {
            get { return new Command(async () => { await App.Current.MainPage.Navigation.PushAsync(new views.sinUpPage()); }); }
        }
        #region Foter navigation --------------------
        public Command Nav_To_Homepage_Command
        {
            get { return new Command(async () => { Settings.PageIconColor = "Home"; await App.Current.MainPage.Navigation.PushAsync(new views.HomePage()); }); }
        }
        public Command Nav_To_CategoriesPage_Command
        {
            get { return new Command(async () => { Settings.PageIconColor = "Categories"; await App.Current.MainPage.Navigation.PushAsync(new views.CategoriesPage()); }); }
        }
        public Command Nav_To_CustomerProfilePage_Command
        {
            get { return new Command(async () => { Settings.PageIconColor = "myaccount"; await App.Current.MainPage.Navigation.PushAsync(new views.CustomerSitingPage()); }); }
        }
        public Command Nav_To_WishlistPage_Command
        {

            get { return new Command(async () => { Settings.PageIconColor = "wishlist"; await App.Current.MainPage.Navigation.PushAsync(new views.WishlistPage()); }); }
        }
        public Command Nav_To_CartPage_Command
        {
            get { return new Command(async () => { Settings.PageIconColor = "Cart"; await App.Current.MainPage.Navigation.PushAsync(new views.CartPage()); }); }
        }
        public Command Nav_To_lastPage_Command
        {
            get { return new Command(async () => { Settings.PageIconColor = "Categories"; await App.Current.MainPage.Navigation.PushAsync(new views.ForgetPasswordPage()); }); }
            //await App.Current.MainPage.Navigation.PopAsync();
        }
        #endregion


        public Command Nav_To_Search_Command
        {
            get { return new Command(async () => { Settings.PageIconColor = "Categories"; await App.Current.MainPage.Navigation.PushAsync(new views.SearchPagexaml()); }); }
        }
        public Command Nav_To_productsPage_Command
        {
            get { return new Command(async () => { Settings.PageIconColor = "Categories"; await App.Current.MainPage.Navigation.PushAsync(new views.productsPage()); }); }
        }


        //public Command Nav_To_EditCustomerProfilePage_Command
        //{
        //    ///get { return new Command(async () => { await App.Current.MainPage.Navigation.PushAsync(new views.EditCustomerProfilePage()); }); }
        //}







        #endregion



        #region constractor ---------------------------------------------------------------------------
        public MainViewModel()
        {
            isPresentedprop = false;
            ItemTapped = new Command(ItemTappedCommand);
            UserInformation();
            
            changeIconecolor(Settings.PageIconColor);
            Settings.PageIconColor = "Home";
            //  Change List view  -------------------------------------------------------------            
            OneItemListView = false;
            TwoItemListView = true;
            ColoroneItemListView = Color.FromHex("3B3B3B");
            ColorTwoItemListView = Color.FromHex("DCD8D8");
            //  Productdata -------------------------------------------------------------            
            getProductdata();
            getProductDetailData();
            ProductItemTapped = new Command(ProductItemTappedMathod);
            //  Categorie -------------------------------------------------------------            
            CategorieByImageData();
            getCategorieItemMathod();
            CategorieItemTapped = new Command(CategorieItemTappedMathod);
            // Favoriteproducts -------------------------------------------------------------            
            GetFavoriteproductsMathod();
            FavoriteproductsComand = new Command(FavoriteproductsComandMathod);            
            DeleteFavoriteproductsComand = new Command(DeleteFavoriteproductsComandMathod);
            // Cart ---------------------------------------------------------------
            GetCartsMathod(); 
            PostCartsComand = new Command(PostCartsComandMathod);
            DeleteCartsComand = new Command(DeleteCartsComandMathod);
            PlusNumberofproductComand = new Command(PlusNumberofproducts);
            minusNumberofproductsComand = new Command(minusNumberofproducts);
            CarttotalPriceM();
            //--------------------------------------------------------------------
            BIsPresented = new Command(IsPresentedCommand);
            BchangeText = new Command(changeTextCommand);
            TappedCommand = new Command(TappedCommandMethod);
            //Navigaton Comand --------------------------------------------------------------------

            Nav_To_PopupPage_Command = new Command(Nav_To_PopupPage_Command_M);
            //Nav_To_HomePage_Command = new Command(Nav_To_HomePage_Command_M);
            //Nav_To_CategoriesPage_Command = new Command(Nav_To_CategoriesPage_Command_M);
            //Nav_To_CustomerProfilePage_Command = new Command(Nav_To_CustomerProfilePage_Command_M);
            //Nav_To_WishlistPage_Command = new Command(Nav_To_WishlistPage_Command_M);
            //Nav_To_CartPage_Command = new Command(Nav_To_CartPage_Command_M);
            //PostUserData = new Command(PostUserDataME);
            //ChangeText = EroorMsgProp.MsgText;
            Sortby = "Red";
            Colors = new ObservableCollection<string>();

            Colors.Add("Red");

            Colors.Add("Green");

            Colors.Add("Yellow");

            Colors.Add("Blue");

            Colors.Add("SkyBlue");

            Colors.Add("Orange");

            Colors.Add("Gray");

            Colors.Add("Pink");

        }

        #endregion
        #region Change List view --------------------------------------------------------------------------
        public void Change_To_OneItemlistview()
        {
            OneItemListView = true;
            TwoItemListView = false;
            ColoroneItemListView = Color.FromHex("DCD8D8");
            ColorTwoItemListView = Color.FromHex("3B3B3B");
        }
        public void Change_To_twoItemlistview()
        {
            OneItemListView = false;
            TwoItemListView = true;
            ColoroneItemListView = Color.FromHex("3B3B3B");
            ColorTwoItemListView = Color.FromHex("DCD8D8"); 
        }
        #endregion
        #region mathod -------------------------------------------------------------------------

        public async void  changeIconecolor(string iconTabedName)
        {
            Color a = Color.FromHex("000");
            Color b = Color.FromHex("3D72FF");            
            if (iconTabedName == "Home")
            {
                Home_icon_color = b;
                Categories_icon_color = a;
                myaccount_icon_color = a;
                wishlist_icon_color = a;                                
                Cart_icon_color = a;
                
            }
            else if (iconTabedName == "Categories" || iconTabedName == "Categories00")
            {
                if(iconTabedName == "Categories00")
                {
                    Home_icon_color = a;
                    Categories_icon_color = b;
                    myaccount_icon_color = a;
                    wishlist_icon_color = a;
                    Cart_icon_color = a;
                }
                else
                {
                    Home_icon_color = a;
                    Categories_icon_color = b;
                    myaccount_icon_color = a;
                    wishlist_icon_color = a;
                    Cart_icon_color = a;
                    Settings.PageIconColor = "Categories00";
                   
                }
           

            }
            else if (iconTabedName == "myaccount")
            {
                Home_icon_color = a;
                Categories_icon_color = a;
                myaccount_icon_color = b;
                wishlist_icon_color = a;
                Cart_icon_color = a;
                
            }
            else if (iconTabedName == "wishlist")
            {
                Home_icon_color = a;
                Categories_icon_color = a;
                myaccount_icon_color = a;
                wishlist_icon_color = b;
                Cart_icon_color = a;
                
            }
            else if (iconTabedName == "Cart")
            {
                Home_icon_color = a;
                Categories_icon_color = a;
                myaccount_icon_color = a;
                wishlist_icon_color = a;
                Cart_icon_color = b;
                
            }
            else
            {
                Home_icon_color = a;
                Categories_icon_color = a;
                myaccount_icon_color = a;
                wishlist_icon_color = a;
                Cart_icon_color = a;
                
            }

        }

        #region Productdata ---------------------------------------------------------------------------------
        public async void getProductdata()
        {
            var O_DataServices = new DataServices();
            var accessToken = Settings.AccessToken;            
            ProductList = await O_DataServices.GetProduct(accessToken);
        }
        public async void getProductDetailData()
        {
            var O_DataServices = new DataServices();
            var accessToken = Settings.AccessToken;
            var Prodectdata = await O_DataServices.GetvWImageTByProdectTSelected(Settings.ProdectID, Settings.AccessToken);
            if (Prodectdata != null)
            {
                ProdectByImage = Prodectdata;
            }
            else
            {
                var x = 1;
            }
             
            
            

        }

        public async void ProductItemTappedMathod(object obj)
        {
            var O_DataServices = new DataServices();
            var accessToken = Settings.AccessToken;
            var prodectItemData = obj as vWProdectTByCategorieT;
             

            ProductIDList = prodectItemData.ProdectID;
            Settings.ProdectID = prodectItemData.ProdectID;
            ProdectByImage = await _apiServices.GetvWImageTByProdectTSelected(prodectItemData.ProdectID, Settings.AccessToken);
            await App.Current.MainPage.Navigation.PushAsync(new views.productsDetailPage());

        }
        #endregion
        public async void UserInformation() 
        {
            var O_DataServices = new DataServices();
            var accessToken = Settings.AccessToken;
            User = (_apiServices.SearchUsersAsyncByID(Settings.ApiUserID, accessToken)).Result;
            Email = User.Email;
            FullName = User.fullName;
            phone = User.Phone;
            AddressDital = User.Address;
            City = User.City;
            Country = User.Country;
            State = User.State;
            if (User.City == null && User.Country == null && User.State == null && User.Address == null)
            {
                FullAddress = "";
                AdressBoxItemShow = false;
            }
            else
            {
                FullAddress = AddressDital + "/" + City + "/" + Country + "/" + State;
                AdressBoxItemShow = true;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Favoriteproducts ---------------------------------------------------------------------------------
        public async void GetFavoriteproductsMathod()
        {
            var O_DataServices = new DataServices();
            var accessToken = Settings.AccessToken;

            var test = await O_DataServices.GetFavoriteproductsData(Settings.ApiUserID, accessToken);
            if (test != null)
            {
                Favoriteproducts = test;
            }
            else
            {
                var erorr = "no data";
            }

        }
        public async void FavoriteproductsComandMathod(object obj)
        {
            var Selectedproduct = obj as prodectData;
            var Favoriteproduct = new FavoriteProduct
            {
                UserID = Settings.ApiUserID,
                ProdectID = Selectedproduct.ProdectID,
            };
            var f = 5;
            await _apiServices.PostFavoriteproductsAsync(Favoriteproduct, Settings.AccessToken);
            //await App.Current.MainPage.Navigation.PushAsync(new views.CustomerProfilePage());

        }
        public async void DeleteFavoriteproductsComandMathod(object obj)
        {
            var Selectedproduct = obj as vWFavoriteProduct;
            await _apiServices.DeleteFavoriteproducts(Selectedproduct.ProdectID, Selectedproduct.UserID, Settings.AccessToken);
            await App.Current.MainPage.Navigation.PushAsync(new views.MasterDetailPageGdG());

        }
        void ItemTappedCommand(object obj)
        {
            var Favoriteproducts = obj as vWFavoriteProduct;
            var x = 1;
            //await _apiServices.PostFavoriteproductsAsync(Favoriteproducts, Settings.AccessToken);
            //  await App.Current.MainPage.Navigation.PushAsync(new views.CustomerProfilePage());

        }
        #endregion        
     

        #region Cart ---------------------------------------------------------------------------------
        public async void GetCartsMathod()
        {
            var O_DataServices = new DataServices();
            var accessToken = Settings.AccessToken;

            var cartdata = await O_DataServices.GetCartsData(Settings.ApiUserID, accessToken);
            if (cartdata != null)
            {
                CartsP = cartdata;
            }
            else
            {
                var erorr = "no data";
            }

        }
        public async void PostCartsComandMathod()
        {
            //var Selectedproduct = obj as prodectData;
            var cartdata = new Cart
            {
                UserID = Settings.ApiUserID,
                ProdectID = ProdectByImage.ProdectID,
                Numberofproducts =1,
                totalPrice = Decimal.ToInt32(ProdectByImage.Price)
            //totalPrice = Selectedproduct.Price
        };
            
            await _apiServices.PostCartsAsync(cartdata, Settings.AccessToken);
            var f = 5;
            //await App.Current.MainPage.Navigation.PushAsync(new views.CustomerProfilePage());

        }
        public async void DeleteCartsComandMathod(object obj)
        {
            var Selectedproduct = obj as vWCart;
            await _apiServices.DeleteCarts(Selectedproduct.ProdectID, Selectedproduct.UserID, Settings.AccessToken);
            await App.Current.MainPage.Navigation.PushAsync(new views.MasterDetailPageGdG());

        }
        public async void   PlusNumberofproducts(object obj)
        {
            
            var SelectedwvCart = obj as vWCart;
            if (SelectedwvCart.Numberofproducts > SelectedwvCart.ProductsAvailableNum)
            {
                var msg = "eroor";
            }
            else
            {
                var NewNumper = SelectedwvCart.Numberofproducts + 1;
                var CartData = new Cart
                {
                    UserID = SelectedwvCart.UserID,
                    ProdectID = SelectedwvCart.ProdectID,
                    Numberofproducts = NewNumper,
                    totalPrice = NewNumper * Decimal.ToInt32(SelectedwvCart.Price),
                   
                };

                await _apiServices.PutCarts(SelectedwvCart.ProdectID, SelectedwvCart.UserID, CartData, Settings.AccessToken);
                await App.Current.MainPage.Navigation.PushAsync(new views.CartPage());
            }
               
        }
        public async void minusNumberofproducts(object obj)
        {
            
            var SelectedwvCart = obj as vWCart;
            if (SelectedwvCart.Numberofproducts < 2 )
            {
                var msg = "eroor";
            }
            else
            {
                var NewNumper = SelectedwvCart.Numberofproducts - 1;
                var CartData = new Cart
                {
                    UserID = SelectedwvCart.UserID,
                    ProdectID = SelectedwvCart.ProdectID,
                    Numberofproducts = NewNumper,
                    totalPrice = NewNumper * Decimal.ToInt32(SelectedwvCart.Price),

                };

                await _apiServices.PutCarts(SelectedwvCart.ProdectID, SelectedwvCart.UserID, CartData, Settings.AccessToken);
                await App.Current.MainPage.Navigation.PushAsync(new views.CartPage());
            }

        }
        public async void CarttotalPriceM()
        {

            //List fruits = new List();
            int intCarttotalPrice =0;
            foreach (var item in CartsP)
            {
                intCarttotalPrice += (item.totalPrice).GetValueOrDefault();
                CarttotalPrice = "$ " + intCarttotalPrice.ToString();    
            }

        }
        //void ItemTappedCommand(object obj)
        //{
        //    var Favoriteproducts = obj as vWFavoriteProduct;
        //    //await _apiServices.PostFavoriteproductsAsync(Favoriteproducts, Settings.AccessToken);
        //    //  await App.Current.MainPage.Navigation.PushAsync(new views.CustomerProfilePage());

        //}
        #endregion

        #region Categorie ---------------------------------------------------------------------------------
        public async void CategorieByImageData()
        {
            var O_DataServices = new DataServices();
            var accessToken = Settings.AccessToken;
            captialvWCategorieByImageProp = await O_DataServices.GetvWCategorieByImageData(accessToken);
        }

        public async void CategorieItemTappedMathod(object obj)
        {
            var O_DataServices = new DataServices();
            var accessToken = Settings.AccessToken;
            var Categorie = obj as vWCategorieByImageData;
            Settings.CategorieID = Categorie.CategorieID;
            //ProdectTByCategorieList = await _apiServices.SearchProductsByCategorie(CategID, Settings.AccessToken);
            await App.Current.MainPage.Navigation.PushAsync(new views.productsPage());

        }
        public async void getCategorieItemMathod()
        {
            ProdectTByCategorieList = await _apiServices.SearchProductsByCategorie(Settings.CategorieID, Settings.AccessToken);
        }

        #endregion
        #region navigation Command mathod --------------------------------------------------------------------
        //public async void Nav_To_HomePage_Command_M()
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(new FacebookProfileCsPage());
        //}
        //public async void Nav_To_CategoriesPage_Command_M()
        //{
        //   if (Settings.PageIconColor == "Categories00")
        //    {
        //        Settings.PageIconColor = "Categories00";                
        //    }
        //    else { Settings.PageIconColor = "Categories";  }
        //    await App.Current.MainPage.Navigation.PushAsync(new views.CategoriesPage());
        //}
        //public async void Nav_To_CustomerProfilePage_Command_M()
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(new views.CustomerProfilePage());
        //}
        //public async void Nav_To_WishlistPage_Command_M()
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(new views.WishlistPage());
        //}
        //public async void Nav_To_CartPage_Command_M()
        //{
        //    await App.Current.MainPage.Navigation.PushAsync(new views.CartPage());
        //}
        #endregion
        #region Command mathod --------------------------------------------------------------------
        //void  PostUserDataME()
        //{
        //    //دى دالة الزرار الى في صفحه اليوزر
        //    var O_DataServices = new DataServices();
        //     O_DataServices.postUser(_user);

        //}



        void IsPresentedCommand()
        {
            var Detail = new NavigationPage(new views.HomePage());
            Application.Current.MainPage = new views.MasterDetailPageGdG();
            IsPresentedprop = true;

        }

        public async void Nav_To_PopupPage_Command_M()
        {
            await PopupNavigation.Instance.PushAsync(new PopUpdemo());
        }





        void changeTextCommand()
        {
            ChangeText = "New Text";

        }
        void changeEroorMSG()
        {
            EroorMsg = "Email Rong";

        }
        private void TappedCommandMethod(object obj)
        {
            //if ((obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData == MainViewModel.InboxInfo[0])
            //    MainViewModel.InboxInfo.Remove(e.ItemData as ListViewInboxInfo)
        }
        //هنا انتهيت ونكمل غدا 18/11/2019

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



    }
}
