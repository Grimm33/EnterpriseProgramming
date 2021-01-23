using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.ViewModels
{
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public string Member { get; set; }

        public Guid Product { get; set; }

        public int Quantity { get; set; }
    }
}
