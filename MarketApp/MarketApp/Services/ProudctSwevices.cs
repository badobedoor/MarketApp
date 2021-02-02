using System;
using System.Collections.Generic;
using System.Text;
using MarketApp.Models;
using System.Collections.ObjectModel;

namespace MarketApp.Services
{
    public class ProudctSwevices
    {
        public ObservableCollection<ProductInfo> GetProduct()
        {
            var list = new ObservableCollection<ProductInfo>
            {
                new ProductInfo
                {
                    name ="Iphone",
                    Price =2500

                },
                new ProductInfo
                {
                    name ="Iphone1",
                    Price =2600

                },
                new ProductInfo
                {
                    name ="Iphone2",
                    Price =2700

                },
                new ProductInfo
                {
                    name = "Iphone3",
                    Price = 3500

                },
                new ProductInfo
                {
                    name = "Iphone4",
                    Price = 5500

                },
                new ProductInfo
                {
                    name = "Iphone5",
                    Price = 246000

                },
                new ProductInfo
                {
                    name = "Iphone",
                    Price = 2500

                },
                new ProductInfo
                {
                    name = "Iphone",
                    Price = 2500

                },
            };
            return list;
        }
    }
}
