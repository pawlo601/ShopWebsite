﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Discount
{
    public class ProductDiscount : SomeDiscount
    {
        [Obsolete("This constructor is only for tests, please use constructor with all variables as parameters.")]
        public ProductDiscount()
        {
            Id = -1;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if(rand.Next(1000)%2==0)
                Discount = ConstantDiscount.GetOneConstantDiscountForProduct();
            else
                Discount = PercantageDiscount.GetOneConstantDiscountForProduct();
        }

        public ProductDiscount(int id, Discount discount)
        {
            Id = id;
            Discount = discount;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            results.AddRange(base.Validate(validationContext));
            if (Discount != null)
            {
                if (!Discount.IsForProduct)
                {
                    results.Add(new ValidationResult("This discount is not for product.", new[] { "Discount" }));
                }
            }
            return results;
        }
    }
}
