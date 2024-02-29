using Microsoft.EntityFrameworkCore;
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
    public class DriverRepository : IDriverRepository
    {

        private readonly AppDbContext _context;
        public DriverRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Driver> Add(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return Task.FromResult(driver);
        }

        public Task<string> Delete(string id)
        {
            var entity = _context.Drivers.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public Task<List<Driver>> GetAll()
        {
            return _context.Drivers.ToListAsync();
        }

        public Task<Driver> GetById(string id)
        {
            var acc = _context.Drivers.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (acc.Result != null)
            {
                return acc;

            }
            throw new Exception("NotFound!");
        }

        public Task<Driver> Update(Driver driver)
        {
            _context.Drivers.Update(driver);
            _context.SaveChanges();
            return Task.FromResult(driver);
        }
    }
}
