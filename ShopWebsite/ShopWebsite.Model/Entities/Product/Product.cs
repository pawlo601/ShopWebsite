using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopWebsite.Model.Entities.Discount;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Products", Schema = "Product")]
    public class Product : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name_of_product")]
        [XmlAttribute("name_of_product")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product name cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of product name should be greater than or equal to 5.")]
        [MaxLength(30, ErrorMessage = "Length of product name should be less than or equal to 30.")]
        public string Name { get; set; }

        [Column("description_of_product")]
        [XmlAttribute("description_of_product")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description of product cannot be empty.")]
        [MinLength(5, ErrorMessage = "Length of product description should be greater than or equal to 5.")]
        [MaxLength(100, ErrorMessage = "Length of product description should be less than or equal to 100.")]
        public string Description { get; set; }

        [XmlElement(ElementName = "cost")]//for xml
        [Required(ErrorMessage = "Cost of product has to be given.")]
        public Cost Cost { get; set; }

        [Column("discount_on_product")]
        [XmlAttribute("discount_on_product")]//for xml
        [Required(ErrorMessage = "Discount has to be given.")]
        public decimal Discount { get; set; }

        [XmlElement(ElementName = "quantity")]//for xml
        [Required(ErrorMessage = "Quantity of product has to be given.")]
        public Quantity Quantity { get; set; }

        [XmlArray(ElementName = "product_discounts")]//for xml
        [XmlArrayItem("discount", Type = typeof(ProductDiscount))]//for xml
        public IList<ProductDiscount> ProductDiscounts { get; set; } 
        #endregion

        public Product(int productId = -1)
        {
            Random rand = new Random();
            Id = productId;
            Name = "Product name " + rand.Next()%100000;
            Description = "Description of product " + rand.Next()%1000000;
            Cost = new Cost(productId);
            Discount = rand.Next()%100/100;
            Quantity = new Quantity();
            ProductDiscounts = new List<ProductDiscount>();
        }

        public Product(int id, string name, string description, Cost cost, decimal discount, Quantity quantity, IList<ProductDiscount> productDiscounts)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            Discount = discount;
            Quantity = quantity;
            ProductDiscounts = productDiscounts;
        }

        public void SetCostGoodProductId()
        {
            Cost.ProductId = Id;
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
                foreach (ProductDiscount discount in ProductDiscounts)
                {
                    results.AddRange(discount.Validate(validationContext));
                }
            }
            return results;
        }
    }
}
