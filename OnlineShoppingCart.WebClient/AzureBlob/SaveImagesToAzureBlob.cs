using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ValidationResult.Framework;
using OnlineShoppingCart.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OnlineShoppingCart.WebClient.AzureBlob
{
    public class SaveImagesToAzureBlob
    {
        public async Task<bool> SaveImageToBlob(List<HttpPostedFileBase> files, int prodID)
        {            
            string fullPath;
            ProductImageInfo prodImageInfo = new ProductImageInfo();
            List<ProductImageInfo> prodImageInfoList = new List<ProductImageInfo>();
            Result<ValidationResult_OSC> result = new Result<ValidationResult_OSC>();
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("imagecontainer");
                foreach (HttpPostedFileBase file in files)
                {
                    string uniqueBlobName = string.Format("productimages/image_{0}_{1}", prodID, Guid.NewGuid().ToString());
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(uniqueBlobName);
                    blockBlob.Properties.ContentType = file.ContentType;
                    blockBlob.UploadFromStream(file.InputStream);
                    var uriBuilder = new UriBuilder(blockBlob.Uri);
                    fullPath = uriBuilder.ToString();            
                    //Create Product List<ProductImageInfo> Object to send to WEB API.
                    prodImageInfo.ProductId = prodID;
                    prodImageInfo.ImageFilePath = fullPath;
                    prodImageInfo.IsIndexImage = false;
                    prodImageInfoList.Add(prodImageInfo);                    
                }
                using (var client = new HttpClient())
                {
                    string url = System.Configuration.ConfigurationManager.AppSettings["ProductAPI"];
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Product/ProductImageInfo", prodImageInfoList);
                    if (response.IsSuccessStatusCode)                    {
                        result = await response.Content.ReadAsAsync<Result<ValidationResult_OSC>>();
                        if (result.Success == true)
                            return true;
                        else
                            return false;
                    }                      
                }
                return false;                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}