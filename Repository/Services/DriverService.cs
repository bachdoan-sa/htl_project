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
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public Task<DriverModel> Add(DriverModel model)
        {
            var entity = _mapper.Map<Driver>(model);
            var result = _mapper.Map<DriverModel>(_driverRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<string> Delete(string id)
        {
            return _driverRepository.Delete(id);
        }

        public Task<List<DriverModel>> GetAll()
        {
            var list = _driverRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<DriverModel>>(list));
        }

        public Task<DriverModel> GetById(string id)
        {
            var list = _driverRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<DriverModel>(list));
        }

        public Task<DriverModel> Update(DriverModel model)
        {
            var entity = _mapper.Map<Driver>(model);
            var result = _mapper.Map<DriverModel>(_driverRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
    }
}
