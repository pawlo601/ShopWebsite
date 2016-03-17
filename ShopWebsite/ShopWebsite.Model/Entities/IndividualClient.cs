using System;

namespace ShopWebsite.Model.Entities
{
    public class IndividualClient : Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string PeselNumber { get; set; }
    }
}
