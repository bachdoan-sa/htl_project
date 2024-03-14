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
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<SectionModel, Section>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Section, SectionModel>();
        }
    }
}
