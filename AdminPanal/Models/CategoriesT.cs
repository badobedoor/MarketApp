//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminPanal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoriesT
    {
        public int CategorieID { get; set; }
        public string CategorieName { get; set; }
        public string CategorieNameAR { get; set; }
        public Nullable<int> ImageID { get; set; }
    
        public virtual ImageT ImageT { get; set; }
    }
}
