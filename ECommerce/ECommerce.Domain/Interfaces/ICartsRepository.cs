using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.Interfaces
{
    public interface ICartsRepository
    {
        IQueryable<Cart> GetCart(string memberEmail);

        Guid AddToCart(Cart c);

        void RemoveFromCart(Cart c);
    }
}
