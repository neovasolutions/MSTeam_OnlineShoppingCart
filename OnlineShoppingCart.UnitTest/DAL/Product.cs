using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ValidationResult.Framework;

namespace OnlineShoppingCart.UnitTest
{
    [TestClass]
    public class Product
    {
        public static int resultId;
        [TestMethod]
        public void InsertProduct()
        {
            OnlineShoppingCart.DAL.Product productObj = new OnlineShoppingCart.DAL.Product();

            Model.Product productInsert = new Model.Product()
            {
                Model = "_productAdd.Model",
                ProductCode = "_productAdd.ProductCode",
                ProductName = "_productAdd.ProductName",
                ProductDescription = "_productAdd.ProductDescription",
                CategoryID = 1,
                Brand = "_productAdd.Brand",
                UnitPrice = new decimal(10.2),
                SKU = "_productAdd.SKU",
                CurrentStock = 1,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now.AddDays(2),
                CreatedByUserID = 1,
                UpdatedByUserID = 2
            };
            var result = productObj.AddProduct(productInsert);
            resultId = Convert.ToInt32(result.returnValue);
            Assert.IsTrue(result.Success, "Insert successful");
        }

        [TestMethod]
        public void GetProduct()
        {
            OnlineShoppingCart.DAL.Product productObj = new OnlineShoppingCart.DAL.Product();
            var result=productObj.GetProduct(resultId);
            Assert.IsTrue(result.Success, "Get called successful");
        }

        [TestMethod]
        public void GetProductList()
        {
            OnlineShoppingCart.DAL.Product productObj = new OnlineShoppingCart.DAL.Product();
            OnlineShoppingCart.Model.Product product = new Model.Product() {
                ProductCode = "Mobile"
            };
            var result = productObj.GetProductList(product);
            Assert.IsTrue(result.Success, "Get product list successful");
        }

        [TestMethod]
        public void EditProduct()
        {
            if (resultId == 0)
                return;
            OnlineShoppingCart.DAL.Product productObj = new OnlineShoppingCart.DAL.Product();

            Model.Product productEdit = new Model.Product()
            {
                ID = resultId,
                Model = "_productEdit.Model",
                ProductCode = "_productEdit.ProductCode",
                ProductName = "_productEdit.ProductName",
                ProductDescription = "_productEdit.ProductDescription",
                CategoryID = 1,
                Brand = "_productEdit.Brand",
                UnitPrice = new decimal(10.2),
                SKU = "_productEdit.SKU",
                CurrentStock = 2,
                IsActive = false,
                CreatedOn = DateTime.Now.AddDays(-1),
                UpdatedOn = DateTime.Now.AddDays(3),
                CreatedByUserID = 3,
                UpdatedByUserID = 4
            };
            var result=productObj.UpdateProduct(productEdit);
            Assert.IsTrue(result.Success, "Edit product successful");
        }

        [TestMethod]
        public void DeleteProduct()
        {
            if (resultId == 0)
                return;
            OnlineShoppingCart.DAL.Product productObj = new OnlineShoppingCart.DAL.Product();
            var result=productObj.DeletProduct(resultId);
            Assert.IsTrue(result.Success, "Delete product successful");
        }
    }
}
