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
using System.Net;
using System.Net.Http;

namespace OnlineShoppingCart.API.Cart.Controllers
{
    public class CartItemController : ApiController
    {
        public Result<OnlineShoppingCart.Model.Cart> GetCart(int userId)
        {
            DAL.Cart cart = new DAL.Cart();
            return cart.GetCart(userId);
        }

        // POST api/values
        //[System.Web.Http.ActionName("PostInsertCartItem")]
        public ValidationResult_OSC PostInsertCartItem([FromBody]OnlineShoppingCart.Model.CartItem cartItem)
        {
            var result = new ValidationResult_OSC();
            ValidationHelper validationHelper = new ValidationHelper(ref result, ModelState);

            if (result.Success)
            {
                DAL.Cart cartDAL = new DAL.Cart();
                result = cartDAL.AddCartItem(cartItem);
            }
            return result;
        }

        // PUT api/values/5

        public ValidationResult_OSC PutUpdateQty(int cartItemId, int quantity)
        {
            var result = new ValidationResult_OSC();
            ValidationHelper validationHelper = new ValidationHelper(ref result, ModelState);

            if (result.Success)
            {
                DAL.Cart cartDAL = new DAL.Cart();
                result = cartDAL.UpdateQty(cartItemId, quantity);
            }
            return result;
        }

        // DELETE api/values/5
        public ValidationResult_OSC Delete(int cartItemId)
        {
            DAL.Cart cartDAL = new DAL.Cart();
            return cartDAL.DeletCartItem(cartItemId);
        }
    }
}