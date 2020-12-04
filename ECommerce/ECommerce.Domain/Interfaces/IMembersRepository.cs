using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Interfaces
{
    public interface IMembersRepository
    {
        void AddMember(Member m);
    }
}
