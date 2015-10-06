using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingCart.Model;

namespace OnlineShoppingCart.DataAccess.SQL
{
    public partial class Product
    {
        public void ConvertToBusinessObject(out OnlineShoppingCart.Model.Product productBO)
        {
            productBO = new Model.Product
            {
                ID = this.Id,
                ProductCode = this.ProductCode,
                ProductName = this.ProductName,
                ProductDescription = this.ProductDescription,
                CategoryID = this.CategoryId,
                Brand = this.Brand,
                Model = this.Model,
                UnitPrice = this.UnitPrice,
                SKU = this.SKU,
                CurrentStock = this.CurrentStock,
                IsActive = this.IsActive,
                CreatedOn = this.CreatedOn,
                UpdatedOn = this.UpdatedOn.GetValueOrDefault(),
                CreatedByUserID = this.CreatedByUserId,
                UpdatedByUserID = this.UpdatedByUserId.GetValueOrDefault()
                //public byte[] ImageThumbNail =
                //byte[] ImageIndex =
                //List<byte[]> ImageOthers =
            };
        }
    }
}
