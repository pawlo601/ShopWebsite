﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ShopWebsite.Model.Entities.Discount;

namespace ShopWebsite.Model.Entities.Order
{
    [Table("Orders", Schema = "Order")]
    public class Order : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("value_of_order")]
        [XmlAttribute("value_of_order")]//for xml
        [Required(ErrorMessage = "Value of order should be given.")]
        public decimal Value { get; set; }

        [XmlArray(ElementName = "items")]//for xml
        [XmlArrayItem("item", Type = typeof(ItemInOrder))]//for xml
        public List<ItemInOrder> Items { get; set; }

        [XmlArray(ElementName = "order_discounts")]//for xml
        [XmlArrayItem("discount", Type = typeof(OrderDiscount))]//for xml
        public List<OrderDiscount> OrderDiscounts { get; set; }

        [XmlArray(ElementName = "order_statuses")]//for xml
        [XmlArrayItem("status_order", Type = typeof(StatusOrder))]//for xml
        public List<StatusOrder> ListOfStatusOrder { get; set; }
        #endregion

        [Obsolete("This constructor is only for tests, please use constructor with all variables as parameters.")]
        public Order()
        {
            Id = -1;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int nitems = rand.Next(1,5);
            Items=new List<ItemInOrder>();
            for(int i=0;i<nitems;i++)
                Items.Add(new ItemInOrder());
            int norder = rand.Next(1,4);
            OrderDiscounts=new List<OrderDiscount>();
            for(int i=0;i<norder;i++)
                OrderDiscounts.Add(new OrderDiscount());
            int nstatus = rand.Next(1,5);
            ListOfStatusOrder=new List<StatusOrder>();
            for(int i=0;i<nstatus;i++)
                ListOfStatusOrder.Add(new StatusOrder());
            Value = rand.Next(1000000)/100.0M;
        }

        public Order(int id, decimal value, List<ItemInOrder> items, List<OrderDiscount> orderDiscounts, List<StatusOrder> listOfStatusOrder)
        {
            Id = id;
            Value = value;
            Items = items;
            OrderDiscounts = orderDiscounts;
            ListOfStatusOrder = listOfStatusOrder;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Value,
                new ValidationContext(this, null, null) { MemberName = "Value" },
                results);
            if (Value < 0.0M)
            {
                results.Add(new ValidationResult("Value of order shouldn't be less than 0.0.", new[] { "Value" }));
            }
            if (Items != null)
            {
                foreach (ItemInOrder item in Items)
                {
                    results.AddRange(item.Validate(validationContext));
                }
            }
            if (OrderDiscounts != null)
            {
                foreach (OrderDiscount discount in OrderDiscounts)
                {
                    results.AddRange(discount.Validate(validationContext));
                }
            }
            if (ListOfStatusOrder != null)
            {
                foreach (StatusOrder status in ListOfStatusOrder)
                {
                    results.AddRange(status.Validate(validationContext));
                }
            }
            return results;
        }
    }
}
