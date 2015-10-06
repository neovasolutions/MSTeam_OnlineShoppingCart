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

namespace OnlineShoppingCart.API.ProductCategory.Controllers
{
    public class ProductCategoryController : ApiController
    {
        [System.Web.Http.ActionName("GetAllCategories")]
        public Result<List<OnlineShoppingCart.Model.ProductCategory>> GetAllCategories()
        {
            DAL.ProductCategory productCategory = new DAL.ProductCategory();
            return productCategory.GetAllCategoryList();
        }

        [System.Web.Http.ActionName("Get")]
        public Result<OnlineShoppingCart.Model.ProductCategory> Get(int id)
        {
            DAL.ProductCategory productCategory = new DAL.ProductCategory();
            return productCategory.GetCategory(id);
        }

        //public Result<List<OnlineShoppingCart.Model.ProductCategory>> Get(string category)
        //{
        //    DAL.ProductCategory productCategoryDAL = new DAL.ProductCategory();
        //    return productCategoryDAL.GetCategoryList(category);
        //}

        // POST api/values
        public ValidationResult_OSC Post([FromBody]OnlineShoppingCart.Model.ProductCategory productCategory)
        {
            var result = new ValidationResult_OSC();
            ValidationHelper validationHelper = new ValidationHelper(ref result, ModelState);

            if (result.Success)
            {
                DAL.ProductCategory productDAL = new DAL.ProductCategory();
                result = productDAL.AddCategory(productCategory);
            }
            return result;
        }

        // PUT api/values/5
        public ValidationResult_OSC Put([FromBody]OnlineShoppingCart.Model.ProductCategory productCategory)
        {
            var result = new ValidationResult_OSC();
            ValidationHelper validationHelper = new ValidationHelper(ref result, ModelState);

            if (result.Success)
            {
                DAL.ProductCategory productCatDAL = new DAL.ProductCategory();
                return productCatDAL.UpdateCategory(productCategory);
            }
            return result;
        }

        // DELETE api/values/5
        public ValidationResult_OSC Delete(int id)
        {
            DAL.ProductCategory productCatDAL = new DAL.ProductCategory();
            return productCatDAL.DeleteCategory(id);
        }
    }
}