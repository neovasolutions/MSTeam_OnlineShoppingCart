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
    
    public partial class CartHistory
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual Cart Cart { get; set; }
    }
}
