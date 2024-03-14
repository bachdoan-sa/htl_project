using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Model;
using Repository.Entities;

namespace Repository.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, Account>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Account, AccountModel>();
        }
    }
}
