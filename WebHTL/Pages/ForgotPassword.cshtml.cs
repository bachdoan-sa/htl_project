using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Repositories.IRepositories;
using Repository.Services;
using Repository.Services.IServices;
using System.Threading.Tasks;

public class ForgotPasswordModel : PageModel
{
    private readonly IAccountService _accountService;

    public ForgotPasswordModel(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public void OnGet()
    {
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

        var user = await _accountService.GetByEmail(Email);
        if (user != null)
        {
            // Generate token and send email to user
            var token = await _accountService.GenerateResetToken(Email);
            await _accountService.SendResetPasswordEmailAsync(Email);
        }
        else
        {
            Message = "Email does not exist in the database.";
        }
        return Page();
    }
}