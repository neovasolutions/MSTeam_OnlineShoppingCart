using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineShoppingCart.DAL;
using System.Collections.Specialized;
using System.Net;

namespace OnlineShoppingCart.Winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string URL = "http://localhost:50639/api/Product";
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
            var result = client.UploadValues(new Uri(URL), "GET", data);
            string reply = Encoding.ASCII.GetString(result).Replace('"', '\0');
            int id;
            Int32.TryParse(reply, out id);
        }

        void client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            
//using (var client = new HttpClient())
//           {
//               client.BaseAddress = new Uri("http://localhost:65268/");
//               client.DefaultRequestHeaders.Accept.Clear();
//               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

             
//               var response1 = await client.DeleteAsync("api/person/1");

//               // HTTP GET
//               HttpResponseMessage response = await client.GetAsync("api/person");
//               if (response.IsSuccessStatusCode)
//               {
//                   var lst= response.Content.ReadAsAsync<IEnumerable<Person>>();
//                   int a=120;
//                   // Console.WriteLine("{0}\t${1}\t{2}", person.Name, person.Age );
//               }
        }
    }
}
