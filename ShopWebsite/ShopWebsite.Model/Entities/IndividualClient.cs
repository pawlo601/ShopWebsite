using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebsite.Model.Entities
{
    public class IndividualClient : Customer
    {
        [Column("NAME")]
        public string Name { get; set; }
        [Column("SURNAME")]
        public string Surname { get; set; }
        [Column("BIRTHDAY")]
        public DateTime Birthday { get; set; }
        [Column("PESEL_NUMBER")]
        public string PeselNumber { get; set; }
    }
}
