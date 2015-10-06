using OnlineShoppingCart.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidationResult.Framework;

namespace OnlineShoppingCart.DAL
{
    public class Product
    {
        public Result<List<OnlineShoppingCart.Model.Product>> GetProductList(OnlineShoppingCart.Model.Product product)
        {
            var result = new Result<List<OnlineShoppingCart.Model.Product>>();
            result.Data = new List<Model.Product>();
            using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
            {

                var listProd = (from prod in entity.Products.Include("ProductCategories")
                                where ((product.ProductCode == null) || prod.ProductCode.Contains(product.ProductCode))
                                  && ((product.ProductName == null) || prod.ProductName.Contains(product.ProductName))
                                  && ((product.ProductDescription == null) || prod.ProductDescription.Contains(product.ProductDescription))
                                  && (product.CategoryID == 0 || prod.CategoryId == product.CategoryID)
                                  && ((product.Brand == null) || prod.Brand.Contains(product.Brand))
                                  && ((product.Model == null) || prod.Model.Contains(product.Model))
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

        public Result<OnlineShoppingCart.Model.Product> GetProduct(int id)
        {
            using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
            {
                var result = new Result<OnlineShoppingCart.Model.Product>();
                OnlineShoppingCart.DataAccess.SQL.Product _product = (from prod in entity.Products
                                                                      where prod.Id == id
                                                                      select prod).FirstOrDefault();
                if (_product == null)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Message = "No product found";
                }
                else
                {
                    OnlineShoppingCart.Model.Product _productModel = null;
                    _product.ConvertToBusinessObject(out _productModel);

                    DAL.ProductImage productImage = new ProductImage();
                    var resultProductImageList = productImage.GetListProductImageFilePath(_productModel.ID);

                    if (resultProductImageList.Success)
                        _productModel.ProductImageInfoList = resultProductImageList.Data;

                    result.Data = _productModel;
                }
                return result;
            }
        }

        public Result<List<OnlineShoppingCart.Model.Product>> GetAllProduct()
        {
            var result = new Result<List<OnlineShoppingCart.Model.Product>>();
            result.Data = new List<Model.Product>();
            using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
            {
                var listProd = entity.Products.ToList();

                if (listProd == null)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Message = "No product found";
                }
                else
                {
                    foreach (var it in listProd)
                    {
                        OnlineShoppingCart.Model.Product _product = null;
                        it.ConvertToBusinessObject(out _product);

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

        public ValidationResult_OSC AddProduct(OnlineShoppingCart.Model.Product product)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                {
                    OnlineShoppingCart.DataAccess.SQL.Product _product = new DataAccess.SQL.Product
                    {
                        Model = product.Model,
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        CategoryId = product.CategoryID,
                        Brand = product.Brand,
                        UnitPrice = product.UnitPrice,
                        SKU = product.SKU,
                        CurrentStock = product.CurrentStock,
                        IsActive = product.IsActive,
                        CreatedOn = product.CreatedOn,
                        UpdatedOn = product.UpdatedOn,
                        CreatedByUserId = product.CreatedByUserID,
                        UpdatedByUserId = product.UpdatedByUserID
                    };
                    entity.Products.Add(_product);
                    entity.SaveChanges();

                    result.Success = true;
                    result.returnValue = Convert.ToString(_product.Id);
                    result.Message = "Product inserted successfully";
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

        public ValidationResult_OSC UpdateProduct(OnlineShoppingCart.Model.Product product)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                {
                    var _p = (from t in entity.Products
                              where t.Id == product.ID
                              select t).First();

                    _p.Model = product.Model;
                    _p.ProductCode = product.ProductCode;
                    _p.ProductName = product.ProductName;
                    _p.ProductDescription = product.ProductDescription;
                    _p.CategoryId = product.CategoryID;
                    _p.Brand = product.Brand;
                    _p.UnitPrice = product.UnitPrice;
                    _p.SKU = product.SKU;
                    _p.CurrentStock = product.CurrentStock;
                    _p.IsActive = product.IsActive;
                    _p.CreatedOn = product.CreatedOn;
                    _p.UpdatedOn = product.UpdatedOn;
                    _p.CreatedByUserId = product.CreatedByUserID;
                    _p.UpdatedByUserId = product.UpdatedByUserID;

                    entity.SaveChanges();
                    result.Success = true;
                    result.Message = "Product updated successfully";
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

        public ValidationResult_OSC DeletProduct(int productId)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                {
                    var product = (from t in entity.Products
                                   where t.Id == productId
                                   select t).First();

                    entity.Products.Remove(product);
                    entity.SaveChanges();

                    result.Success = true;
                    result.Message = "Product deleted successfully";
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
    }
}
