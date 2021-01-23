using ECommerce.Data.Context;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data.Repositories
{
    public class CartsRepository : ICartsRepository
    {
        ECommerceDbContext _context;

        public CartsRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public Guid AddToCart(Cart c)
        {
            _context.Cart.Add(c);

            return c.Id;
        }

        public IQueryable<Cart> GetCart(string memberEmail)
        {
            return _context.Cart.Where(x => x.MemberEmail == memberEmail);
        }

        public void RemoveFromCart(Cart c)
        {
            _context.Cart.Remove(c);
            _context.SaveChanges();
        }
    }
}
