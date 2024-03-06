using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHTL.Pages.Areas.Admin.Account
{
    public class UpdateModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("/SignIn");
            }
            return Page();
        }
    }
}
