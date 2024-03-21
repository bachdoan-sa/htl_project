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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public Task<List<TransactionModel>> GetAll()
        {
            var list = _transactionRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<TransactionModel>>(list));
        }

        public Task<TransactionModel> GetById(string id)
        {
            var list = _transactionRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<TransactionModel>(list));
        }
        public Task<TransactionModel> Add(TransactionModel model)
        {
            var entity = _mapper.Map<Transaction>(model);
            var result = _mapper.Map<TransactionModel>(_transactionRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<TransactionModel> Update(TransactionModel model)
        {
            var entity = _mapper.Map<Transaction>(model);
            var result = _mapper.Map<TransactionModel>(_transactionRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
        public Task<string> Delete(string id)
        {
            return _transactionRepository.Delete(id);
        }

        public Task<string> AddByhand(SetTransactionDto model)
        {

            return _transactionRepository.AddbyHand(model);
        }
    }
}
