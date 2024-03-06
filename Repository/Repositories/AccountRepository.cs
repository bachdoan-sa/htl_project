using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repository.ApplicationDbContext;
using Repository.Entities;
using Repository.Repositories.IRepositories;
using Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
            if(acc.Result != null)
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
        public Task<Account> Update(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return Task.FromResult(account);
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

        public Task<Account> GetByEmail(string email)
        {
            var acc = _context.Accounts.Where(_ => _.Email == email).FirstOrDefaultAsync().Result;
            if (acc != null)
            {
                return Task.FromResult(acc);

            }
            throw new Exception("NotFound!");
        }
        public async Task<bool> SendResetPasswordEmailAsync(string email)
        {
            var user = await GetByEmail(email);
            if (user == null)
                return false; // User not found

            // Generate a reset token and save it to the user record
            var token = GenerateResetToken();
            user.ResetToken = token;
            await Update(user);

            // Tạo nội dung email với URL cố định
            var resetUrl = $"https://localhost:7035/ResetPassword?email={email}&token={token}";
            var emailContent = $"Please reset your password by clicking the link below: <a href=\"{resetUrl}\">Reset Password</a>";

            // Gửi email
            try
            {
                var message = new MailMessage();
                message.To.Add(email);
                message.Subject = "Reset Your Password";
                message.Body = emailContent;
                message.IsBodyHtml = true;

                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new System.Net.NetworkCredential("boybybame@gmail.com", "Ductruong2810");
                    smtpClient.EnableSsl = true;

                    await smtpClient.SendMailAsync(message);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi gửi email
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await GetByEmail(email);
            if (user == null || user.ResetToken != token)
                return false; // Token not valid or user not found

            // Reset password
            user.Password = HashPassword(newPassword); // Hash the new password before saving
            user.ResetToken = null; // Clear reset token
            await Update(user);

            return true;
        }

        private string GenerateResetToken()
        {
            // Generate a unique token (e.g., GUID)
            return Guid.NewGuid().ToString();
        }

        private string HashPassword(string password)
        {
            // Hash password (you should use a secure hashing algorithm)
            return HashingAlgorithm.HashPassword(password);
        }

        public async Task<bool> VerifyResetTokenAsync(string email, string token)
        {
            // Truy vấn người dùng từ email
            var user = await GetByEmail(email);
            if (user == null)
            {
                return false; // Người dùng không tồn tại
            }

            // Kiểm tra xem token có khớp với token lưu trong người dùng hay không
            return user.ResetToken == token;
        }
    }
}
