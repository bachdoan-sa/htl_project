using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _context;
        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<OrderDetail> GetById(string id)
        {
            var orderdetail = _context.OrderDetails.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (orderdetail.Result != null)
            {
                return orderdetail;

            }
            throw new Exception("NotFound!");
        }
        public Task<List<OrderDetail>> GetAll()
        {
            return _context.OrderDetails.ToListAsync();
        }
        public Task<OrderDetail> Add(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return Task.FromResult(orderDetail);
        }
        public Task<OrderDetail> Update(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            _context.SaveChanges();
            return Task.FromResult(orderDetail);
        }
        public Task<string> Delete(string id)
        {

            var entity = _context.OrderDetails.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByIds(string[] itemIds)
        {
            var orderDetailsList = await _context.OrderDetails
                .Where(od => itemIds.Contains(od.Id))
                .ToListAsync();

            return orderDetailsList;
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByUserId(string userId)
        {
            return await _context.OrderDetails
                .Where(od => od.Order.AccountId == userId)
                .ToListAsync();
        }


        public async Task<List<OrderDetail>> GetOrderDetailsByOrderId(string Id)
        {
            return await _context.OrderDetails
                .Where(od => od.OrderId == Id)
                .ToListAsync();
        }
    }

}
