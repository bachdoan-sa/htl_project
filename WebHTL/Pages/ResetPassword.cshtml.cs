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
        }

        return Page();
    }
}
