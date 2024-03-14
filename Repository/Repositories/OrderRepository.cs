using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Order> Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Task.FromResult(order);
        }

        public Task<string> Delete(string id)
        {
            var entity = _context.Orders.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public Task<List<Order>> GetAll()
        {
            return _context.Orders.ToListAsync();
        }

        public Task<Order> GetById(string id)
        {
            var acc = _context.Orders.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (acc.Result != null)
            {
                return acc;

            }
            throw new Exception("NotFound!");
        }

        public Task<Order> Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return Task.FromResult(order);
        }
        public async Task<decimal> GetTotalRevenueForCurrentMonth()
        {
            var now = DateTime.Now;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var totalRevenue = await _context.Orders
                .Where(o => o.DateCreated >= firstDayOfMonth && o.DateCreated < firstDayOfMonth.AddMonths(1))
                .SumAsync(o => o.Total);

            return totalRevenue;
        }
        public async Task<int> GetTotalOrdersForCurrentMonth()
        {
            var now = DateTime.Now;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var totalOrders = await _context.Orders
                .CountAsync(o => o.DateCreated >= firstDayOfMonth && o.DateCreated < firstDayOfMonth.AddMonths(1));

            return totalOrders;
        }
        public async Task<int> GetTotalOrderCount()
        {
            return await _context.Orders.CountAsync(); 
        }
    }
}
