using System;
using System.Linq;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Model.Entities.Generators
{
    public class DiscountGenerator
    {
        public static int NumberOfDiscountsForProducts => 5;

        public static int NumberOfDiscountsForOrders => 5;

        public static int NumberOfDiscountsForCustomers => 5;

        private static DiscountGenerator _instance { get; set; }
        private readonly Discount.Discount[] _discountForProducts;
        private readonly Discount.Discount[] _discountForOrders;
        private readonly Discount.Discount[] _discountForCustomers;

        private static int DiscountId = 1;
        private static int MainDiscountId = 1;

        public static DiscountGenerator Intance => _instance ?? (_instance = new DiscountGenerator());

        private DiscountGenerator()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            _discountForProducts = new Discount.Discount[NumberOfDiscountsForProducts];
            for (int i = 0; i < NumberOfDiscountsForProducts; i++)
            {
                _discountForProducts[i] = new Discount.Discount(
                    DiscountId,
                    "Discount" + rand.Next(10000),
                    true,
                    false,
                    false,
                    rand.Next(10000)%2 == 0,
                    rand.Next(100000)/100.0,
                    DateTime.Now.AddDays(-rand.Next(365)),
                    DateTime.Now.AddDays(rand.Next(365))
                    );
                DiscountId++;
            }
            _discountForCustomers = new Discount.Discount[NumberOfDiscountsForCustomers];
            for (int i = 0; i < NumberOfDiscountsForCustomers; i++)
            {
                _discountForCustomers[i] = new Discount.Discount(
                    DiscountId,
                    "Discount" + rand.Next(10000),
                    false,
                    true,
                    false,
                    rand.Next()%2 == 0,
                    rand.Next(100000)/100.0,
                    DateTime.Now.AddDays(-rand.Next(365)),
                    DateTime.Now.AddDays(rand.Next(365))
                    );
                DiscountId++;
            }
            _discountForOrders = new Discount.Discount[NumberOfDiscountsForOrders];
            for (int i = 0; i < NumberOfDiscountsForOrders; i++)
            {
                _discountForOrders[i] = new Discount.Discount(
                    DiscountId,
                    "Discount" + rand.Next(10000),
                    false,
                    false,
                    true,
                    rand.Next()%2 == 0,
                    rand.Next(100000)/100.0,
                    DateTime.Now.AddDays(-rand.Next(365)),
                    DateTime.Now.AddDays(rand.Next(365))
                    );
                DiscountId++;
            }
        }

        public Discount.Discount[] GetAllDiscounts()
        {
            return _discountForProducts.Concat(_discountForCustomers.Concat(_discountForOrders)).ToArray();
        }

        public OrderDiscount GetNextOrderDiscount(int orderId)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = MainDiscountId;
            MainDiscountId++;
            return new OrderDiscount(Id, orderId, _discountForOrders[rand.Next()%NumberOfDiscountsForOrders]);
        }

        public ProductDiscount GetNextProductDiscount(int productId)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = MainDiscountId;
            MainDiscountId++;
            return new ProductDiscount(Id, productId, _discountForProducts[rand.Next()%NumberOfDiscountsForProducts]);
        }

        public CustomerDiscount GetNextCustomerDiscount(int customerId)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = MainDiscountId;
            MainDiscountId++;
            return new CustomerDiscount(Id, customerId, _discountForCustomers[rand.Next()%NumberOfDiscountsForCustomers]);
        }
    }
}
