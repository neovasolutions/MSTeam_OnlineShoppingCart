using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;

namespace OnlineShoppingCart.Model
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [DisplayName("Product Code")]
        [Required(ErrorMessage = "Product Code cannot be blank")]
        public string ProductCode { get; set; }

        [DataMember]
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name cannot be blank")]
        public string ProductName { get; set; }

        [DataMember]
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }

        [DataMember]
        [DisplayName("Category")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Category cannot be blank")]
        public int CategoryID { get; set; }

        [DataMember]
        public string CategoryName { set; get; }

        [DataMember]
        [DisplayName("Brand")]
        public string Brand { get; set; }

        [DataMember]
        [DisplayName("Model")]
        public string Model { get; set; }

        //[DataType(DataType.Currency)]
        [DisplayName("Unit Price")]
        [Required(ErrorMessage = "Unit Price cannot be blank")]
        [DataMember(IsRequired = true)]
        public decimal UnitPrice { get; set; }

        [DataMember]
        [DisplayName("Stock Keeping Unit")]
        public string SKU { get; set; }

        [DisplayName("Current Stock")]
        [Required(ErrorMessage = "Current Stock cannot be blank")]
        [DataMember(IsRequired = true)]
        public int CurrentStock { get; set; }

        [DataMember]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public DateTime? UpdatedOn { get; set; }

        [DataMember]
        public int CreatedByUserID { get; set; }

        [DataMember]
        public int? UpdatedByUserID { get; set; }

        public List<HttpPostedFileBase> ProductImages { get; set; }

        [DataMember]
        public List<ProductImageInfo> ProductImageInfoList { get; set; }

    }

    public class ProductImageInfo
    {
        public int ProductId { get; set; }
        public string ImageFilePath { get; set; }
        public bool IsIndexImage { get; set; }
    }
}
