using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("POSITIONS_IN_THE_ORDERS")]
    public class PositionInTheOrder : IValidatableObject
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionInTheOrderID { get; set; }

        [Column("PRODUCT_ID")]
        public int ProductID { get; set; }

        [Column("CUSTOMER_ID")]
        public int CustomerID { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }
        public PositionInTheOrder() { }

        public PositionInTheOrder(int id, int productID, int customerID, int quantity)
        {
            PositionInTheOrderID = id;
            ProductID = productID;
            CustomerID = customerID;
            Quantity = quantity;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Quantity <= 0)
            {
                results.Add(new ValidationResult("Quantity of product should be greater than 0.0", new string[] { "Quantity" }));
            }
            return results;
        }
    }
}
