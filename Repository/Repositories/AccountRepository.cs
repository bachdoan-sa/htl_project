using Microsoft.Identity.Client;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Account> GetById(string id)
        {
            throw new NotImplementedException();
        }
        public Task<List<Account>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Account> Add(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return Task.FromResult(account);
        }
        public Task<Account> Update(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return Task.FromResult(account);
        }
        public Task<string> Delete(string id)
        {

            var entity = _context.Accounts.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }
        
    }
}
