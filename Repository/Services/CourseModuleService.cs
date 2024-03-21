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

    public class CourseModuleService : ICourseModuleService
    {
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly IMapper _mapper;
        public CourseModuleService(ICourseModuleRepository courseModuleRepository, IMapper mapper)
        {
            _courseModuleRepository = courseModuleRepository;
            _mapper = mapper;
        }
        public Task<CourseModuleModel> Add(CourseModuleModel model)
        {
            var entity = _mapper.Map<CourseModule>(model);
            var result = _mapper.Map<CourseModuleModel>(_courseModuleRepository.Add(entity).Result);

            return Task.FromResult(result);
        }


        public Task<string> Delete(string id)
        {
            return _courseModuleRepository.Delete(id);
        }

        public Task<List<CourseModuleModel>> GetAll()
        {
            var list = _courseModuleRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<CourseModuleModel>>(list));
        }

        public Task<List<CourseModuleModel>> GetByCourseId(string id)
        {
            var list = _courseModuleRepository.GetByCourseId(id).Result;
            return Task.FromResult(_mapper.Map<List<CourseModuleModel>>(list));
        }

        public Task<CourseModuleModel> GetById(string id)
        {
            var list = _courseModuleRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<CourseModuleModel>(list));
        }

        public Task<CourseModuleModel> Update(CourseModuleModel model)
        {
            var entity = _mapper.Map<CourseModule>(model);
            var result = _mapper.Map<CourseModuleModel>(_courseModuleRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
    }
}
