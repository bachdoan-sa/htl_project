using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface ITransactionService
    {
        Task<TransactionModel> GetById(string id);
        Task<List<TransactionModel>> GetAll();
        Task<TransactionModel> Add(TransactionModel model);
        Task<TransactionModel> Update(TransactionModel model);
        Task<string> Delete(string id);
    }
}
