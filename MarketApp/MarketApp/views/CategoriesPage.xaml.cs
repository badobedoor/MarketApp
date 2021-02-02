using MarketApp.Services;
using MarketApp.ViewModels;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MarketApp.Models.data;

namespace MarketApp.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoriesPage : ContentPage
	{
		public CategoriesPage ()
		{
			InitializeComponent ();
            //getImage();
            this.BindingContext = new ViewModels.MainViewModel();
            
        }

        //private void mnueBTN_Clicked(object sender, EventArgs e)
        //{
        //    var mainPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
        //    (mainPage as MasterDetailPage).IsPresented = true;
        //}


      
    }
}

//SfListView listView = new SfListView();
//listView.TapCommand = viewModel.TappedCommand;
            
public class CommandViewModel
{
    

    
}













//var bath = "C:\\Users\\Ans\\source\\repos\\MarketApp2\\AdminPanal\\UploadedFiles\\mm_119205444.jpg";
//var f = await FileSystem.Current.LocalStorage.GetFileAsync(bath);

//Stream s = await f.OpenAsync(PCLStorage.FileAccess.Read);
//Stream b= await f.OpenAsync("C:\\Users\\Ans\\source\\repos\\MarketApp2\\AdminPanal\\UploadedFiles\\mm_119205444.jpg"); 
//ImageSource imageSourcee = ImageSource.FromStream(() => s);
//sts.Source = imageSourcee;



//ImageSource imageSource = ImageSource.FromFile("C:\\Users\\Ans\\source\\repos\\MarketApp2\\AdminPanal\\UploadedFiles\\mm_119205444.jpg");
//imageans.Source = imageSource;

//this.FindByName<Entry>("zq").Text="hi from heare";
//var x = new MainViewModel();
//ImgUser.Source = ImageSource.FromStream(() =>
//{
//    var stream = imgfilepath.GetStream();
//    return stream;
//});

//this.FindByName<Image>("imageans").Source =
//var author = "ans";
//var book = "bedoor";
//$"{author} is the author of {book}."; 
//string.Format("{0} + {1}", "C:\Users\Ans\source\repos\MarketApp2\AdminPanal\UploadedFiles\"  , "cafe19095992.png "); 