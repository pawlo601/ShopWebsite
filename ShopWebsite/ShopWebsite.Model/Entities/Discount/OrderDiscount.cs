using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Discount
{
    public class OrderDiscount
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public int OrderId { get; set; }
    }
}
