﻿using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface ITransactionRepository
    {
        
        Task<Transaction> GetById(string id);
        Task<List<Transaction>> GetAll();
        Task<Transaction> Add(Transaction transaction);
        Task<Transaction> Update(Transaction transaction);
        Task<string> Delete(string id);
        Task<string> AddbyHand(SetTransactionDto model);
    }
}
