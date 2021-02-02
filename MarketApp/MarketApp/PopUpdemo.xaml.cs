using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MarketApp.Models.data;

namespace MarketApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpdemo : PopupPage
    {
        public PopUpdemo()
        {
            InitializeComponent();
        }

        private void pupUpBtn_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}