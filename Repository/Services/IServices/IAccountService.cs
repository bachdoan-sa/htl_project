using System.Threading.Tasks;
using Repository.Entities;
using Repository.Model;

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
        Task<string> Update(AccountModel model, bool IsUserProfile);
        Task<string> UpdatePassword(string id, string pass);
        Task<string> Delete(string id);
        Task<Account> Login(string username, string password);
        Task<Account?> GetByEmail(string email);
        Task<string> GenerateResetToken(string email);
        Task SendResetPasswordEmailAsync(string email);
        Task<bool> VerifyResetTokenAsync(string email, string token);
        Task ResetPasswordAsync(string email, string newPassword);
        Task<int> GetNewUserCountForCurrentMonth();
        Task<List<AccountModel>> GetNewUsersForCurrentMonth();
    }
}
