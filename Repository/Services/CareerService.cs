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
    public class CareerService : ICareerService
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IMapper _mapper;
        public CareerService(ICareerRepository careerRepository, IMapper mapper)
        {
            _careerRepository = careerRepository;
            _mapper = mapper;
        }
        public Task<CareerModel> Add(CareerModel model)
        {
            var entity = _mapper.Map<Career>(model);
            var result = _mapper.Map<CareerModel>(_careerRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<string> Delete(string id)
        {
            return _careerRepository.Delete(id);
        }

        public Task<List<CareerModel>> GetAll()
        {
            var list = _careerRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<CareerModel>>(list));
        }

        public Task<CareerModel> GetById(string id)
        {
            var list = _careerRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<CareerModel>(list));
        }

        public Task<CareerModel> Update(CareerModel model)
        {
            var entity = _mapper.Map<Career>(model);
            var result = _mapper.Map<CareerModel>(_careerRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
    }
}
