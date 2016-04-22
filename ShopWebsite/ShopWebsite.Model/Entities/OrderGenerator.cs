using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Model.Entities
{
    public class OrderGenerator
    {
        public static int NumberOfDiscountsForProducts => 4;

        public static int NumberOfDiscountsForOrders => 4;

        public static int NumberOfDiscountsForCustomers => 4;

        private static OrderGenerator _instance { get; set; }
        private readonly Discount.Discount[] _discountForProducts;
        private readonly Discount.Discount[] _discountForOrders;
        private readonly Discount.Discount[] _discountForCustomers;

        private static int DiscountId = 1;
        private static int MainDiscountId = 1;

        public static OrderGenerator Intance => _instance ?? (_instance = new OrderGenerator());

        private OrderGenerator()
        {
            
        }

        public Discount.Discount[] GetAllDiscounts()
        {
            return _discountForCustomers.Concat(_discountForOrders.Concat(_discountForProducts)).ToArray();
        }

        public OrderDiscount GetNextOrderDiscount()
        {
            return null;
        }

        public ProductDiscount GetNextProductDiscount()
        {
            return null;
        }

        public CustomerDiscount GetNextCustomerDiscount()
        {
            return null;
        }
    }
}
