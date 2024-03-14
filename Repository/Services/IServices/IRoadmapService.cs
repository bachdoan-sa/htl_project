﻿using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface IRoadmapService
    {
        Task<RoadmapModel> GetRoadmapById(string id);
        Task<List<RoadmapModel>> GetAllRoadmaps();
        Task<RoadmapModel> AddRoadmap(RoadmapModel model);
        Task<RoadmapModel> UpdateRoadmap(RoadmapModel model);
        Task DeleteRoadmap(string id);
        Task<int> CountCourseInRoadMap(string id);
        Task<List<RoadmapModel>> SearchRoadMapByName(string roadmapName);
        Task<GetRoadmapDetailResDto> GetRoadmapDetailResByIdAsync(string id);
    }
}
