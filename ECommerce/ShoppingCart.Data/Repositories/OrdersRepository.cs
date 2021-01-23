using ECommerce.Data.Context;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        ECommerceDbContext _context;

        public OrdersRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public Guid AddOder(Order o)
        {
            _context.Orders.Add(o);
            _context.SaveChanges();
            return o.Id;
        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders;
        }
    }
}
