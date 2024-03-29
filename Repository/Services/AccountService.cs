﻿using AutoMapper;
using Repository.Entities;
using Repository.Model;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;
using System.Net;
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
            var result = _mapper.Map<AccountModel>(_accountRepository.Add(entity).Result);

            return Task.FromResult(result);
        }

        public Task<AccountModel> Update(AccountModel model)
        {
            var entity = _mapper.Map<Account>(model);
            var result = _mapper.Map<AccountModel>(_accountRepository.Update(entity).Result);

            return Task.FromResult(result);
        }
        public Task<string> Update(AccountModel model, bool isProfile)
        {
            if (isProfile)
            {
                var acc = _accountRepository.GetById(model.Id).Result;
                acc.Phone = model.Phone;
                acc.Birthdate = model.Birthdate ?? DateTimeOffset.Now;
                _accountRepository.Update(acc);

                return Task.FromResult(acc.Id);
            }
            throw new NotImplementedException();

        }
        public Task<string> UpdatePassword(string id, string password)
        {

            var acc = _accountRepository.GetById(id).Result;
            acc.Password = password;
            _accountRepository.Update(acc);

            return Task.FromResult(acc.Id);


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

            // Kiểm tra xem người dùng và ResetToken có tồn tại không
            if (user == null || string.IsNullOrEmpty(user.ResetToken))
            {
                await _emailSender.SendEmailAsync(
                    email,
                    "Reset Password",
                    "If an account with this email address exists, a password reset link has been sent. Please check your email.");
                return;
            }

            // Encode email và token để đảm bảo chúng an toàn khi được chuyển qua URL
            string tokenEncoded = WebUtility.UrlEncode(user.ResetToken);
            string emailEncoded = WebUtility.UrlEncode(email);

            // Tạo URL an toàn với HTTPS và các tham số đã được encode
            var callbackUrl = $"https://localhost:7035/ResetPassword?email={emailEncoded}&token={tokenEncoded}";

            // Gửi email với URL đặt lại mật khẩu
            await _emailSender.SendEmailAsync(
                email,
                "Reset Password",
                $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
        }

        public static string GenerateResetToken()
        {
            var randomBytes = new byte[40];
            RandomNumberGenerator.Fill(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public async Task<bool> VerifyResetTokenAsync(string email, string token)
        {
            var user = await _accountRepository.GetByEmail(email);
            return user != null && user.ResetToken == token;
        }

        public async Task ResetPasswordAsync(string email, string newPassword)
        {
            var user = await _accountRepository.GetByEmail(email);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

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
