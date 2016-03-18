using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Column("NAME_OF_PRODUCT")]
        public string ProductName { get; set; }
        [Column("DESCRIPTION_OF_PRODUCT")]
        public string ProductDescription { get; set; }
        [Column("QUANTITY_PER_UNIT")]
        public decimal QuantityPerUnit { get; set; }
        [Column("PRICE_PER_UNIT")]
        public decimal PricePerUnit { get; set; }
    }
}
