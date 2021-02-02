using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.PopupLayout;

namespace MarketApp.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class productsPage : ContentPage
    {
        SfPopupLayout popupLayout;
        public productsPage()
        {
            InitializeComponent();
            popupLayout = new SfPopupLayout();
        }

        //private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        //{
        //    popupLayout.Show();
        //}
    }
}