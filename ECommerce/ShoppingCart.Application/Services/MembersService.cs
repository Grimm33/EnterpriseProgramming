using AutoMapper;
using ECommerce.Application.Interfaces;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class MembersService : IMembersService
    {
        private IMembersRepository _membersRepo;
        private IMapper _mapper;

        public MembersService(IMembersRepository membersRepo, IMapper mapper)
        {
            _membersRepo = membersRepo;
            _mapper = mapper;
        }

        public void AddMember(MemberViewModel m)
        {
            Member member = new Member();
            member.Email = m.Email;
            member.FirstName = m.FirstName;
            member.LastName = m.LastName;

            _membersRepo.AddMember(member);
        }

        public MemberViewModel GetMember(string memberEmail)
        {
            var member = _membersRepo.GetMember(memberEmail);

            var result = _mapper.Map<MemberViewModel>(member);

            return result;
        }
    }
}
