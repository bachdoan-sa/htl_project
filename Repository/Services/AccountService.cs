using AutoMapper;
using Repository.Entities;
using Repository.Model;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public Task<List<AccountModel>> GetAll()
        {  
            var list = _accountRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<AccountModel>>(list));
        }

        public Task<AccountModel> GetById(string id)
        {
            var list = _accountRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<AccountModel>(list));
        }
        public Task<AccountModel> Add(AccountModel model)
        {
            var entity = _mapper.Map<Account>(model);
            var result = _mapper.Map <AccountModel>(_accountRepository.Add(entity).Result);

            return Task.FromResult(result);
        }
 
        public Task<AccountModel> Update(AccountModel model)
        {
            var entity = _mapper.Map<Account>(model);
            var result = _mapper.Map<AccountModel>(_accountRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
        public Task<string> Delete(string id)
        {
            return _accountRepository.Delete(id);
        }
    }
}
