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
    public class CheckpointService : ICheckpointService
    {
        private readonly ICheckpointRepository _checkpointRepository;
        private readonly IMapper _mapper;
        public CheckpointService(ICheckpointRepository checkpointRepository, IMapper mapper)
        {
            _checkpointRepository = checkpointRepository;
            _mapper = mapper;
        }

        public Task<CheckpointModel> Add(CheckpointModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(string id)
        {
            return _checkpointRepository.Delete(id);
        }

        public Task<List<CheckpointModel>> GetAll()
        {
            var list = _checkpointRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<CheckpointModel>>(list));
        }

        public Task<CheckpointModel> GetById(string id)
        {
            var list = _checkpointRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<CheckpointModel>(list));
        }

        public Task<CheckpointModel> Update(CheckpointModel model)
        {
            var entity = _mapper.Map<Checkpoint>(model);
            var result = _mapper.Map<CheckpointModel>(_checkpointRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
    }
}
