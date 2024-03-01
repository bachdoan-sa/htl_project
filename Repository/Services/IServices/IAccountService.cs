using Repository.Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface IAccountService
    {
        // Repo template: Chỉ nhận về model hoặc biến và trả về entity hoặc biến
        // Nếu dùng model thì phải chuyển về model trước khi vào repo
        
        Task<AccountModel> GetById(string id);
        Task<List<AccountModel>> GetAll();
        Task<AccountModel> Add(AccountModel model);
        Task<AccountModel> Update(AccountModel model);
        Task<string> Delete(string id);
        Task<Account> Login(string username, string password);
        Task<bool> SendResetPasswordEmailAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
        Task<bool> VerifyResetTokenAsync(string email, string token);
    }
}
