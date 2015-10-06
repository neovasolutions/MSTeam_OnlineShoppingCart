using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineShoppingCart.UnitTest.API
{
    [TestClass]
    public class Product
    {
        //change this url as per hosed port number 
        static string URL = "http://localhost:90/api/Product";

        [TestMethod]
        public void GetProduct()
        {
            AsyncGetProduct().Wait();
        }

        static async Task AsyncGetProduct()
        {
            HttpClient hcl = new HttpClient();
            HttpResponseMessage response = await hcl.GetAsync(URL+"/10");
            Assert.IsTrue(response.IsSuccessStatusCode, "API get successful");
        }

        [TestMethod]
        public void DeleteProduct()
        {
            AsyncDeleteProduct().Wait();
        }

        static async Task AsyncDeleteProduct()
        {
            HttpClient hcl = new HttpClient();
            HttpResponseMessage response = await hcl.DeleteAsync(URL+"/14");
            Assert.IsTrue(response.IsSuccessStatusCode, "API Delete successful");
        }

        [TestMethod]
        public void InsertProduct()
        {
            NameValueCollection data = new NameValueCollection();
            data.Add("ProductName", "Johannes");
            data.Add("ProductCode", "THTEHT432");
            data.Add("ProductDescription", "desc");
            data.Add("CategoryID", "1");
            data.Add("Brand", "Brand");
            data.Add("UnitPrice", "2");
            data.Add("SKU", "SKU");
            data.Add("CurrentStock", "1");
            data.Add("IsActive", "true");
            data.Add("CreatedOn", "02/09/2015");
            data.Add("UpdatedOn", "02/09/2015");
            data.Add("CretedByUserID", "1");
            data.Add("UpdatedByUserID", "1");

            WebClient client = new WebClient();
            //client.UploadValuesCompleted += client_UploadValuesCompleted;
            client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            //Task t = client.UploadValuesTaskAsync(new Uri(URL), "POST", data);
            var result = client.UploadValues(new Uri(URL), "POST", data);
            string reply = Encoding.ASCII.GetString(result);
            Assert.IsTrue(!String.IsNullOrEmpty(reply), "API Insert successful");
        }

        [TestMethod]
        public void EditProduct()
        {
            NameValueCollection data = new NameValueCollection();
            data.Add("ID", "18");
            data.Add("ProductName", "Product name edited by API test method");
            data.Add("ProductCode", "Product code edited by API test method");
            data.Add("ProductDescription", "Product description edited by API test method");
            data.Add("CategoryID", "1");
            data.Add("Brand", "Brand Edited by API");
            data.Add("UnitPrice", "3");
            data.Add("SKU", "SKU Edited by API");
            data.Add("CurrentStock", "2");
            data.Add("IsActive", "false");
            data.Add("CreatedOn", "03/09/2015");
            data.Add("UpdatedOn", "04/09/2015");
            data.Add("CretedByUserID", "3");
            data.Add("UpdatedByUserID", "3");

            WebClient client = new WebClient();
            //client.UploadValuesCompleted += client_UploadValuesCompleted;
            client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            //Task t = client.UploadValuesTaskAsync(new Uri(URL), "POST", data);
            var result = client.UploadValues(new Uri(URL), "PUT", data);
            string reply = Encoding.ASCII.GetString(result);
            Assert.IsTrue(!String.IsNullOrEmpty(reply), "API Edit successful");
        }
    }
}
