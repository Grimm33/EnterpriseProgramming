using ECommerce.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IMembersService
    {
        void AddMember(MemberViewModel m);

        public MemberViewModel GetMember(string memberEmail);
    }
}
