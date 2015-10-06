using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.DataAccess.SQL
{
    public partial class Cart
    {
        public void ConvertToBusinessObject(out OnlineShoppingCart.Model.Cart cartBO)
        {
            cartBO = new Model.Cart
            {
                Id = this.Id,
                UserId = this.UserId,
                TotalAmount= this.TotalAmount,
                IsActive = this.IsActive,
                CreatedDate = this.CreatedDate
            };
        }
    }
}
