using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    public abstract class Customer : User
    {
        #region variables

        [Column("contact_title")]
        [XmlAttribute("contact_title")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact title cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of contact title should be greater than or equal to 3.")]
        [MaxLength(10, ErrorMessage = "Length of contact title should be less than or equal to 10.")]
        public string ContactTitle { get; set; }

        [XmlArray(ElementName = "orders")] //for xml
        [XmlArrayItem("order", Type = typeof (Order.Order))] //for xml
        public List<Order.Order> Orders { get; set; }

        [XmlArray(ElementName = "discounts")] //for xml
        [XmlArrayItem("discount", Type = typeof (Discount.CustomerDiscount))] //for xml
        public List<Discount.CustomerDiscount> Discounts { get; set; }

        #endregion

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(ContactTitle,
                new ValidationContext(this, null, null) {MemberName = "ContactTitle"},
                results);
            if (Orders != null)
            {
                foreach (Order.Order order in Orders)
                {
                    results.AddRange(order.Validate(validationContext));
                }
            }
            if (Discounts != null)
            {
                foreach (Discount.CustomerDiscount discount in Discounts)
                {
                    results.AddRange(discount.Validate(validationContext));
                }
            }
            return results;
        }
    }
}
