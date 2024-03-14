using AutoMapper;
using Repository.Entities;
using Repository.Model;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public AccountService(IAccountRepository accountRepository, IMapper mapper, IEmailSender emailSender)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _emailSender = emailSender;
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

        public async Task<Account> Login(string email, string password)
        {
            var acc = await _accountRepository.GetByEmail(email);
            if (acc == null)
            {
                throw new Exception("Account not found.");
            }
            else if (acc.Password != password)
            {
                throw new Exception("Invalid Password.");
            }
            return acc;
        }
        public async Task<Account?> GetByEmail(string email)
        {
            try
            {
                var acc = await _accountRepository.GetByEmail(email);
                return acc;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                return null;
            }
        }

        public async Task<string> GenerateResetToken(string email)
        {
            var user = await _accountRepository.GetByEmail(email);
            var token = GenerateResetToken();

            await _accountRepository.SetResetToken(email, token);

            return token;
        }

        public async Task SendResetPasswordEmailAsync(string email)
        {
            var user = await _accountRepository.GetByEmail(email);
            var callbackUrl = $"http://yourwebsite.com/ResetPassword?email={email}&token={user?.ResetToken}";

            await _emailSender.SendEmailAsync(
                email,
                "Reset Password",
                $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
        }

        public string GenerateResetToken()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[40]; // Sau này, token sẽ có ~54 ký tự
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public async Task<bool> VerifyResetTokenAsync(string email, string token)
        {
            var user = await _accountRepository.GetByEmail(email);
            return user.ResetToken == token;
        }

        public async Task ResetPasswordAsync(string email, string newPassword)
        {
            using var hmac = new HMACSHA512();

            var user = await _accountRepository.GetByEmail(email);
            user.Password = newPassword;
            user.ResetToken = null;

            await _accountRepository.Update(user);
        }
        public async Task<int> GetNewUserCountForCurrentMonth()
        {
            return await _accountRepository.GetNewUserCountForCurrentMonth();
        }
    }
}
