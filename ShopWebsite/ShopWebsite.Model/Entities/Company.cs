namespace ShopWebsite.Model.Entities
{
    public class Company : Customer
    {
        public string CompanyName { get; set; }
        public string REGON { get; set; }
        public string TaxID { get; set; }
    }
}
