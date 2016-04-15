using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    public class PercantageDiscount: Discount
    {
        [Column("percent_of_percantage_discount")]
        [XmlAttribute("percent_of_percantage_discount")]//for xml
        [Required(ErrorMessage = "Percent has to be given.")]
        public decimal Percent { get; set; }

        private static PercantageDiscount[] _tablePercantageDiscounts { get; set; }

        private PercantageDiscount() { }

        private static void GenerateTable()
        {
            _tablePercantageDiscounts = new PercantageDiscount[4];
            _tablePercantageDiscounts[0] = new PercantageDiscount()
            {
                Id = -1,
                Name = "PercentD1",
                Percent = 0.45M,
                IsForProduct = true,
                StartDiscount = DateTime.Now,
                EndDisscount = DateTime.Now.AddDays(14)
            };
            _tablePercantageDiscounts[1] = new PercantageDiscount()
            {
                Id = -1,
                Name = "PercentD2",
                Percent = 0.34M,
                IsForProduct = false,
                StartDiscount = DateTime.Now,
                EndDisscount = DateTime.Now.AddDays(2)
            };
            _tablePercantageDiscounts[2] = new PercantageDiscount()
            {
                Id = -1,
                Name = "PercentD3",
                Percent = 0.09M,
                IsForProduct = true,
                StartDiscount = DateTime.Now,
                EndDisscount = DateTime.Now.AddDays(7)
            };
            _tablePercantageDiscounts[3] = new PercantageDiscount()
            {
                Id = -1,
                Name = "PercentD4",
                Percent = 0.99M,
                IsForProduct = false,
                StartDiscount = DateTime.Now,
                EndDisscount = DateTime.Now.AddDays(31)
            };
        }

        public static PercantageDiscount GetOneConstantDiscount()
        {
            Random rand = new Random();
            if (_tablePercantageDiscounts != null)
                return _tablePercantageDiscounts[rand.Next() % _tablePercantageDiscounts.Length];
            GenerateTable();
            return _tablePercantageDiscounts[rand.Next() % _tablePercantageDiscounts.Length];
        }

        public static PercantageDiscount GetOneConstantDiscountForProduct()
        {
            Random rand = new Random();
            if (_tablePercantageDiscounts == null)
                GenerateTable();
            while (true)
            {
                var a = _tablePercantageDiscounts[rand.Next() % _tablePercantageDiscounts.Length];
                if (a.IsForProduct)
                    return a;
            }
        }

        public static PercantageDiscount GetOneConstantDiscountForOrder()
        {
            Random rand = new Random();
            if (_tablePercantageDiscounts == null)
                GenerateTable();
            while (true)
            {
                var a = _tablePercantageDiscounts[rand.Next() % _tablePercantageDiscounts.Length];
                if (!a.IsForProduct)
                    return a;
            }
        }

        public static PercantageDiscount GetOneConstantDiscount(int id)
        {
            if (_tablePercantageDiscounts == null)
                return GetOneConstantDiscount();
            foreach (PercantageDiscount discount in _tablePercantageDiscounts.Where(discount => discount.Id == id))
                return discount;
            return GetOneConstantDiscount();
        }

        public static void SetTablePercantageDiscounts(PercantageDiscount[] table)
        {
            _tablePercantageDiscounts = table;
        }

        public override decimal CountDiscount(decimal value)
        {
            return value*(1-Percent);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(Percent,
                new ValidationContext(this, null, null) { MemberName = "Percent" },
                results);
            if (Percent < 0)
            {
                results.Add(new ValidationResult("Percent should be greater than or equal to 0.", new[] { "Percent" }));
            }
            if (Percent > 1)
            {
                results.Add(new ValidationResult("Percent should be less than or equal to 1.", new[] { "Percent" }));
            }
            return results;
        }
    }
}
