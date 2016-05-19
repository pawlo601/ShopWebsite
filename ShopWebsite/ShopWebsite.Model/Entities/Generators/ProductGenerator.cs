using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Product;

namespace ShopWebsite.Model.Entities.Generators
{
    public class ProductGenerator
    {
        public static int ProductId = 1;
        private static int UnitId = 1;
        private static int CurrencyId = 1;
        private static int CostId = 1;
        private static int QuantityId = 1;
        private static int PriceId = 1;
        private readonly Unit[] _units;
        private readonly Currency[] _currencies;

        private static ProductGenerator _instance { get; set; }

        public static int NumberOfUnits => 5;

        public static int NumberOfCurrencies => 5;

        public static ProductGenerator Instatnce => _instance ?? (_instance = new ProductGenerator());

        public Unit[] GetAllUnits()
        {
            return _units;
        }

        public Currency[] GetAllCurrencies()
        {
            return _currencies;
        }

        private ProductGenerator()
        {
            _units = new Unit[NumberOfUnits];
            Dictionary<string, string> dic1 = new Dictionary<string, string>
            {
                {"Kilogram", "KG"},
                {"Sztuka", "SZT"},
                {"Metr", "M"},
                {"Para", "Para"},
                {"Litr", "L"}
            };
            foreach (KeyValuePair<string, string> keyValuePair in dic1)
            {
                _units[UnitId - 1] = new Unit(UnitId, keyValuePair.Key, keyValuePair.Value);
                UnitId++;
            }
            _currencies = new Currency[NumberOfCurrencies];
            Tuple<string, string, decimal> a = Tuple.Create("Zloty", "PLN", 3.82M);
            Tuple<string, string, decimal> b = Tuple.Create("Dolar", "USD", 1.0M);
            Tuple<string, string, decimal> c = Tuple.Create("Euro", "EUR", 0.88M);
            Tuple<string, string, decimal> d = Tuple.Create("Funt", "GBD", 0.69M);
            Tuple<string, string, decimal> e = Tuple.Create("Rubel", "RUB", 66.83M);
            ArrayList list = new ArrayList {a, b, c, d, e};
            foreach (Tuple<string, string, decimal> v in list)
            {
                _currencies[CurrencyId - 1] = new Currency(CurrencyId, v.Item1, v.Item2, v.Item3);
                CurrencyId++;
            }
        }

        public Product.Product GetNextProduct()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = ProductId;
            string Name = "Product name " + rand.Next(10000);
            string Description = "Description of product " + rand.Next(10000);
            Cost Cost = GetNextCost();
            decimal Discount = rand.Next(100)/100.0M;
            Quantity Quantity = GetNextQuantity();
            int p = rand.Next(1, 5);
            var ProductDiscounts = new List<ProductDiscount>();
            for (int i = 0; i < p; i++)
                ProductDiscounts.Add(GetNextProductDiscount(Id));
            ProductId++;
            return new Product.Product(Id, Name, Description, Cost, Discount, Quantity, ProductDiscounts);
        }

        public Cost GetNextCost()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = CostId;
            CostId++;
            decimal Tax = rand.Next(99)/100.0M;
            int howManyPrices = rand.Next(1, 5);
            List<Price> Prices = new List<Price>();
            List<Currency> notThisCurrencies = new List<Currency>();
            for (int i = 0; i < howManyPrices; i++)
            {
                Price element = GetNextPrice(notThisCurrencies);
                notThisCurrencies.Add(element.Currency);
                Prices.Add(element);
            }
            return new Cost(Id, Tax, Prices);
        }

        public Price GetNextPrice(List<Currency> notThisCurrencies)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = PriceId;
            PriceId++;
            decimal Value = rand.Next(1000000)/100.0M;
            Currency Currency = _currencies.FirstOrDefault(currency => !notThisCurrencies.Contains(currency)) ??
                                _currencies[0];
            return new Price(Id, Value, Currency);
        }

        public Quantity GetNextQuantity()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = QuantityId;
            QuantityId++;
            decimal Value = rand.Next(10000);
            Unit Unit = _units[rand.Next()%_units.Length];
            return new Quantity(Id, Value, Unit);
        }

        public ProductDiscount GetNextProductDiscount(int productId)
        {
            return DiscountGenerator.Intance.GetNextProductDiscount(productId);
        }
    }
}
