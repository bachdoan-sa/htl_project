using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHTL.Pages.Profile
{
    public class ProfileAccountModel : PageModel
    {
        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetString("customerId");

            if (userId == null)
            {
                return RedirectToPage("/SignIn");
            }
            return Page();
        }
    }
}
