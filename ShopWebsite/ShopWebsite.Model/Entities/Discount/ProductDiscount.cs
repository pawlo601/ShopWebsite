using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    [Table("Product_discounts", Schema = "Discount")]
    public class ProductDiscount : MainDiscount, IIntroduceable
    {
        #region variables

        [Column("product_id")]
        [XmlAttribute("product_id")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product id cannot be empty.")]
        public int ProductId { get; set; }

        #endregion

        #region methods
        public ProductDiscount()
        {
        }

        public ProductDiscount(int id, int productId, Discount discount)
        {
            Id = id;
            ProductId = productId;
            Discount = discount;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(ProductId,
                new ValidationContext(this, null, null) {MemberName = "ProductId"},
                results);
            return results;
        }

        public int GetId()
        {
            return Id;
        }
        #endregion
    }
}
