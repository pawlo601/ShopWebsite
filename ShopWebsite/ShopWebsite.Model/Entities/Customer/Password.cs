using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Customer
{
    public class Password
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
