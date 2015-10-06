using OnlineShoppingCart.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidationResult.Framework;

namespace OnlineShoppingCart.DAL
{
    public class ProductCategory
    {
        public Result<List<OnlineShoppingCart.Model.ProductCategory>> GetAllCategoryList()
        {
            var result = new Result<List<OnlineShoppingCart.Model.ProductCategory>>();
            result.Data = new List<Model.ProductCategory>();
            using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
            {
                var listProdCat = new List<DataAccess.SQL.ProductCategory>();
                listProdCat = entity.ProductCategories.ToList();

                if (listProdCat == null || listProdCat.Count == 0)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Message = "No product category found";
                }
                else
                {
                    foreach (var prodCat in listProdCat)
                    {
                        OnlineShoppingCart.Model.ProductCategory _productCategory = null;
                        prodCat.ConvertToBusinessObject(out _productCategory);
                        result.Data.Add(_productCategory);
                    }
                    result.Success = true;
                }
            }
            return result;
        }

        public Result<OnlineShoppingCart.Model.ProductCategory> GetCategory(int id)
        {
            using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
            {
                var result = new Result<OnlineShoppingCart.Model.ProductCategory>();
                OnlineShoppingCart.DataAccess.SQL.ProductCategory _productCategory = (from prod in entity.ProductCategories
                                                                                      where prod.Id == id
                                                                                      select prod).FirstOrDefault();
                if (_productCategory == null)
                {
                    result.Success = false;
                    result.Data = null;
                    result.Message = "No product category found.";
                }
                else
                {
                    OnlineShoppingCart.Model.ProductCategory _productCatModel = null;
                    _productCategory.ConvertToBusinessObject(out _productCatModel);
                    result.Data = _productCatModel;
                }
                return result;
            }
        }

        public ValidationResult_OSC AddCategory(OnlineShoppingCart.Model.ProductCategory category)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                {
                    OnlineShoppingCart.DataAccess.SQL.ProductCategory _category = new DataAccess.SQL.ProductCategory
                    {
                        Category = category.Category,
                        IsActive = category.IsActive,
                        CreatedOn = category.CreatedOn,
                        UpdatedOn = category.UpdatedOn,
                        CreatedByUserId = category.CreatedByUserID,
                        UpdatedByUserId = category.UpdatedByUserID
                    };

                    entity.ProductCategories.Add(_category);
                    entity.SaveChanges();

                    result.Success = true;
                    result.returnValue = Convert.ToString(_category.Id);
                    result.Message = "Product category inserted successfully";
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

        public ValidationResult_OSC UpdateCategory(OnlineShoppingCart.Model.ProductCategory category)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                {
                    var _category = (from prodCat in entity.ProductCategories
                                     where prodCat.Id == category.ID
                                     select prodCat).First();

                    _category.Category = category.Category;
                    _category.IsActive = category.IsActive;
                    _category.CreatedOn = category.CreatedOn;
                    _category.UpdatedOn = category.UpdatedOn;
                    _category.CreatedByUserId = category.CreatedByUserID;
                    _category.UpdatedByUserId = category.UpdatedByUserID;

                    entity.SaveChanges();
                    result.Success = true;
                    result.Message = "Product category updated successfully";
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

        public ValidationResult_OSC DeleteCategory(int categoryId)
        {
            var result = new ValidationResult_OSC();
            try
            {
                using (OnlineShoppingCartEntities entity = new OnlineShoppingCartEntities())
                {
                    var category = (from prodCat in entity.ProductCategories
                                    where prodCat.Id == categoryId
                                    select prodCat).First();

                    entity.ProductCategories.Remove(category);
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
