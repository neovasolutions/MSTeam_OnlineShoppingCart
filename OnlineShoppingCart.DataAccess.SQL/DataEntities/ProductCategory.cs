using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.DataAccess.SQL
{
    public partial class ProductCategory
    {
        public void ConvertToBusinessObject(out OnlineShoppingCart.Model.ProductCategory ProductCategory)
        {
            ProductCategory = new Model.ProductCategory
            {
                ID = this.Id,
                Category = this.Category,
                IsActive= this.IsActive,
                CreatedOn= this.CreatedOn,
                UpdatedOn= this.UpdatedOn,
                CreatedByUserID=this.CreatedByUserId,
                UpdatedByUserID= this.UpdatedByUserId
            };
        }
    }
}
