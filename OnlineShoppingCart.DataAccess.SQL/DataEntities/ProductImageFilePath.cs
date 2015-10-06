using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCart.DataAccess.SQL
{
    public partial class ProductImageFilePath
    {
        public void ConvertToBusinessObject(out OnlineShoppingCart.Model.ProductImageInfo productImageInfo)
        {
            productImageInfo = new Model.ProductImageInfo
            {
                ProductId = this.ProductId,
                ImageFilePath = this.ImageFilePath,
                IsIndexImage = this.IsIndexImage
            };
        }
    }
}
