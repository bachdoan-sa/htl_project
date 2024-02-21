using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHTL.Pages
{
    public class SignUpModel : PageModel
    {
        public void OnGet()
        {


        }
        [BindProperty]
        public string Email { get; set; } = default!;

        [BindProperty]
        public string Password { get; set; } = default!;

        [BindProperty]
        public string ConfirmPassword { get; set; } = default!;

    }
}
