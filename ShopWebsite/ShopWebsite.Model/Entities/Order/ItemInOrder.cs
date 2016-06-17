using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Order
{
    [Table("Items", Schema = "Order")]
    public class Item : IValidatableObject, IIntroduceable
    {
        #region variables

        [Key]
        [Column("item_id")]
        [XmlElement(ElementName = "id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("product_id")]
        [XmlElement(ElementName = "product_id")] //for xml
        [Required(ErrorMessage = "Product id has to be given")]
        public int ProductId { get; set; }

        [Column("quantity")]
        [XmlElement(ElementName = "quantity")] //for xml
        [Required(ErrorMessage = "Quantity has to be given")]
        public int Quantity { get; set; }

        #endregion

        #region methods
        public Item()
        {
        }

        public Item(int id, int productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Quantity <= 0)
            {
                results.Add(new ValidationResult("Quantity of product should be greater than 0.0", new[] { "Quantity" }));
            }
            return results;
        }

        public int GetId()
        {
            return Id;
        }
        #endregion
    }
}
