using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Costs", Schema = "Product")]
    public class Cost : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("product_id")]
        [XmlAttribute("product_id")]//for xml
        [Required(ErrorMessage = "Product id cannot be empty.")]
        public int ProductId { get; set; }

        [Column("tax")]
        [XmlAttribute("tax")]//for xml
        [Required(ErrorMessage = "Tax cannot be empty.")]
        public double Tax { get; set; }

        [XmlArray(ElementName = "prices")]//for xml
        [XmlArrayItem("price", Type = typeof(Price))]//for xml
        public IList<Price> Prices { get; set; }
        #endregion

        public Cost(int productId = -1)
        {
            Random rand = new Random();
            Id = -1;
            ProductId = productId;
            Tax = rand.Next()%1000/1000;
            int p = rand.Next()%5;
            Prices = new List<Price>();
            for (int i = 0; i < p; i++)
            {
                Prices.Add(new Price());
            }
        }

        public Cost(int id, int productId, double tax, IList<Price> prices)
        {
            Id = id;
            ProductId = productId;
            Tax = tax;
            Prices = prices;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(ProductId,
                new ValidationContext(this, null, null) {MemberName = "ProductId"},
                results);
            if (ProductId < 0)
            {
                results.Add(new ValidationResult("Product id must be greater than 0.", new[] {"ProductId"}));
            }
            Validator.TryValidateProperty(Tax,
                new ValidationContext(this, null, null) {MemberName = "Tax"},
                results);
            if (Tax < 0.0)
            {
                results.Add(new ValidationResult("Tax must be greater than or equal 0%.", new[] {"Tax"}));
            }
            if (Tax > 1.0)
            {
                results.Add(new ValidationResult("Tax must be smaller than or equal 100%.", new[] { "Tax" }));
            }
            if (Prices != null)
            {
                foreach (Price price in Prices)
                {
                    results.AddRange(price.Validate(validationContext));
                }
            }
            return results;
        }
    }
}
