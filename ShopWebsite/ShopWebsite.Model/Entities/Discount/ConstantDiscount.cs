using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    public class ConstantDiscount: Discount
    {
        [Column("value_of_constant_discount")]
        [XmlAttribute("value_of_constant_discount")]//for xml
        [Required(ErrorMessage = "Value has to be given.")]
        public decimal Value { get; set; }

        private static ConstantDiscount[] _tableConstantDiscounts { get; set; }

        private ConstantDiscount() { }

        private static void GenerateTable()
        {
            _tableConstantDiscounts = new ConstantDiscount[4];
            _tableConstantDiscounts[0] = new ConstantDiscount()
            {
                Id = -1,
                Name = "ConstD1",
                Value = 10.45M,
                IsForProduct = true, 
                StartDiscount = DateTime.Now,
                EndDisscount = DateTime.Now.AddDays(10)
            };
            _tableConstantDiscounts[1] = new ConstantDiscount()
            {
                Id = -1,
                Name = "ConstD2",
                Value = 0.34M,
                IsForProduct = true,
                StartDiscount = DateTime.Now,
                EndDisscount = DateTime.Now.AddDays(2)
            };
            _tableConstantDiscounts[2] = new ConstantDiscount()
            {
                Id = -1,
                Name = "ConstD3",
                Value = 45.09M,
                IsForProduct = false,
                StartDiscount = DateTime.Now,
                EndDisscount = DateTime.Now.AddDays(5)
            };
            _tableConstantDiscounts[3] = new ConstantDiscount()
            {
                Id = -1,
                Name = "ConstD4",
                Value = 0.99M,
                IsForProduct = false,
                StartDiscount = DateTime.Now,
                EndDisscount = DateTime.Now.AddDays(14)
            };
        }

        public static ConstantDiscount GetOneConstantDiscount()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (_tableConstantDiscounts != null)
            {
                int r = rand.Next() % _tableConstantDiscounts.Length;
                return _tableConstantDiscounts[r];
            }
            GenerateTable();
            return _tableConstantDiscounts[rand.Next() % _tableConstantDiscounts.Length];
        }

        public static ConstantDiscount GetOneConstantDiscountForProduct()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (_tableConstantDiscounts == null)
                GenerateTable();
            while (true)
            {
                var a = _tableConstantDiscounts[rand.Next()%_tableConstantDiscounts.Length];
                if (a.IsForProduct)
                    return a;
            }
        }

        public static ConstantDiscount GetOneConstantDiscountForOrder()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (_tableConstantDiscounts == null)
                GenerateTable();
            while (true)
            {
                var a = _tableConstantDiscounts[rand.Next() % _tableConstantDiscounts.Length];
                if (!a.IsForProduct)
                    return a;
            }
        }

        public static ConstantDiscount GetOneConstantDiscount(int id)
        {
            if (_tableConstantDiscounts == null)
                return GetOneConstantDiscount();
            foreach (ConstantDiscount discount in _tableConstantDiscounts.Where(discount => discount.Id == id))
                return discount;
            return GetOneConstantDiscount();
        }

        public static void SetTableConstantDiscounts(ConstantDiscount[] table)
        {
            _tableConstantDiscounts = table;
        }

        public override decimal CountDiscount(decimal value)
        {
            if (value < Value)
                return 0;
            return value-Value;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            Validator.TryValidateProperty(Value,
                new ValidationContext(this, null, null) { MemberName = "Value" },
                results);
            if (Value < 0)
            {
                results.Add(new ValidationResult("Value should be greater than or equal to 0.", new[] { "Value" }));
            }
            return results;
        }
    }
}
