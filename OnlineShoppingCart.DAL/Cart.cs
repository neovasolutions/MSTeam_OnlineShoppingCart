using OnlineShoppingCart.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidationResult.Framework;
using System.Transactions;

namespace OnlineShoppingCart.DAL
{
    public class Cart
    {
        public Result<OnlineShoppingCart.Model.Cart> GetCart(int userId)
        {
            var result = new Result<OnlineShoppingCart.Model.Cart>();
            Model.Cart _cart = null;
            using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
            {
                var cart = entity.Carts.Where(c => c.UserId == userId && c.IsActive).First();

                if (cart == null)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Message = "No cart found for this user";
                    return result;
                }

                cart.ConvertToBusinessObject(out _cart);
                _cart.CartItemList = new List<Model.CartItem>();
                var cartItemList = entity.CartItems.Where(ci => ci.CartId == _cart.Id).ToList();
                foreach (var ci in cartItemList)
                {
                    Model.CartItem ciModel;
                    ci.ConvertToBusinessObject(out ciModel);
                    _cart.CartItemList.Add(ciModel);
                }
            }
            result.Data = _cart;
            result.Message = "No cart found for this user";
            return result;
        }

        public ValidationResult_OSC AddCartItem(OnlineShoppingCart.Model.CartItem cartItem)
        {
            var result = new ValidationResult_OSC();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                    {
                        int userId = cartItem.UserId;
                        var cart = (from carts in entity.Carts
                                    where (carts.UserId == userId && carts.IsActive == true)
                                    select carts).FirstOrDefault();

                        if (cart == null)
                        {
                            cart = new OnlineShoppingCart.DataAccess.SQL.Cart();
                            cart.IsActive = true;
                            cart.UserId = userId;
                            cart.CreatedDate = DateTime.Now;
                            entity.Carts.Add(cart);

                        }

                        OnlineShoppingCart.DataAccess.SQL.CartItem _cartItem = new DataAccess.SQL.CartItem
                        {
                            CartId = cart.Id,
                            ProductId = cartItem.ProductId,
                            Quantity = cartItem.Quantity,
                            UnitPrice = cartItem.UnitPrice,
                            SubTotal = cartItem.UnitPrice * cartItem.Quantity,
                            AddedDate = cartItem.AddedDate
                        };


                        entity.CartItems.Add(_cartItem);
                        entity.SaveChanges();
                        cart.TotalAmount = CalculateTotalAmount(_cartItem.CartId, entity);

                        entity.SaveChanges();
                        result.Success = true;
                        result.returnValue = Convert.ToString(_cartItem.Id);
                        result.Message = "Cart items inserted successfully";
                        scope.Complete();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public ValidationResult_OSC UpdateQty(int cartItemId, int quantity)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                {
                    var _cartItem = (from t in entity.CartItems
                                     where t.Id == cartItemId
                                     select t).First();

                    _cartItem.Quantity = quantity;
                    _cartItem.SubTotal = quantity * _cartItem.UnitPrice;
                    entity.SaveChanges();

                    var cart = (from c in entity.Carts
                                where c.Id == _cartItem.CartId
                                select c).First();

                    cart.TotalAmount = CalculateTotalAmount(_cartItem.CartId, entity);
                    entity.SaveChanges();

                    result.Success = true;
                    result.Message = "Cart item updated successfully";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return result;
            }
        }

        public ValidationResult_OSC DeletCartItem(int cartItemId)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                    {
                        var cartItem = (from t in entity.CartItems
                                        where t.Id == cartItemId
                                        select t).First();

                        var cart = (from c in entity.Carts
                                    where c.Id == cartItem.CartId
                                    select c).First();

                        entity.CartItems.Remove(cartItem);
                        entity.SaveChanges();
                        cart.TotalAmount = CalculateTotalAmount(cartItem.CartId, entity);
                        entity.SaveChanges();

                        result.Success = true;
                        result.Message = "Cart item deleted successfully";
                        scope.Complete();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return result;
            }
        }

        Decimal CalculateTotalAmount(int cartId, OnlineShoppingCartEntities entity)
        {
            int total = entity.CartItems.Count(item=>item.CartId==cartId);
            //var total = entity.CartItems.Where(t=>t.CartId==cartId).Sum(t => t.SubTotal);
            if (total == 0)
                return 0;
            else
                return entity.CartItems.Where(t => t.CartId == cartId).Sum(t => t.SubTotal);
        }
    }
}
