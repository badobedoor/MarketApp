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
    
    public partial class ImageT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImageT()
        {
            this.CategoriesTs = new HashSet<CategoriesT>();
        }
    
        public int ImageID { get; set; }
        public string ImagePath { get; set; }
        public string ImageTitle { get; set; }
        public Nullable<int> ProdectID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoriesT> CategoriesTs { get; set; }
        public virtual ProdectT ProdectT { get; set; }
    }
}
