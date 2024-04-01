using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.IRepositories
{
    public interface IAccountRepository
    {
        // Repo template: Chỉ nhận về entity hoặc biến và trả về entity hoặc biến
        // Nếu dùng model thì phải chuyển về model trước khi vào repo
        Task<Account?> GetByEmail(string email);
        Task<Account> GetById(string id);
        Task<List<Account>> GetAll();
        Task<Account> Add(Account roadmap);
        Task<Account> Update(Account roadmap);
        Task<string> Delete(string id);
        Task SetResetToken(string email, string token);
        Task<int> GetAllUserCount();
        Task<int> GetNewUserCountForCurrentMonth();
        Task<List<Account>> GetNewUsersForCurrentMonth(int? month = null);
    }
}
