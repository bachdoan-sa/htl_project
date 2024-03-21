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

        try
        {
            var user = await _accountService.GetByEmail(Email);

            if (user == null)
            {
                Message = "Email does not exist in the database.";
            }
            else
            {
                var token = await _accountService.GenerateResetToken(Email);
                await _accountService.SendResetPasswordEmailAsync(Email);
            }
        }
        catch (Exception exception)
        {
            Message = exception.Message;
        }
        return Page();
    }
}