using ECommerce.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface ICartsService
    {
        IQueryable<CartViewModel> GetCart(string memberEmail);

        void AddToCart(CartViewModel cart);

        void DeleteFromCart(Guid Id);
    }
}
