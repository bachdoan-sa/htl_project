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
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;
        public SectionService(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }
        public Task<List<SectionModel>> GetAll()
        {
            var list = _sectionRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<SectionModel>>(list));
        }

        public Task<SectionModel> GetById(string id)
        {
            var list = _sectionRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<SectionModel>(list));
        }
        public Task<SectionModel> Add(SectionModel model)
        {
            var entity = _mapper.Map<Section>(model);
            var result = _mapper.Map<SectionModel>(_sectionRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<SectionModel> Update(SectionModel model)
        {
            var entity = _mapper.Map<Section>(model);
            var result = _mapper.Map<SectionModel>(_sectionRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
        public Task<string> Delete(string id)
        {
            return _sectionRepository.Delete(id);
        }
    }
}
