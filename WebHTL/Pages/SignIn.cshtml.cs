using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHTL.Pages
{
    public class SignInModel : PageModel
    {
        public readonly IConfiguration _config;
        public SignInModel(IConfiguration config)
        {
            _config = config;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public string email { get; set; } = default!;
        [BindProperty]
        public string password { get; set; } = default!;
        public IActionResult OnPost()
        {
            var adminAcc = _config["AdminAccount:Admin"];
            var adminPass = _config["AdminAccount:Password"];
            if (adminAcc == email && adminPass == password)
            {
                HttpContext.Session.SetString("Admin", email);
                return RedirectToPage("./Areas/Admin/AdminDashBoard");
            }
            return Page();
        }

    }
}
