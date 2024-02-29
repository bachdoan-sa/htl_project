using AutoMapper;
using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mapper
{
    public class CourseModuleProfile : Profile
    {
        public CourseModuleProfile()
        {
            CreateMap<CourseModuleModel, CourseModule>().ReverseMap();
        }
    }
}