using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Discount
{
    public abstract class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract decimal CountDiscount(decimal value);
    }
}
