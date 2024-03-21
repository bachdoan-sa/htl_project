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
    public class CourseLessonService : ICourseLessonService
    {
        private readonly ICourseLessonRepository _courseLessonRepository;
        private readonly IMapper _mapper;
        public CourseLessonService(ICourseLessonRepository courseLessonRepository, IMapper mapper)
        {
            _courseLessonRepository = courseLessonRepository;
            _mapper = mapper;
        }
        public Task<CourseLessonModel> Add(CourseLessonModel model)
        {
            var entity = _mapper.Map<CourseLesson>(model);
            var result = _mapper.Map<CourseLessonModel>(_courseLessonRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<string> Delete(string id)
        {
            return _courseLessonRepository.Delete(id);
        }

        public Task<List<CourseLessonModel>> GetAll()
        {
            var list = _courseLessonRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<CourseLessonModel>>(list));
        }

        public Task<CourseLessonModel> GetById(string id)
        {
            var list = _courseLessonRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<CourseLessonModel>(list));
        }

        public Task<CourseLessonModel> Update(CourseLessonModel model)
        {
            var entity = _mapper.Map<CourseLesson>(model);
            var result = _mapper.Map<CourseLessonModel>(_courseLessonRepository.Update(entity).Result);

            return Task.FromResult(result);
        }

        public Task<CourseLessonModel> GetCourseLessonByCourseModuleId(string id)
        {
            var list = _courseLessonRepository.GetCourseLessonByCourseModuleId(id).Result;
            return Task.FromResult(_mapper.Map<CourseLessonModel>(list));
        }
    }
}
