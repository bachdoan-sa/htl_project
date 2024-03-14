using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Entities;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Transaction
{
    public class AddModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;

        public AddModel(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        [BindProperty]
        public SetTransactionDto Dto { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("/SignIn");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var account = await _accountService.GetByEmail(Email);
                if (account == null)
                {
                    ModelState.AddModelError(string.Empty, "Không tìm th?y tài kho?n v?i email ?ã nh?p.");
                    return Page();
                }

                // Gán ID c?a tài kho?n vào Order
                Dto.Order.AccountId = account.Id;
                // Map DTO to model
                var result = await _transactionService.AddByhand(Dto);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return Redirect("/Admin/Transaction/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to add transaction.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}