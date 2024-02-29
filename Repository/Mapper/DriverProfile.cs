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
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<DriverModel, Driver>().ReverseMap();
        }
    }
}

