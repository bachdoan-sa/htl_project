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
        public SetTransactionDto Dto { get; set; } = new SetTransactionDto();
        [BindProperty]
        public float? Amount { get; set; }

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
                    ModelState.AddModelError(string.Empty, "Không tìm thấy tài khoản với email đã nhập.");
                    return Page();
                }

                // Gán ID c?a tài kho?n vào Order
                Dto.Order.AccountId = account.Id;
                Dto.Driver.DriverStatus = "Active";
                Dto.Transaction.Amount = Amount ?? 0;
                Dto.Transaction.TransactionStatus = "ok";
                Dto.Order.Total = (decimal) (Amount ?? 0);
                Dto.Order.OrderStatus = "done";
                Dto.OrderDetail.OrderDetailStatus = "done";
                Dto.OrderDetail.Cost = (decimal) (Amount ?? 0);
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