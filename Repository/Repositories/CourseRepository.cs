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
    public class CourseRepository : ICourseRepository
    { 
           private readonly AppDbContext _context;
    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task<Course> GetById(string id)
    {
            var entity = _context.Courses.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            return Task.FromResult(entity);
        }
    public Task<List<Course>> GetAll()
    {
            return _context.Courses.ToListAsync();
        }
    public Task<Course> Add(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
        return Task.FromResult(course);
    }
    public Task<Course> Update(Course course)
    {
        _context.Courses.Update(course);
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

}
}