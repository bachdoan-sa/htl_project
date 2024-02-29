using Microsoft.EntityFrameworkCore;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CareerRepository : ICourseService
    {
        private readonly AppDbContext _context;
        public CareerRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Course> Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return Task.FromResult(course);
        }

        public Task<string> Delete(string id)
        {
            var entity = _context.Courses.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public Task<List<Course>> GetAll()
        {
            return _context.Courses.ToListAsync();
        }

        public Task<Course> GetById(string id)
        {
            var course = _context.Courses.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (course.Result != null)
            {
                return course;

            }
            throw new Exception("NotFound!");
        }

        public Task<Course> Update(Course model)
        {
            _context.Courses.Update(model);
            _context.SaveChanges();
            return Task.FromResult(model);
        }
    }
}
