using ECommerce.Data.Context;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        ECommerceDbContext _context;

        public MembersRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void AddMember(Member m)
        {
            _context.Members.Add(m);
            _context.SaveChanges();
        }
    }
}
