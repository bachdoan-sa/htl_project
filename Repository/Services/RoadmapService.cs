using AutoMapper;
using Repository.Entities;
using Repository.Model;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _roadmapRepository;
        private readonly IMapper _mapper;
        
        public RoadmapService(IRoadmapRepository roadmapRepository, IMapper mapper)
        {
            _roadmapRepository = roadmapRepository;
            _mapper = mapper;
        }

        public Task<RoadmapModel> AddRoadmap(RoadmapModel model)
        {
            var entity = _mapper.Map<Roadmap>(model);
            var result = _mapper.Map<RoadmapModel>(_roadmapRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<int> CountCourseInRoadMap(string id)
        {
            return Task.FromResult(_roadmapRepository.CountCourseInRoadMap(id)).Result;
        }

        public Task DeleteRoadmap(string id)
        {
            return _roadmapRepository.Delete(id);
        }

        public Task<List<RoadmapModel>> GetAllRoadmaps()
        {
            var list = _roadmapRepository.GetAll().Result;
            var result = new List<RoadmapModel>();
            foreach (var entity in list)
            {
                RoadmapModel roadmapModel = new()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    CareerId = entity.CareerId,
                    CareerName = entity.Career.CareerName,
                    CreatedTime = entity.CreatedTime,
                    DeleteTime = entity.DeleteDate ?? new DateTimeOffset(),
                    Language = entity.Language,
                    LastUpdated = entity.LastUpdated,
                    RoadmapGoal = entity.RoadmapGoal,
                    RoadmapType = entity.RoadmapType,
                    CountCourse = (_roadmapRepository.CountCourseInRoadMap(entity.Id)).Result
                };
                result.Add(roadmapModel);
            }
            return Task.FromResult(result);
        }

        public Task<RoadmapModel> GetRoadmapById(string id)
        {
             var list = _roadmapRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<RoadmapModel>(list));
        }

        public Task<RoadmapModel> UpdateRoadmap(RoadmapModel model)
        {
            var entity = _mapper.Map<Roadmap>(model);
            var result = _mapper.Map<RoadmapModel>(_roadmapRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
    }
}
