using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Discount
{
    public class PercantageDiscount:Discount
    {
        public decimal Percent { get; set; }
        public override decimal CountDiscount(decimal value)
        {
            return value*(1-Percent);
        }
    }
}
