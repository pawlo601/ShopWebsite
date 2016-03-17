using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    public abstract class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string ContactTitle { get; set; }
        public Address ContactAddress { get; set; }
        public Address ResresidentialAddress { get; set; }
        public string Mail1 { get; set; }
        public string Phone1 { get; set; }
        public string Mail2 { get; set; }
        public string Phone2 { get; set; }
    }
}
