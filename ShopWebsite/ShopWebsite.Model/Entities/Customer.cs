using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    [Table("CUSTOMERS")]
    public abstract class Customer
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Column("TITLE_CONACT")]
        public string ContactTitle { get; set; }
        [ForeignKey("ADDRESS_CONACT")]
        public Address ContactAddress { get; set; }
        [ForeignKey("RESIDENTIAL_ADDRESS")]
        public Address ResidentialAddress { get; set; }
        [Column("MAIL_1")]
        [EmailAddress(ErrorMessage ="Wrong email")]
        public string Mail1 { get; set; }
        [Column("PHONE_1")]
        [Phone(ErrorMessage = "Wrong phone number")]
        public string Phone1 { get; set; }
        [Column("MAIL_2")]
        [EmailAddress(ErrorMessage = "Wrong email")]
        public string Mail2 { get; set; }
        [Column("PHONE_2")]
        [Phone(ErrorMessage = "Wrong phone number")]
        public string Phone2 { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
