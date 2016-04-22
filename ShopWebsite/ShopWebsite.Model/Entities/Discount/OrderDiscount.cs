using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    public class OrderDiscount : MainDiscount
    {
        #region variables
        [Column("order_id")]
        [XmlAttribute("order_id")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Order id cannot be empty.")]
        public int OrderId { get; set; }
        #endregion

        public OrderDiscount() { }

        public OrderDiscount(int id, int orderId, Discount discount)
        {
            Id = id;
            OrderId = orderId;
            Discount = discount;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(OrderId,
                new ValidationContext(this, null, null) { MemberName = "OrderId" },
                results);
            return results;
        }
    }
}
