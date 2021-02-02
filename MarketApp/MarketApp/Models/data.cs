using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MarketApp.Models
{
    public class data
    {
        public class prodectData
        {

            //public ProdectT()
            //{
            //    this.OrderTs = new HashSet<OrderT>();
            //    this.ImageTs = new HashSet<ImageT>();
            //}
            
            public int ProdectID { get; set; }
            public string ProdectName { get; set; }
            public string ProdectNameAR { get; set; }
            public string Descriotion { get; set; }
            public string DescriotionAR { get; set; }
            public decimal Price { get; set; }
            public Nullable<decimal> Rating { get; set; }
            public Nullable<int> CategorieID { get; set; }
            public Nullable<int> ProductsAvailableNum { get; set; }

            public virtual Categoriesdata Categoriesdata { get; set; }

            //public virtual ICollection<OrderT> OrderTs { get; set; }

            //public virtual ICollection<ImageT> ImageTs { get; set; }

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        }
        public partial class vWImageTByProdectT
        {
            public string ProdectName { get; set; }
            public string ProdectNameAR { get; set; }
            public string Descriotion { get; set; }
            public string DescriotionAR { get; set; }
            public decimal Price { get; set; }
            public Nullable<decimal> Rating { get; set; }
            public Nullable<int> ProductsAvailableNum { get; set; }
            public string ImagePath { get; set; }
            public string ImageTitle { get; set; }
            public int ProdectID { get; set; }
        }
        public class Categoriesdata
        {
            public Categoriesdata()
            {
                this.prodectsData = new HashSet<prodectData>();
            }

            public int CategorieID { get; set; }
            public string CategorieName { get; set; }
            public string CategorieNameAR { get; set; }
            public Nullable<int> ImageID { get; set; }


            public virtual ICollection<prodectData> prodectsData { get; set; }
            //public virtual ImageT ImageT { get; set; }
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        }


        //Start vWProdectTByCategorieT   
        public partial class vWProdectTByCategorieT
        {
            public string ProdectName { get; set; }
            public string ProdectNameAR { get; set; }
            public string Descriotion { get; set; }
            public string DescriotionAR { get; set; }
            public decimal Price { get; set; }
            public Nullable<decimal> Rating { get; set; }
            public Nullable<int> ProductsAvailableNum { get; set; }
            public string CategorieName { get; set; }
            public string CategorieNameAR { get; set; }
            public int CategorieID { get; set; }

            public int ProdectID { get; set; }
        }


        public class Imagedata
        {
            public Imagedata()
            {
                this.Categoriesdatas = new HashSet<Categoriesdata>();
            }

            public int ImageID { get; set; }
            public string ImagePath { get; set; }
            public string ImageTitle { get; set; }
            public Nullable<int> ProdectID { get; set; }
            //public HttpPostedFileBase ImageUpload { get; set; }
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Categoriesdata> Categoriesdatas { get; set; }
            public virtual prodectData prodectData { get; set; }
        }


        //Start UserT    
        public class UserT 
        {
            public string UserID { get; set; }
            public string UserName { get; set; }
            
            public string Password { get; set; }

            public string Email { get; set; }

            public string fullName { get; set; }
            
            public string Phone { get; set; }
            
            public string City { get; set; }
            
            public string State { get; set; }
            
            public string Country { get; set; }
            
            public string Address { get; set; }

            public string UserApiID { get; set; }

        }
        //Start View_Favoriteproducts   
        public partial class FavoriteProduct
        {
            public int favoriteProductsID { get; set; }
            public string UserID { get; set; }
            public Nullable<int> ProdectID { get; set; }  

        }
        //Start vWFavoriteProduct
        public partial class vWFavoriteProduct
        {
            public string Expr1 { get; set; }
            public int ProdectID { get; set; }
            public string ProdectName { get; set; }
            public string ProdectNameAR { get; set; }
            public string Descriotion { get; set; }
            public string DescriotionAR { get; set; }
            public decimal Price { get; set; }
            public Nullable<decimal> Rating { get; set; }
            public Nullable<int> CategorieID { get; set; }
            public Nullable<int> ProductsAvailableNum { get; set; }
            public string UserID { get; set; }
        }
        //Start vWCategorieByImageData        
        public partial class vWCart
        {
            public Nullable<int> Numberofproducts { get; set; }
            
            public Nullable<int> totalPrice { get; set; }

            public int ProdectID { get; set; }
            public string ProdectName { get; set; }
            public string ProdectNameAR { get; set; }
            public string Descriotion { get; set; }
            public string DescriotionAR { get; set; }
            public decimal Price { get; set; }
            public Nullable<decimal> Rating { get; set; }
            public Nullable<int> CategorieID { get; set; }
            public Nullable<int> ProductsAvailableNum { get; set; }
            public string UserID { get; set; }
        }
        public partial class Cart
        {
            public int ProdectID { get; set; }
            public string UserID { get; set; }
            public Nullable<int> Numberofproducts { get; set; }
            public Nullable<int> totalPrice { get; set; }

            

            
            
        }
        public class vWCategorieByImageData
        {
            public int CategorieID { get; set; }
            public string CategorieName { get; set; }
            public string CategorieNameAR { get; set; }
            public string ImagePath { get; set; }
            public string ImageTitle { get; set; }
        }

        //Start RegisterBindingModel 
        public class RegisterBindingModel
        {
            public string Email { get; set; }

            public string Password { get; set; }

            public string ConfirmPassword { get; set; }
        }
        //Start EroorMsg        

        public class EroorMsg
        {
            public string MsgText { get; set; }
           
        }

    }

}
