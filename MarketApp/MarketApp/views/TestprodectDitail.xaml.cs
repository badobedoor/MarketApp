using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketApp.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestprodectDitail : ContentPage
    {
        public TestprodectDitail()
        {
            InitializeComponent();
            var i = 1;
            Color a = Color.Gray;
            Color b = Color.Gray;
            Color c = Color.Gray;
            Color d = Color.Gray;



            imagerrtt.Source = (String.Format("mm_{0}.jpg", i));
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (i == 5)
                {
                    i = 1;
                    imagerrtt.Source = (String.Format("mm_{0}.jpg", i));
                }

                imagerrtt.Source = (String.Format("mm_{0}.jpg", i));


                if (i == 1)
                {
                    d = Color.Gray;
                    a = Color.FromHex("#12848F");
                }
                else if (i == 2)
                {
                    a = Color.Gray;
                    b = Color.FromHex("#12848F");
                }
                else if (i == 3)
                {
                    b = Color.Gray;
                    c = Color.FromHex("#12848F");
                }
                else if (i == 4)
                {
                    c = Color.Gray;
                    d = Color.FromHex("#12848F");
                }
                border_1.BorderColor = a;
                border_2.BorderColor = b;
                border_3.BorderColor = c;
                border_4.BorderColor = d;
                i++;

                return true;
            });






        }
    }
}