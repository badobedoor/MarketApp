//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProdectT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProdectT()
        {
            this.ImageTs = new HashSet<ImageT>();
            this.OrderTs = new HashSet<OrderT>();
        }
    
        public int ProdectID { get; set; }
        public string ProdectName { get; set; }
        public string ProdectNameAR { get; set; }
        public string Descriotion { get; set; }
        public string DescriotionAR { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public Nullable<int> CategorieID { get; set; }
        public Nullable<int> ProductsAvailableNum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageT> ImageTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderT> OrderTs { get; set; }
        public object CategoriesT { get; set; }
    }
}
