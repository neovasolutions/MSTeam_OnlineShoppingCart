using OnlineShoppingCart.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidationResult.Framework;

namespace OnlineShoppingCart.DAL
{
    public class ProductImage
    {
        public Result<List<OnlineShoppingCart.Model.ProductImageInfo>> GetListProductImageFilePath(int productId)
        {
            using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
            {
                var result = new Result<List<OnlineShoppingCart.Model.ProductImageInfo>>();
                List<OnlineShoppingCart.DataAccess.SQL.ProductImageFilePath> lstProductImageFilePath = (from prod in entity.ProductImageFilePaths
                                                                                                        where prod.ProductId == productId
                                                                                                        select prod).ToList();

                if (lstProductImageFilePath == null || lstProductImageFilePath.Count == 0)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Message = "No product image path information found";
                }
                else
                {
                    result.Data = new List<Model.ProductImageInfo>();
                    foreach (var productImageFilePath in lstProductImageFilePath)
                    {
                        OnlineShoppingCart.Model.ProductImageInfo productImageInfo = null;
                        productImageFilePath.ConvertToBusinessObject(out productImageInfo);
                        result.Data.Add(productImageInfo);
                    }
                }
                return result;
            }
        }

        public ValidationResult_OSC AddListProductImageFilePath(List<OnlineShoppingCart.Model.ProductImageInfo> lstProductImageInfo)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                {
                    foreach (var productImageInfo in lstProductImageInfo)
                    {
                        OnlineShoppingCart.DataAccess.SQL.ProductImageFilePath _product = new DataAccess.SQL.ProductImageFilePath
                        {
                            ProductId = productImageInfo.ProductId,
                            ImageFilePath = productImageInfo.ImageFilePath,
                            IsIndexImage = productImageInfo.IsIndexImage
                        };
                        entity.ProductImageFilePaths.Add(_product);
                    }
                    entity.SaveChanges();

                    result.Success = true;
                    result.Message = "Product image path information inserted successfully";
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
    }
}