using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHTL.Pages
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = default!;
        public void OnGet()
        {
        }
    }
}
