using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Services.IServices;

namespace WebHTL.Pages
{
    public class SignInModel : PageModel
    {
        private readonly IAccountService _accountService;
        public readonly IConfiguration _config;
        public SignInModel(IConfiguration config, IAccountService accountService)
        {
            _config = config;
            _accountService = accountService;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public string email { get; set; } = default!;
        [BindProperty]
        public string password { get; set; } = default!;
        [BindProperty]
        public string Message { get; set; } = default!;
        public IActionResult OnPost()
        {
            var adminAcc = _config["AdminAccount:Admin"];
            var adminPass = _config["AdminAccount:Password"];
            if (adminAcc == email && adminPass == password)
            {
                HttpContext.Session.SetString("Admin", email);
                return RedirectToPage("./Areas/Admin/AdminDashBoard");
            }
            try
            {
                _accountService.Login(email, password);
                HttpContext.Session.SetString("Customer", email);
                return RedirectToPage("./HomePage");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
                
            }
        }

    }
}
