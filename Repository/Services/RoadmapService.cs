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
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _roadmapRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly ICareerRepository _careerRepository;
        private readonly IMapper _mapper;

        public RoadmapService(IRoadmapRepository roadmapRepository, IMapper mapper, ISectionRepository sectionRepository, ICourseRepository courseRepository, ICourseModuleRepository courseModuleRepository, ICareerRepository careerRepository)
        {
            _roadmapRepository = roadmapRepository;
            _mapper = mapper;
            _sectionRepository = sectionRepository;
            _courseRepository = courseRepository;
            _courseModuleRepository = courseModuleRepository;
            _careerRepository = careerRepository;
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
                    RoadmapImage = entity.RoadmapImage,
                    RoadmapPrice = entity.RoadmapPrice,
                    CountCourse = (_roadmapRepository.CountCourseInRoadMap(entity.Id)).Result
                };
                result.Add(roadmapModel);
            }
            return Task.FromResult(result);
        }

        //public Task<RoadmapModel> GetRoadmapById(string id)
        //{
        //     var list = _roadmapRepository.GetById(id).Result;
        //    return Task.FromResult(_mapper.Map<RoadmapModel>(list));
        //}

        public async Task<RoadmapModel> GetRoadmapById(string id)
        {
            var entity = await _roadmapRepository.GetById(id);

            if (entity == null)
            {
                // Xử lý trường hợp không tìm thấy entity, ví dụ:
                // throw new Exception("Không tìm thấy lộ trình");
                return null;
            }

            var roadmapModel = new RoadmapModel
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
                RoadmapImage = entity.RoadmapImage,
                RoadmapPrice = entity.RoadmapPrice,
                CountCourse = await _roadmapRepository.CountCourseInRoadMap(entity.Id)
            };

            return roadmapModel;
        }

        public Task<RoadmapModel> UpdateRoadmap(RoadmapModel model)
        {
            var entity = _mapper.Map<Roadmap>(model);
            var result = _mapper.Map<RoadmapModel>(_roadmapRepository.Update(entity).Result);

            return Task.FromResult(result);
        }

        public async Task<List<RoadmapModel>> SearchRoadMapByName(string roadmapName)
        {
            var list = await _roadmapRepository.SearchRoadMapByName(roadmapName);
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
                    RoadmapImage = entity.RoadmapImage,
                    RoadmapPrice = entity.RoadmapPrice,
                    CountCourse = (_roadmapRepository.CountCourseInRoadMap(entity.Id)).Result
                };
                result.Add(roadmapModel);
            }
            return result;

        }

        public async Task<GetRoadmapDetailResDto> GetRoadmapDetailResByIdAsync(string id)
        {
            try
            {
                var roadmap = await _roadmapRepository.GetById(id);
                var listSection = await _sectionRepository.GetListSectionByRoadmapId(id);
                List<GetListCourseResDto> list = new();
                foreach ( var section in listSection)
                {
                    var course = await _courseRepository.GetById(section.CourseId);
                    var listCourseModule = await _courseModuleRepository.GetByCourseId(section.CourseId);
                    GetListCourseResDto getListCourseResDto = new()
                    {
                        Id = course.Id,
                        CourseName = course.CourseName,
                        CourseInformation = course.CourseInformation,
                        TypeOfLearning = course.TypeOfLearning,
                        DefaultImage = course.DefaultImage,
                        Level = course.Level,
                        CourseModules = listCourseModule.Count
                    };
                    list.Add(getListCourseResDto);
                }
                var career = await _careerRepository.GetById(roadmap.CareerId);
                GetRoadmapDetailResDto resDto = new()
                {
                    Id = roadmap.Id,
                    KeyId = roadmap.RoadmapKeyId,
                    CareerId = roadmap.CareerId,
                    CareerName = career.CareerName,
                    Language = roadmap.Language,
                    ListCourse = list,
                    RoadmapGoal = roadmap.RoadmapGoal,
                    RoadmapImage = roadmap.RoadmapImage,
                    RoadmapPrice = roadmap.RoadmapPrice,
                    RoadmapType = roadmap.RoadmapType,
                    Title = roadmap.Title,
                    Sections = roadmap.Sections,
                    CountCourse = listSection.Count
                };
                return resDto;
            } catch (Exception) 
            {
                throw;
            }
        }
    }
}
