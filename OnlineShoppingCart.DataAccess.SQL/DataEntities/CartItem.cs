using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.DataAccess.SQL
{
    public partial class CartItem
    {
        public void ConvertToBusinessObject(out OnlineShoppingCart.Model.CartItem CartItemBO)
        {
            CartItemBO = new Model.CartItem
            {
                Id = this.Id,
                CartId=this.CartId,
                ProductId = this.ProductId,
                Quantity = this.Quantity,
                UnitPrice=this.UnitPrice,
                SubTotal = this.SubTotal,
                AddedDate=this.AddedDate
            };
        }
    }
}
