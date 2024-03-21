using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IAccountService _accountService;
        public SignUpModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string Email { get; set; } = default!;

        [BindProperty]
        public string Password { get; set; } = default!;

        [BindProperty]
        public string ConfirmPassword { get; set; } = default!;
        [BindProperty]
        public string Message { get; set; } = default!;
        public IActionResult OnPost()
        {
            AccountModel account = new AccountModel
            {
                UserName = "",
                Email = Email,
                Password = Password,
                Phone = "",
                Birthdate = DateTime.UtcNow,
                Role = "Customer",
                Work = "student"
            };
            var result = _accountService.Add(account).Result;

            if (result == null)
            {
                Message = "Email already exists. Please choose a different email.";
            }
            else
            {
                Message = "Create Account Success: " + result.Email;
                return RedirectToPage("/SignIn");
            }
            return Page();
        }
    }
}
