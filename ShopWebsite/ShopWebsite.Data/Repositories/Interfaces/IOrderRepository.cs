﻿using ShopWebsite.Data.Infrastructure.Interfaces;
using ShopWebsite.Model.Entities.Order;

namespace ShopWebsite.Data.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}