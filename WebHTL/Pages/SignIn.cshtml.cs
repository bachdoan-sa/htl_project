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
        public string Email { get; set; } = default!;
        [BindProperty]
        public string Password { get; set; } = default!;
        [BindProperty]
        public string Message { get; set; } = default!;
        public IActionResult OnPost()
        {
            try
            {

                var adminAcc = _config["AdminAccount:Admin"];
                var adminPass = _config["AdminAccount:Password"];
                if (adminAcc == Email && adminPass == Password)
                {
                    HttpContext.Session.SetString("Admin", Email);
                    return Redirect("~/Admin/Index");
                }
                var cus = _accountService.Login(Email, Password);
                HttpContext.Session.SetInt32("customerId", cus.Id);
                return RedirectToPage("./Profile/Index");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();

            }
        }

    }
}
