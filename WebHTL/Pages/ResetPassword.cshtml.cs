using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Services.IServices;

public class ResetPasswordModel : PageModel
{
    private readonly IAccountService _accountService;

    public ResetPasswordModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty(SupportsGet = true)]
    public string Email { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string Token { get; set; } = default!;

    [BindProperty]
    public string NewPassword { get; set; } = default!;
    [BindProperty]
    public string ConfirmPassword { get; set; } = default!;
    [BindProperty]
    public string ErrorMessage { get; set; } = default!;
    [BindProperty]
    public bool TokenValid { get; set; }
    [BindProperty]
    public bool PasswordResetSuccess { get; set; }

    public void OnGet(string email, string token)
    {
        Email = email;
        Token = token;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        /*if (!ModelState.IsValid)
        {
            return Page();
        }*/

        if (!await _accountService.VerifyResetTokenAsync(Email, Token))
        {
            ErrorMessage = "Invalid OTP.";
            return Page();
        }

        await _accountService.ResetPasswordAsync(Email, NewPassword);
        TempData["Message"] = "Your password has been reset successfully. Please sign in with your new password.";
        return RedirectToPage("/SignIn");
    }
}