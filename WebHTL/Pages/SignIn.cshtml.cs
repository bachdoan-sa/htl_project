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
            HttpContext.Session.Remove("Admin");
            HttpContext.Session.Remove("CustomerId");
        }
        [BindProperty]
        public string Email { get; set; } = default!;
        [BindProperty]
        public string Password { get; set; } = default!;
        [BindProperty]
        public string Message { get; set; } = default!;
        public IActionResult OnPost()
        {
            var adminAcc = _config["AdminAccount:Admin"];
            var adminPass = _config["AdminAccount:Password"];
            if (adminAcc == Email && adminPass == Password)
            {
                HttpContext.Session.SetString("Admin", Email);
                return Redirect("~/Admin/Index");
            }
            else
            {
                try
                {
                    var cus = _accountService.Login(Email, Password).Result;
                    HttpContext.Session.SetString("CustomerId", cus.Id);
                    return RedirectToPage("./Profile/Index");
                }
                catch (Exception)
                {
                    Message = "Incorrect login";
                    return Page();
                }
            }
        }
    }
}
