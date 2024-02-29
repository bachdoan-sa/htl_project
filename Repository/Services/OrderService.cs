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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task<OrderModel> Add(OrderModel model)
        {
            var entity = _mapper.Map<Order>(model);
            var result = _mapper.Map<OrderModel>(_orderRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<string> Delete(string id)
        {
            return _orderRepository.Delete(id);
        }

        public Task<List<OrderModel>> GetAll()
        {
            var list = _orderRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<OrderModel>>(list));
        }

        public Task<OrderModel> GetById(string id)
        {
            var list = _orderRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<OrderModel>(list));
        }

        public Task<OrderModel> Update(OrderModel model)
        {
            var entity = _mapper.Map<Order>(model);
            var result = _mapper.Map<OrderModel>(_orderRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
    }
}
