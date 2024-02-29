using Microsoft.EntityFrameworkCore;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CareerRepository : ICareerRepository
    {
        private readonly AppDbContext _context;
        public CareerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Career> Add(Career Career)
        {
            _context.Careers.Add(Career);
            _context.SaveChanges();
            return Task.FromResult(Career);
        }

        public Task<string> Delete(string id)
        {
            var entity = _context.Careers.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }


        public Task<List<Career>> GetAll()
        {
            return _context.Careers.ToListAsync();
        }

        public Task<Career> GetById(string id)
        {
            var entity = _context.Careers.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            return Task.FromResult(entity);
        }

        public Task<Career> Update(Career Career)
        {
            _context.Careers.Update(Career);
            _context.SaveChanges();
            return Task.FromResult(Career);
        }
    }
}
