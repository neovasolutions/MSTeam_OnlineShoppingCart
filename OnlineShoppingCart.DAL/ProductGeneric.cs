using OnlineShoppingCart.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidationResult.Framework;

namespace OnlineShoppingCart.DAL
{
    public class ProductGeneric
    {
        public Result<List<OnlineShoppingCart.Model.Product>> GetProductList_GenericSearch(string productInfo, int categoryID)
        {
            var result = new Result<List<OnlineShoppingCart.Model.Product>>();
            result.Data = new List<Model.Product>();
            using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
            {
                var listProd = (from prod in entity.Products.Include("ProductCategories")
                                where (((productInfo == null || productInfo.Trim() == "")
                                  || prod.ProductCode.Contains(productInfo)
                                  || prod.ProductName.Contains(productInfo)
                                  || prod.ProductDescription.Contains(productInfo)
                                  || prod.Brand.Contains(productInfo)
                                  || prod.Model.Contains(productInfo))) && (categoryID == prod.CategoryId)
                                select new OnlineShoppingCart.Model.Product
                                {
                                    ID = prod.Id,
                                    ProductCode = prod.ProductCode,
                                    ProductName = prod.ProductName,
                                    ProductDescription = prod.ProductDescription,
                                    CategoryID = prod.CategoryId,
                                    CategoryName = prod.ProductCategory.Category,
                                    Brand = prod.Brand,
                                    Model = prod.Model,
                                    UnitPrice = prod.UnitPrice,
                                    SKU = prod.SKU,
                                    CurrentStock = prod.CurrentStock,
                                    IsActive = prod.IsActive,
                                    CreatedOn = prod.CreatedOn,
                                    UpdatedOn = prod.UpdatedOn,
                                    CreatedByUserID = prod.CreatedByUserId,
                                    UpdatedByUserID = prod.UpdatedByUserId
                                }).ToList();

                if (listProd == null)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Message = "No product found for given search criteria";
                }
                else
                {
                    foreach (var _product in listProd)
                    {
                        DAL.ProductImage productImage = new ProductImage();
                        var resultProductImageList = productImage.GetListProductImageFilePath(_product.ID);

                        if (resultProductImageList.Success)
                            _product.ProductImageInfoList = resultProductImageList.Data;

                        result.Data.Add(_product);
                    }
                    result.Success = true;
                }
            }
            return result;
        }
    }
}
