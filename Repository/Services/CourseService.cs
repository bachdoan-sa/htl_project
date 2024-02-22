using Repository.Entities;
using Repository.Repositories;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<Course> Add(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public Task<Course> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> Update(Course model)
        {
            throw new NotImplementedException();
        }
    }
}
