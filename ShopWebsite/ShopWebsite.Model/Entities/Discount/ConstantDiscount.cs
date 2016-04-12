using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Discount
{
    public class ConstantDiscount:Discount
    {
        public decimal Value { get; set; }
        public override decimal CountDiscount(decimal value)
        {
            if (value < Value)
                return 0;
            return value-Value;
        }
    }
}
