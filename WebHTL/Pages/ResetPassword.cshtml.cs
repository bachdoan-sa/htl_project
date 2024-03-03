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
    public string ErrorMessage { get; set; } = default!;

    public bool TokenValid { get; set; }

    public bool PasswordResetSuccess { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        TokenValid = await _accountService.VerifyResetTokenAsync(Email, Token);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        TokenValid = await _accountService.VerifyResetTokenAsync(Email, Token);
        if (TokenValid)
        {
            PasswordResetSuccess = await _accountService.ResetPasswordAsync(Email, Token, NewPassword);

            if (PasswordResetSuccess)
            {
                // Password reset success, redirect to SignIn page with success message
                TempData["Message"] = "Password reset successfully. Please sign in with your new password.";
                return RedirectToPage("/SignIn");
            }
            else
            {
                // Password reset failed, return to the current page with error message
                TempData["ErrorMessage"] = "Failed to reset password. Please try again.";
                return Page();
            }
        }
        else
        {
            // Token is not valid, return to the current page with error message
            TempData["ErrorMessage"] = "Invalid token. Please try again or request a new reset link.";
            return Page();
        }
    }
}
