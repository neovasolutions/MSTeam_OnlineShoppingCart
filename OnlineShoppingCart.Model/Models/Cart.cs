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
    public class Cart
    {
        [DataMember]
        public int Id { get; set; }

        [DisplayName("Created Date")]
        [Required(ErrorMessage = "Created Date can not be blank")]
        [DataMember(IsRequired = true)]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Total Amount")]
        [Required(ErrorMessage = "Total Amount can not be blank")]
        [DataMember(IsRequired = true)]
        public Decimal TotalAmount { get; set; }

        [DisplayName("User Id")]
        [DataMember]
        public int? UserId { get; set; }

        [DisplayName("Is Active")]
        [Required(ErrorMessage = "Is Active can not be blank")]
        [DataMember(IsRequired = true)]
        public bool IsActive { get; set; }

        [DataMember]
        public List<CartItem> CartItemList { get; set; }
    }

    [DataContract]
    public class CartItem
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public int CartId { get; set; }

        [Required(ErrorMessage = "Product id is mandatory")]
        [DataMember(IsRequired = true)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is mandatory")]
        [DataMember(IsRequired = true)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit price is mandatory")]
        [DataMember(IsRequired = true)]
        public Decimal UnitPrice { get; set; }

        [DataMember]
        public Decimal SubTotal { get; set; }

        [Required(ErrorMessage = "Added date is mandatory")]
        [DataMember(IsRequired = true)]
        public DateTime AddedDate { get; set; }
        
        [Required(ErrorMessage = "User id is mandatory")]
        [DataMember(IsRequired = true)]
        public int UserId { get; set; }
    }
}
