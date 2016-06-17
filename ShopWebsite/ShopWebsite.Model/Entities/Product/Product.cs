using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Products", Schema = "Product")]
    public class Product : IValidatableObject, IIntroduceable
    {
        #region variables

        [Key]
        [Column("product_id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name_of_product")]
        [XmlAttribute("name_of_product")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product name cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of product name should be greater than or equal to 5.")]
        [MaxLength(30, ErrorMessage = "Length of product name should be less than or equal to 30.")]
        public string Name { get; set; }

        [Column("description_of_product")]
        [XmlAttribute("description_of_product")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description of product cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of product description should be greater than or equal to 5.")]
        [MaxLength(100, ErrorMessage = "Length of product description should be less than or equal to 100.")]
        public string Description { get; set; }

        [XmlElement(ElementName = "cost")] //for xml
        [Required(ErrorMessage = "Cost of product has to be given.")]
        public Cost Cost { get; set; }

        [Column("discount_on_product")]
        [XmlAttribute("discount_on_product")] //for xml
        [Required(ErrorMessage = "Discount has to be given.")]
        public decimal Discount { get; set; }

        [XmlElement(ElementName = "quantity")] //for xml
        [Required(ErrorMessage = "Quantity of product has to be given.")]
        public Quantity Quantity { get; set; }

        [XmlArray(ElementName = "product_discounts")] //for xml
        [XmlArrayItem("discount", Type = typeof(ProductDiscount))] //for xml
        public ICollection<ProductDiscount> ProductDiscounts { get; set; }

        #endregion

        #region methods
        public Product()
        {
        }

        public Product(int id, string name, string description, Cost cost, decimal discount, Quantity quantity,
            ICollection<ProductDiscount> productDiscounts)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            Discount = discount;
            Quantity = quantity;
            ProductDiscounts = productDiscounts;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(Description,
                new ValidationContext(this, null, null) { MemberName = "Description" },
                results);
            Validator.TryValidateProperty(Discount,
                new ValidationContext(this, null, null) { MemberName = "Discount" },
                results);
            if (Discount < 0.0M)
            {
                results.Add(new ValidationResult("Discount should be greater than or equal to 0.", new[] { "Discount" }));
            }
            if (Cost != null)
            {
                results.AddRange(Cost.Validate(validationContext));
            }
            if (Quantity != null)
            {
                results.AddRange(Quantity.Validate(validationContext));
            }
            if (ProductDiscounts != null)
            {
                foreach (ProductDiscount productDiscount in ProductDiscounts)
                {
                    results.AddRange(productDiscount.Validate(validationContext));
                }
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
