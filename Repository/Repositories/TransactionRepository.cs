using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Model;
using Repository.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Transaction> GetById(string id)
        {
            var trans = _context.Transactions.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (trans.Result != null)
            {
                return trans;

            }
            throw new Exception("NotFound!");
        }
        public Task<List<Transaction>> GetAll()
        {
            return _context.Transactions.ToListAsync();
        }
        public Task<Transaction> Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return Task.FromResult(transaction);
        }
        public Task<Transaction> Update(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
            return Task.FromResult(transaction);
        }
        public Task<string> Delete(string id)
        {

            var entity = _context.Transactions.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }
        public Task<string> AddbyHand(SetTransactionDto model)
        {
            var order = new Order()
            {
                Total = model.Order.Total ?? 0,
                OrderStatus = model.Order.OrderStatus,
                AccountId = model.Order.AccountId,

            };

            var tran = new Transaction()
            {
                PaymentMethod = model.Transaction.PaymentMethod,
                Amount = model.Transaction.Amount ?? 0,
                TransactionStatus = model.Transaction.TransactionStatus,
                Message = model.Transaction.Message,
                ReponseTime = model.Transaction.ReponseTime ?? 0,
                OrderId = order.Id,
            };

            var driver = new Driver()
            {
                StartTime = model.Driver.StartTime ?? DateTimeOffset.Now,
                ExpectedEndTime = model.Driver.ExpectedEndTime ?? DateTimeOffset.Now,
                Type = model.Driver.Type,
                DriverStatus = model.Driver.DriverStatus,
                RoadmapId = model.Driver.RoadmapId,
            };

            var orderDetail = new OrderDetail()
            {
                OrderDetailStatus = model.OrderDetail.OrderDetailStatus,
                Cost = model.OrderDetail.Cost ?? 0,
                DriverId = driver.Id,
                OrderId = order.Id,
            };
            _context.Orders.Add(order);
            _context.Transactions.Add(tran);
            _context.Drivers.Add(driver);
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return Task.FromResult("OK");
        }



    }
}
