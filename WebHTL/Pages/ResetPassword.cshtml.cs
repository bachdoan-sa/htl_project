using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebHTL.Pages
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = default!;
        [BindProperty]
        public int RSState { get; set; } = 0!;
        [BindProperty]
        public string ResetPasswordOtp { get; set; } = default!;
        [BindProperty]
        public string Password { get; set; } = default!;
        [BindProperty]
        public string PasswordConfirm { get; set; } = default!;
        public IActionResult OnPost()
        {
            //account toofn tai
            if (Email != default!)
            {
                RSState = 1;
            }
            //xu li gui mail va tao otp
            //xu li otp va so sanh hop le
            if (ResetPasswordOtp != default!)
            {
                RSState = 2;
            }
            if(Password != default! && Password == PasswordConfirm)
            {
                return RedirectToPage("./HomePage");
            }
            return Page();
        }
    }
}
