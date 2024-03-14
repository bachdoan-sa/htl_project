﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Repositories.IRepositories;

namespace Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<Account> GetById(string id)
        {
            var acc = _context.Accounts.Where(_ => _.Id == id).FirstOrDefaultAsync();
            if (acc.Result != null)
            {
                return acc;

            }
            throw new Exception("NotFound!");
        }
        public Task<List<Account>> GetAll()
        {
            return _context.Accounts.ToListAsync();
        }
        public Task<Account> Add(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return Task.FromResult(account);
        }
        public async Task<Account> Update(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
        public Task<string> Delete(string id)
        {

            var entity = _context.Accounts.Where(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("Not Found!");
            }
            entity.DeleteDate = DateTime.Now;
            _context.SaveChanges();

            return Task.FromResult(entity.Id);
        }

        public async Task<Account?> GetByEmail(string email)
        {
            return await _context.Accounts.FirstOrDefaultAsync(account => account.Email == email);
        }

        public async Task SetResetToken(string email, string token)
        {
            var user = await GetByEmail(email);
            if (user == null)
            {
                throw new Exception("Account not found");
            }

            user.ResetToken = token;

            await _context.SaveChangesAsync();
        }
        public async Task<int> GetNewUserCountForCurrentMonth()
        {
            var now = DateTimeOffset.Now;
            var firstDayOfMonth = new DateTimeOffset(new DateTime(now.Year, now.Month, 1));
            var newUserCount = await _context.Accounts
                .CountAsync(a => a.CreatedTime >= firstDayOfMonth && a.CreatedTime < firstDayOfMonth.AddMonths(1));

            return newUserCount;
        }
    }
}