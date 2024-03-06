using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Services.IServices;
using System.Threading.Tasks;

public class ForgotPasswordModel : PageModel
{
    private readonly IAccountService _accountService;

    public ForgotPasswordModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty]
    public string Email { get; set; } = default!;

    public string Message { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var emailSent = await _accountService.SendResetPasswordEmailAsync(Email);
        if (emailSent)
        {
            Message = "An email with instructions to reset your password has been sent to your email address.";
        }
        else
        {
            Message = "User not found.";
        }

        return Page();
    }
}