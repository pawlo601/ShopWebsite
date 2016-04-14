using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Customer
{
    public class Employee : User
    {
        public string Position { get; set; }
        public PersonalInformation Information { get; set; }
    }
}
