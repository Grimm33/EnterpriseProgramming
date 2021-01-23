using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.Interfaces
{
    public interface IOrdersRepository
    {
        Guid AddOder(Order o);

        IQueryable<Order> GetOrders();


    }
}
