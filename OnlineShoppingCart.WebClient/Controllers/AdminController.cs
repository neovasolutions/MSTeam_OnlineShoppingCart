using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingCart.Model;
using System.IO;

namespace OnlineShoppingCart.WebClient.Controllers
{
    public class AdminController : Controller
    {
        
         //GET: /Admin/
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


        public ActionResult Index()
        {
            return View();
        }
 
        


        

    }
}
