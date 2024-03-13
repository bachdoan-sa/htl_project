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

    public void OnGet(string email, string token)
    {
        Email = email;
        Token = token;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!await _accountService.VerifyResetTokenAsync(Email, Token))
        {
            ErrorMessage = "Invalid token.";
            return Page();
        }

        // Reset password and redirect to sign in page
        await _accountService.ResetPasswordAsync(Email, NewPassword);
        return RedirectToPage("SignIn");
    }
}