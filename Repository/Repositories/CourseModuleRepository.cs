using Microsoft.EntityFrameworkCore;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Model;
using Repository.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CourseModuleRepository : ICourseModuleRepository
    {
        private readonly AppDbContext _context;
        public CourseModuleRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<CourseModule> Add(CourseModule courseModule)
        {
            _context.CourseModules.Add(courseModule);
            _context.SaveChanges();
            return Task.FromResult(courseModule);
        }

        public Task<string> Delete(string id)
        {

            var entity = _context.CourseModules.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public Task<List<CourseModule>> GetAll()
        {
            return _context.CourseModules.ToListAsync();
        }

        public Task<CourseModule> GetById(string id)
        {
            var acc = _context.CourseModules.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (acc.Result != null)
            {
                return acc;

            }
            throw new Exception("NotFound!");
        }

        public Task<CourseModule> Update(CourseModule courseModule)
        {
            _context.CourseModules.Update(courseModule);
            _context.SaveChanges();
            return Task.FromResult(courseModule);
        }
    }
}
