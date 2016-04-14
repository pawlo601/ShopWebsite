using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Customer
{
    public class UserHasRole
    { 
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
