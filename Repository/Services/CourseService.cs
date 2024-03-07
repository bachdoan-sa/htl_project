using AutoMapper;
using Repository.Entities;
using Repository.Model;
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
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository,IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public Task<CourseModel> Add(CourseModel model)
        {
            var entity = _mapper.Map<Course>(model);
            var result = _mapper.Map<CourseModel>(_courseRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<string> Delete(string id)
        {
            return _courseRepository.Delete(id);
        }

        public Task<List<CourseModel>> GetAll()
        {
            var list = _courseRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<CourseModel>>(list));
        }

        public Task<CourseModel> GetById(string id)
        {
            var list = _courseRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<CourseModel>(list));
        }

        public Task<List<CourseModel>> SearchCourseByName(string courseName)
        {
            return Task.FromResult(_mapper.Map<List<CourseModel>>(_courseRepository.SearchCourseByName(courseName)));
        }

        public Task<CourseModel> Update(CourseModel model)
        {
            var entity = _mapper.Map<Course>(model);
            var result = _mapper.Map<CourseModel>(_courseRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
    }
}
