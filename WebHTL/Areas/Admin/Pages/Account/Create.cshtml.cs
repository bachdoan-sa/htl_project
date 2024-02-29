using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Account
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public AccountModel NewAccount { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NewAccount.CreatedTime = DateTimeOffset.Now;
            NewAccount.LastUpdated = DateTimeOffset.Now;
            var result = await _accountService.Add(NewAccount);

            if (result != null)
            {
                return RedirectToPage("/Admin/Account/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to create account.");
                return Page();
            }
        }
    }
}
