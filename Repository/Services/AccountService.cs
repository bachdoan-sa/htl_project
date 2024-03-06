using AutoMapper;
using Repository.Entities;
using Repository.Model;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;
using Repository.Utils;
using System.Net.Mail;

namespace Repository.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public Task<List<AccountModel>> GetAll()
        {  
            var list = _accountRepository.GetAll().Result;
            return Task.FromResult(_mapper.Map<List<AccountModel>>(list));
        }

        public Task<AccountModel> GetById(string id)
        {
            var list = _accountRepository.GetById(id).Result;
            return Task.FromResult(_mapper.Map<AccountModel>(list));
        }
        public Task<AccountModel> Add(AccountModel model)
        {
            var entity = _mapper.Map<Account>(model);
            var result = _mapper.Map <AccountModel>(_accountRepository.Add(entity).Result);

            return Task.FromResult(result);
        }
 
        public Task<AccountModel> Update(AccountModel model)
        {
            var entity = _mapper.Map<Account>(model);
            var result = _mapper.Map<AccountModel>(_accountRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
        public Task<string> Delete(string id)
        {
            return _accountRepository.Delete(id);
        }

        public Task<Account> Login(string email, string password)
        {
            var acc = _accountRepository.GetByEmail(email).Result;
            if(acc.Password != password)
            {
                throw new Exception("Invalid Email or Password.");
            }
            return Task.FromResult(acc);
        }
        public async Task<bool> SendResetPasswordEmailAsync(string email)
        {
            var user = await _accountRepository.GetByEmail(email);
            if (user == null)
                return false; // User not found

            // Generate a reset token and save it to the user record
            var token = GenerateResetToken();
            user.ResetToken = token;
            await _accountRepository.Update(user);

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
            var user = await _accountRepository.GetByEmail(email);
            if (user == null || user.ResetToken != token)
                return false; // Token not valid or user not found

            // Reset password
            user.Password = HashPassword(newPassword); // Hash the new password before saving
            user.ResetToken = null; // Clear reset token
            await _accountRepository.Update(user);

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
            var user = await _accountRepository.GetByEmail(email);
            if (user == null)
            {
                return false; // Người dùng không tồn tại
            }
            // Kiểm tra xem token có khớp với token lưu trong người dùng hay không
            return user.ResetToken == token;
        }
    }
}
