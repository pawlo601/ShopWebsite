using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("POSITIONS_IN_THE_ORDERS")]
    public class PositionInTheOrder
    {
        [Column("PRODUCT_ID")]
        public int ProductID { get; set; }
        [Column("CUSTOMER_ID")]
        public int CustomerID { get; set; }
        [Column("QUANTITY")]
        public int Quantity { get; set; }
        public PositionInTheOrder(int productID, int customerID, int quantity)
        {
            ProductID = productID;
            CustomerID = customerID;
            Quantity = quantity;
        }
    }
}
