using System;
using System.Collections.Generic;
using ShopWebsite.Model.Entities.Discount;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Model.Entities.Generators
{
    public class OrderGenerator
    {
        private static int StatusId = 1;
        private static int StatusOrderId = 1;
        private static int ItemInOrderId = 1;
        private static int OrderId = 1;
        private readonly Status[] _statuses;
        private static OrderGenerator _instatnce { get; set; }

        public static int NumberOfStatuses => 4;

        private OrderGenerator()
        {
            _statuses = new Status[NumberOfStatuses];
            List<string> names = new List<string>() {"Zlozone", "Anulowane", "Wstrzymane", "Zrealizowane"};
            foreach (string name in names)
            {
                _statuses[StatusId - 1] = new Status(StatusId, name);
                StatusId++;
            }
        }

        public static OrderGenerator Instatnce => _instatnce ?? (_instatnce = new OrderGenerator());

        public Status[] GetAllStatuses()
        {
            return _statuses;
        }

        public List<StatusOrder> GetRandomListOfStatusesOrder()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int r = rand.Next()%4 + 1;
            List<StatusOrder> list = new List<StatusOrder>();
            for (int i = 0; i < r; i++)
            {
                list.Add(new StatusOrder(StatusOrderId, _statuses[i], DateTime.Now.AddDays(rand.Next(365))));
                StatusOrderId++;
            }
            return list;
        }

        public ItemInOrder GetNextItemInOrder()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int ProductId = rand.Next()%ProductGenerator.ProductId + 1;
            int Quantity = rand.Next()%100 + 1;
            ItemInOrder a = new ItemInOrder(ItemInOrderId, ProductId, Quantity);
            ItemInOrderId++;
            return a;
        }

        public Order.Order GetNextOrder()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int Id = OrderId;
            OrderId++;
            decimal Value = rand.Next(1000000)/100.0M;
            List<ItemInOrder> items = new List<ItemInOrder>();
            int r = rand.Next(4) + 1;
            for (int i = 0; i < r; i++)
            {
                items.Add(GetNextItemInOrder());
            }
            List<OrderDiscount> items2 = new List<OrderDiscount>();
            int r2 = rand.Next(4) + 1;
            for (int i = 0; i < r2; i++)
            {
                items2.Add(DiscountGenerator.Intance.GetNextOrderDiscount(Id));
            }
            return new Order.Order(Id, Value, items, items2, GetRandomListOfStatusesOrder());
        }
    }
}
