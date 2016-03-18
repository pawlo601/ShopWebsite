using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("ORDERS")]
    public class Order
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Column("DATE_OF_SUBMISSION")]
        public DateTime DateOfSubmission { get; set; }
        [Column("STATUS_OF_ORDER")]
        public string StatusOfOrder { get; set; }
        [Column("VALUE_OF_ORDER")]
        public decimal Value { get; set; }
        public List<PositionInTheOrder> OrderedItems { get; set; }
    }
}
