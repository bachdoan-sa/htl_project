using Microsoft.EntityFrameworkCore;
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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Transaction> GetById(string id)
        {
            var trans = _context.Transactions.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (trans.Result != null)
            {
                return trans;

            }
            throw new Exception("NotFound!");
        }
        public Task<List<Transaction>> GetAll()
        {
            return _context.Transactions.ToListAsync();
        }
        public Task<Transaction> Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return Task.FromResult(transaction);
        }
        public Task<Transaction> Update(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
            return Task.FromResult(transaction);
        }
        public Task<string> Delete(string id)
        {

            var entity = _context.Transactions.Where(_ => _.Id.Equals(id)).FirstOrDefault();
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
