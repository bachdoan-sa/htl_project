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

        public async Task<OrderModel> Add(OrderModel model)
        {
            var entity = _mapper.Map<Order>(model);
            var resultEntity = await _orderRepository.Add(entity);
            var resultModel = _mapper.Map<OrderModel>(resultEntity);

            return resultModel;
        }

        public async Task<string> Delete(string id)
        {
            return await _orderRepository.Delete(id);
        }

        public async Task<List<OrderModel>> GetAll()
        {
            var list = await _orderRepository.GetAll();
            return _mapper.Map<List<OrderModel>>(list);
        }

        public async Task<OrderModel> GetById(string id)
        {
            var entity = await _orderRepository.GetById(id);
            return _mapper.Map<OrderModel>(entity);
        }

        public async Task<OrderModel> Update(OrderModel model)
        {
            var entity = _mapper.Map<Order>(model);
            var updatedEntity = await _orderRepository.Update(entity);
            return _mapper.Map<OrderModel>(updatedEntity);
        }

        public async Task<decimal> GetTotalRevenueForCurrentMonth()
        {
            return await _orderRepository.GetTotalRevenueForCurrentMonth();
        }
        public async Task<int> GetTotalOrdersForCurrentMonth()
        {
            return await _orderRepository.GetTotalOrdersForCurrentMonth();
        }
        public async Task<int> GetTotalOrderCount()
        {
            return await _orderRepository.GetTotalOrderCount(); 
        }
        public async Task<List<OrderModel>> GetRecentOrdersWithUsers(int count)
        {
            return await _orderRepository.GetRecentOrdersWithUsers(count);
        }
        public async Task<List<OrderModel>> GetAllByAccountId(string id)
        {
            var entity = await _orderRepository.GetAllByAccountId(id);
            return _mapper.Map<List<OrderModel>>(entity);
        }

        public Task<decimal> GetTotalRevenue()
        {
            var data = _orderRepository.GetTotalRevenue();
            return data;
        }

        public Task<int> GetTotalOrders()
        {
            var data = _orderRepository.GetTotalOrders();
            return data;
        }

        public Task<List<OrderModel>> GetMonthlyOrders(int? month)
        {
            var data = _orderRepository.GetMonthlyOrders(month).Result;
            var list = _mapper.Map<List<OrderModel>>(data);
            return Task.FromResult(list);
        }
    }
}
