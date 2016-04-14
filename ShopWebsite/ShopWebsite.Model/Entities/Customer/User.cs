using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Customer
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime LockoutEndsDateTimeUTC { get; set; }
        public Address ContactAddress { get; set; }
        public Address ResidentialAddress { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Password> Passwords { get; set; }
        public IList<UserHasRole> UserRoles { get; set; }  
    }
}
