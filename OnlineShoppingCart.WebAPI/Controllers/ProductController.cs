using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShoppingCart.DAL;
using ValidationResult.Framework;
//using System.Web.Mvc;

namespace OnlineShoppingCart.WebAPI.Controllers
{
    //[Authorize]
    public class ProductController : ApiController
    {
        public Result<OnlineShoppingCart.Model.Models.Product> Get(int id)
        {
            Product product = new Product();
            return product.GetProduct(id);
        }

        public Result<List<OnlineShoppingCart.Model.Models.Product>> Get([FromBody]OnlineShoppingCart.Model.Models.Product product)
        {
            Product productDAL = new Product();
            return productDAL.GetProductList(product);
        }

        // POST api/values
        public ValidationResult_OSC Post([FromBody]OnlineShoppingCart.Model.Models.Product product)
        {
            var result = new ValidationResult_OSC();
            ValidationHelper validationHelper = new ValidationHelper(ref result, ModelState);

            if (result.Success)
            {
                Product productDAL = new Product();
                result = productDAL.AddProduct(product);
            }
            return result;
        }

        // PUT api/values/5
        public ValidationResult_OSC Put([FromBody]OnlineShoppingCart.Model.Models.Product product)
        {
            var result = new ValidationResult_OSC();
            ValidationHelper validationHelper = new ValidationHelper(ref result, ModelState);

            if (result.Success)
            {
                Product productDAL = new Product();
                result = productDAL.EditProduct(product);
            }
            return result;        
        }

        // DELETE api/values/5
        public ValidationResult_OSC Delete(int id)
        {
            Product productDAL = new Product();
            return productDAL.DeletProduct(id);
        }
    }
}