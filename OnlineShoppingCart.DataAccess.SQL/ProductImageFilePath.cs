//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShoppingCart.DataAccess.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductImageFilePath
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageFilePath { get; set; }
        public bool IsIndexImage { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
