//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FavoriteProduct
    {
        public int ProdectID { get; set; }
        public string UserID { get; set; }
        public string test { get; set; }
    
        public virtual ProdectT ProdectT { get; set; }
        public virtual UserT UserT { get; set; }
    }
}
