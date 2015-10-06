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
    public class ProductController : ApiController
    {
        // this implementation is not required.  
        // use action - public Result<List<OnlineShoppingCart.Model.Product>> Get([FromBody]OnlineShoppingCart.Model.Product product)
        //[System.Web.Http.ActionName("GetAllProducts")]
        //public Result<List<OnlineShoppingCart.Model.Product>> GetAllProduct()
        //{
        //    DAL.Product product = new DAL.Product();
        //    return product.GetAllProduct();
        //}

        [System.Web.Http.ActionName("GetProduct")]
        public Result<OnlineShoppingCart.Model.Product> GetProduct(int id)
        {
            DAL.Product product = new DAL.Product();
            return product.GetProduct(id);
        }
        [System.Web.Http.ActionName("GetSearchProduct")]
        public Result<List<OnlineShoppingCart.Model.Product>> Get([FromUri]OnlineShoppingCart.Model.Product product)
        {
            DAL.Product productDAL = new DAL.Product();
            return productDAL.GetProductList(product);
        }

        // POST api/values
        [System.Web.Http.ActionName("InsertProduct")]
        public ValidationResult_OSC PostInsertProduct([FromBody]OnlineShoppingCart.Model.Product product)
        {
            var result = new ValidationResult_OSC();
            ValidationHelper validationHelper = new ValidationHelper(ref result, ModelState);

            if (result.Success)
            {
                DAL.Product productDAL = new DAL.Product();
                result = productDAL.AddProduct(product);
            }
            return result;
        }

        [System.Web.Http.ActionName("ProductImageInfo")]
        public ValidationResult_OSC PostProductImageInfo([FromBody] List<OnlineShoppingCart.Model.ProductImageInfo> lstProductImageInfo)
        {
            var result = new ValidationResult_OSC();

            //validate that string path is not empty
            bool listNotValid = lstProductImageInfo.Any(cus => String.IsNullOrWhiteSpace(cus.ImageFilePath));
            if (listNotValid)
            {
                result.AddMessage("One or more image path are empty.");
                return result;
            }
            ProductImage productImageDAL = new ProductImage();
            result = productImageDAL.AddListProductImageFilePath(lstProductImageInfo);
            return result;
        }

        // PUT api/values/5
        public ValidationResult_OSC Put([FromBody]OnlineShoppingCart.Model.Product product)
        {
            var result = new ValidationResult_OSC();
            ValidationHelper validationHelper = new ValidationHelper(ref result, ModelState);

            if (result.Success)
            {
                DAL.Product productDAL = new DAL.Product();
                result = productDAL.UpdateProduct(product);
            }
            return result;
        }

        // DELETE api/values/5
        public ValidationResult_OSC Delete(int id)
        {
            DAL.Product productDAL = new DAL.Product();
            return productDAL.DeletProduct(id);
        }
    }
}
