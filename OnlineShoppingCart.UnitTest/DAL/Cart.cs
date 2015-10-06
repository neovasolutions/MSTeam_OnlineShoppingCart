using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ValidationResult.Framework;
namespace OnlineShoppingCart.UnitTest
{
    [TestClass]
    public class Cart
    {
        public static int resultId;
        [TestMethod]
        public void InsertCartItem()
        {
            DAL.Cart cartObj = new DAL.Cart();

            Model.CartItem cartInsert = new Model.CartItem()
            {
                UserId=3,
                ProductId = 187,
                Quantity = 1,
                UnitPrice = 100,
                AddedDate = DateTime.Now
            };

            var result = cartObj.AddCartItem(cartInsert);
            resultId = Convert.ToInt32(result.returnValue);
            Assert.IsTrue(result.Success, "Insert successful");
        }

        [TestMethod]
        public void DeleteCartItem()
        {
            DAL.Cart cartObj = new DAL.Cart();
            var result = cartObj.DeletCartItem(3);
            Assert.IsTrue(result.Success, "Delete successful");
        }

        [TestMethod]
        public void UpdateQty()
        {
            DAL.Cart cartObj = new DAL.Cart();
            var result = cartObj.UpdateQty(2,3);
            Assert.IsTrue(result.Success, "Update successful");
        }

        [TestMethod]
        public void GetCart()
        {
            DAL.Cart cartObj = new DAL.Cart();
            var result = cartObj.GetCart(2);
            Assert.IsTrue(result.Success, "Get successful");
        }
    }
}
