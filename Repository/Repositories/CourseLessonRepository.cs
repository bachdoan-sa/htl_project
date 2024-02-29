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
    public class CourseLessonRepository : ICourseLessonRepository
    {
        private readonly AppDbContext _context;
        public CourseLessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<CourseLesson> Add(CourseLesson courseLesson)
        {
            _context.CourseLessons.Add(courseLesson);
            _context.SaveChanges();
            return Task.FromResult(courseLesson);
        }

        public Task<string> Delete(string id)
        {
            var entity = _context.CourseLessons.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public Task<List<CourseLesson>> GetAll()
        {
            return _context.CourseLessons.ToListAsync();
        }

        public Task<CourseLesson> GetById(string id)
        {
            var courseLesson = _context.CourseLessons.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (courseLesson.Result != null)
            {
                return courseLesson;

            }
            throw new Exception("NotFound!");
        }

        public Task<CourseLesson> Update(CourseLesson courseLesson)
        {
            _context.CourseLessons.Update(courseLesson);
            _context.SaveChanges();
            return Task.FromResult(courseLesson);
        }
    }
}
