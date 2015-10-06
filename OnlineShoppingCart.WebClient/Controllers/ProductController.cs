using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingCart.Model;
using OnlineShoppingCart.WebClient.AzureBlob;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.IO;
using ValidationResult.Framework;


using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;


namespace OnlineShoppingCart.WebClient.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        List<ProductCategory> prodcatList = new List<ProductCategory>();
        List<Product> prodList = new List<Product>();

        public void AddTempData()
        {
            ProductCategory cat1 = new ProductCategory()
            {
                ID = 1,
                Category = "Men & Womens Clothes",
                ParentCategoryID = 1,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2
            };
            ProductCategory cat2 = new ProductCategory()
            {
                ID = 2,
                Category = "footwear",
                ParentCategoryID = 1,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2
            };
            ProductCategory cat3 = new ProductCategory()
            {
                ID = 3,
                Category = "watches",
                ParentCategoryID = 1,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2
            };
            ProductCategory cat4 = new ProductCategory()
            {
                ID = 4,
                Category = "fashion",
                ParentCategoryID = 1,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2
            };
            ProductCategory cat5 = new ProductCategory()
            {
                ID = 5,
                Category = "Books",
                ParentCategoryID = 1,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2
            };

            Product prod1 = new Product()
            {
                ID = 1,
                ProductCode = "2344",
                ProductName = "Revolution 2020",
                ProductDescription = "test",
                CategoryID = 5,
                Brand = "..Publications",
                Model = "test",
                UnitPrice = 500,
                SKU = "some keeping unit",
                CurrentStock = 478,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2,
                //ImageThumbNail=
                //ImageIndex
                //ImageOthers


            };
            Product prod2 = new Product()
            {
                ID = 2,
                ProductCode = "2344",
                ProductName = "Filmfair maghzine",
                ProductDescription = "test",
                CategoryID = 4,
                Brand = "..Publications",
                Model = "test",
                UnitPrice = 500,
                SKU = "some keeping unit",
                CurrentStock = 478,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2,
                //ImageThumbNail=
                //ImageIndex
                //ImageOthers


            };
            Product prod3 = new Product()
            {
                ID = 3,
                ProductCode = "2344",
                ProductName = "Rado",
                ProductDescription = "test",
                CategoryID = 3,
                Brand = "..Publications",
                Model = "test",
                UnitPrice = 500,
                SKU = "some keeping unit",
                CurrentStock = 478,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2,
                //ImageThumbNail=
                //ImageIndex
                //ImageOthers


            };
            Product prod4 = new Product()
            {
                ID = 4,
                ProductCode = "2344",
                ProductName = "bata",
                ProductDescription = "test",
                CategoryID = 2,
                Brand = "..Publications",
                Model = "test",
                UnitPrice = 500,
                SKU = "some keeping unit",
                CurrentStock = 478,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2,
                //ImageThumbNail=
                //ImageIndex
                //ImageOthers


            };
            Product prod5 = new Product()
            {
                ID = 5,
                ProductCode = "2344",
                ProductName = "Pepe Jeans",
                ProductDescription = "test",
                CategoryID = 1,
                Brand = "..Publications",
                Model = "test",
                UnitPrice = 500,
                SKU = "some keeping unit",
                CurrentStock = 478,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2,
                //ImageThumbNail=
                //ImageIndex
                //ImageOthers


            };

            Product prod6 = new Product()
            {
                ID = 6,
                ProductCode = "2344",
                ProductName = "Lee Cooper",
                ProductDescription = "test",
                CategoryID = 2,
                Brand = "..Publications",
                Model = "test",
                UnitPrice = 500,
                SKU = "some keeping unit",
                CurrentStock = 478,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2,
                //ImageThumbNail=
                //ImageIndex
                //ImageOthers


            };

            Product prod7 = new Product()
            {
                ID = 7,
                ProductCode = "2344",
                ProductName = "Red Chief",
                ProductDescription = "test",
                CategoryID = 2,
                Brand = "..Publications",
                Model = "test",
                UnitPrice = 500,
                SKU = "some keeping unit",
                CurrentStock = 478,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2,
                //ImageThumbNail=
                //ImageIndex
                //ImageOthers


            };
            Product prod8 = new Product()
            {
                ID = 8,
                ProductCode = "2344",
                ProductName = "Goggles",
                ProductDescription = "test",
                CategoryID = 4,
                Brand = "..Publications",
                Model = "test",
                UnitPrice = 500,
                SKU = "stock keeping unit",
                CurrentStock = 478,
                IsActive = true,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedByUserID = 1,
                UpdatedByUserID = 2,
            };

            prodcatList.Add(cat1);
            prodcatList.Add(cat2);
            prodcatList.Add(cat3);
            prodcatList.Add(cat4);
            prodcatList.Add(cat5);

            prodList.Add(prod1);
            prodList.Add(prod2);
            prodList.Add(prod3);
            prodList.Add(prod4);
            prodList.Add(prod5);
            prodList.Add(prod6);
            prodList.Add(prod7);
            prodList.Add(prod8);

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.ProductCategories = prodcatList;
            ViewBag.Products = prodList;
        }
        public PartialViewResult Index()
        {
            return PartialView("_ProductIndex");
        }

        public async Task<ActionResult> Prod_Read([DataSourceRequest]DataSourceRequest request, string productCode, string productName, string productDescription, string categoryID, string brand, string model)
        {
            //AddTempData();           
            Result<List<Product>> allProductsWithResult = new Result<List<Product>>();
            int catID;
            bool converted = Int32.TryParse(categoryID, out catID);


            string ProductCode = productCode;
            string ProductName = productName;
            string ProductDescription = productDescription;
            int CategoryID = catID;
            string Brand = brand;
            string Model = model;

            if (string.IsNullOrWhiteSpace(ProductCode) && string.IsNullOrWhiteSpace(ProductName) && string.IsNullOrWhiteSpace(ProductDescription) && CategoryID == 0 && string.IsNullOrWhiteSpace(Brand) && string.IsNullOrWhiteSpace(Model))
            {
                using (var client = new HttpClient())
                {
                    string url = System.Configuration.ConfigurationManager.AppSettings["ProductAPI"];
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //string uri = string.Format("api/Product/GetSearchProduct?searchAll={0}", true);
                    string uri = string.Format("api/Product/GetSearchProduct");
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        allProductsWithResult = await response.Content.ReadAsAsync<Result<List<Product>>>();
                    }
                }
                List<Product> allProducts = allProductsWithResult.Data;
                DataSourceResult result = allProducts.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            #region COMMENTED
            //Product prodToSearchParams = new Product()
            //  {
            //      ProductCode = productCode,
            //      ProductName = productName,
            //      ProductDescription = productDescription,
            //      CategoryID = catID,
            //      Brand = brand,
            //      Model = model
            //  };
            #endregion
            else
            {
                using (var client = new HttpClient())
                {
                    string url = System.Configuration.ConfigurationManager.AppSettings["ProductAPI"];
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //string uri = String.Format("api/Product?product.ProductCode={0}&product.ProductName={1}&product.ProductDescription={2}&product.CategoryID={3}&product.Brand={4}&product.Model={5}", ProductCode,
                    //                      ProductName, ProductDescription, CategoryID, Brand, Model);
                    string uri = String.Format("api/Product/GetSearchProduct?ProductCode={0}&ProductName={1}&ProductDescription={2}&CategoryID={3}&Brand={4}&Model={5}", ProductCode, ProductName, ProductDescription, CategoryID, Brand, Model);

                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        allProductsWithResult = await response.Content.ReadAsAsync<Result<List<Product>>>();
                    }
                }
                List<Product> allProducts = allProductsWithResult.Data;
                DataSourceResult result = allProducts.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }




        }

        [HttpGet]
        public PartialViewResult GetProductEntryForm()
        {
            return PartialView("_ProductEntry");
        }

        [HttpGet]
        public async Task<PartialViewResult> GetProduct(int proID)
        {
            Result<Product> result = new Result<Product>();
            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["ProductAPI"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Product/" + proID);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<Result<Product>>();
                }
            }
            Product product = result.Data;
            ViewBag.Mode = "Edit";
            return PartialView("_ProductEntry", product);
        }

        [HttpPost]
        public async Task<ActionResult> InsertProduct(Product product, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5)
        {
            Result<ValidationResult_OSC> result = new Result<ValidationResult_OSC>();
            int productIDAfterInsertProduct;
            #region PRODUCT INSERT DOUBLE VALIDATION
            if (product == null)
            {
                result.Success = false;
                result.Message = "Can not insert Empty Product!";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            #endregion
            #region IMAGE INSERT VALIDATION

            List<HttpPostedFileBase> prodImageList = new List<HttpPostedFileBase>();
            #region file list
            if (file1 != null)
            {
                prodImageList.Add(file1);
            }
            if (file2 != null)
            {
                prodImageList.Add(file2);
            }
            if (file3 != null)
            {
                prodImageList.Add(file3);
            }
            if (file4 != null)
            {
                prodImageList.Add(file4);
            }
            if (file5 != null)
            {
                prodImageList.Add(file5);
            }
            #endregion

            product.ProductImages = prodImageList;


            if (product.ProductImages.Count == 0)
            {
                result.Success = false;
                result.Message = "Please Upload An Image to Proceed!";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            #endregion
            #region PRODUCT INSERT AND IMAGE INSERT

            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["ProductAPI"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                product.CreatedOn = DateTime.Now;
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Product/InsertProduct", product);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<Result<ValidationResult_OSC>>();
                    if (result.Success == false)
                    {
                        return Json(result, JsonRequestBehavior.AllowGet);

                    }
                    productIDAfterInsertProduct = Int32.Parse(result.returnValue);


                    //save image to azure blob
                    SaveImagesToAzureBlob saveImage = new SaveImagesToAzureBlob();
                    var ImageInsertedToBothDBAndAzure = await saveImage.SaveImageToBlob(product.ProductImages, productIDAfterInsertProduct);

                    if (ImageInsertedToBothDBAndAzure)
                        return Json(result, JsonRequestBehavior.AllowGet);
                    else
                    {
                        result.Success = false;
                        result.Message = "Image not saved";
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    return Json(result, JsonRequestBehavior.AllowGet);

            }
            #endregion
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(Product prodToEdit, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4, HttpPostedFileBase file5)
        {
            Result<ValidationResult_OSC> result = new Result<ValidationResult_OSC>();

            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["ProductAPI"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                prodToEdit.CreatedOn = DateTime.Now;
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Product/", prodToEdit);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<Result<ValidationResult_OSC>>();
                    if (result.Success == true)
                    {
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProduct(int proID)
        {
            Result<ValidationResult_OSC> result = new Result<ValidationResult_OSC>();

            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["ProductAPI"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync("api/Product/" + proID);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<Result<ValidationResult_OSC>>();
                    if (result.Success == true)
                    {
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public async Task<ActionResult> SearchProduct(Product productToSearch)
        //{
        //    Result<List<Product>> searchedProducts = new Result<List<Product>>();
        //    using (var client = new HttpClient())
        //    {
        //        string url = System.Configuration.ConfigurationManager.AppSettings["ProductAPI"];
        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage response = await client.GetAsync("api/Product" + productToSearch);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            searchedProducts = await response.Content.ReadAsAsync<Result<List<Product>>>();
        //        }
        //    }
        //    List<Product> searchedProductsConverted = searchedProducts.Data;
        //    DataSourceResult result = searchedProductsConverted.ToDataSourceResult(request);
        //    return PartialView("_ProductEntry", searchedProducts);

        //}

        [HttpGet]
        public ActionResult LoadProductListGridPartialView()
        {
            //return PartialView("_ProductsGridList");
            return PartialView("_ProductList");
        }

        public async Task<JsonResult> GetCategories()
        {
            //AddTempData();
            //return Json(prodcatList, JsonRequestBehavior.AllowGet);
            Result<List<ProductCategory>> result = new Result<List<ProductCategory>>();
            List<ProductCategory> listCategories = new List<ProductCategory>();
            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["ProductCategoryAPI"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/ProductCategory/");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<Result<List<ProductCategory>>>();
                    if (result.Success == true)
                    {
                        listCategories = result.Data;
                        return Json(listCategories, JsonRequestBehavior.AllowGet);
                    }
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult GetProductCategoryForm()
        {
            return PartialView("_ProductCategory");
        }
        [HttpPost]
        public async Task<JsonResult> AddCategory(ProductCategory prodCategoryToAdd)
        {
             
            ValidationResult_OSC result = new ValidationResult_OSC();
            prodCategoryToAdd.CreatedOn = DateTime.Now.Date;
            prodCategoryToAdd.IsActive = true;
            prodCategoryToAdd.CreatedByUserID = 2;
            prodCategoryToAdd.UpdatedByUserID = 2;
            using (var client = new HttpClient())
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["ProductCategoryAPI"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/ProductCategory/", prodCategoryToAdd);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<ValidationResult_OSC>();
                    if (result.Success == true)
                        return Json(result, JsonRequestBehavior.AllowGet);
                    else
                    {
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                     
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }



    }
}
