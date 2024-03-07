using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Account
{
    public class UpdateModel : PageModel
    {
        private readonly IAccountService _accountService;

        [BindProperty]
        public AccountModel Account { get; set; }

        public UpdateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("/SignIn");
            }
            Account = await _accountService.GetById(id);
            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // You might want to perform some validation or sanitization before updating
            await _accountService.Update(Account);

            return RedirectToPage("./Index"); // Redirect to some page after successful update
        }
    }
}