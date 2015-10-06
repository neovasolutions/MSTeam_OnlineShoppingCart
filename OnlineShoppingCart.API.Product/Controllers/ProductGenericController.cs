using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingCart.DAL;
using OnlineShoppingCart.Model;
using ValidationResult.Framework;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace OnlineShoppingCart.API.Product.Controllers
{
    public class ProductGenericController : ApiController
    {
        [System.Web.Http.ActionName("GetProductGenericList")]
        public Result<List<OnlineShoppingCart.Model.Product>> Get(string productInfo, int categoryID)
        {
            DAL.ProductGeneric productGeneric = new DAL.ProductGeneric();
            return productGeneric.GetProductList_GenericSearch(productInfo,categoryID);
        }
    }
}
