using System.Linq;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Model.Entities.Generators
{
    public class DiscountGenerator
    {
        public static int NumberOfDiscountsForProducts => 4;

        public static int NumberOfDiscountsForOrders => 4;

        public static int NumberOfDiscountsForCustomers => 4;

        private static DiscountGenerator _instance { get; set; }
        private readonly Discount.Discount[] _discountForProducts;
        private readonly Discount.Discount[] _discountForOrders;
        private readonly Discount.Discount[] _discountForCustomers;

        private static int DiscountId = 1;
        private static int MainDiscountId = 1;

        public static DiscountGenerator Intance => _instance ?? (_instance = new DiscountGenerator());

        private DiscountGenerator()
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
