using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public string Status { get; set; }
        public Customer Client { get; set; }
        public List<PositionInTheOrder> OrderedItems { get; set; }
    }
}
