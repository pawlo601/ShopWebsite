using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    public class Company : Customer
    {
        [Column("NAME_OF_COMPANY")]
        public string CompanyName { get; set; }
        [Column("REGON")]
        public string REGON { get; set; }
        [Column("TAX_ID")]
        public string TaxID { get; set; }
    }
}
