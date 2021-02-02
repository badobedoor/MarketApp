using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MarketApp
{
    class ImageFileToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fullpath = "C:\\Users\\Ans\\source\\repos\\MarketApp2\\AdminPanal\\UploadedFiles\\mm.png";
            var path = "C:\\Users\\Ans\\source\\repos\\MarketApp2\\AdminPanal\\UploadedFiles\\" + (string)value;
            //string fullpath = "C:\\Users\\Ans\\source\\repos\\MarketApp2\\AdminPanal\\UploadedFiles\\" ;
            //path = fullpath + path;
            return ImageSource.FromFile(fullpath);
            var x = 5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
