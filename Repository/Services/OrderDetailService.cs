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
    public class OrderDetailService: IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public Task<List<OrderDetailModel>> GetAll()
        {
            var list = _orderDetailRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<OrderDetailModel>>(list));
        }

        public Task<OrderDetailModel> GetById(string id)
        {
            var list = _orderDetailRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<OrderDetailModel>(list));
        }
        public Task<OrderDetailModel> Add(OrderDetailModel model)
        {
            var entity = _mapper.Map<OrderDetail>(model);
            var result = _mapper.Map<OrderDetailModel>(_orderDetailRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<OrderDetailModel> Update(OrderDetailModel model)
        {
            var entity = _mapper.Map<OrderDetail>(model);
            var result = _mapper.Map<OrderDetailModel>(_orderDetailRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
        public Task<string> Delete(string id)
        {
            return _orderDetailRepository.Delete(id);
        }
        public async Task<List<OrderDetailModel>> GetOrderDetailsByIds(string[] itemIds)
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetailsByIds(itemIds);
            return _mapper.Map<List<OrderDetailModel>>(orderDetails);
        }

        public async Task<List<OrderDetailModel>> GetOrderDetailsByUserId(string userId)
        {
            var orderDetailsEntities = await _orderDetailRepository.GetOrderDetailsByUserId(userId);
            return _mapper.Map<List<OrderDetailModel>>(orderDetailsEntities);
        }

    }
}
