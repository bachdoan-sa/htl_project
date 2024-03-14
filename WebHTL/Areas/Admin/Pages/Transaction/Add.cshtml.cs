using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Transaction
{
    public class AddModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        

        public AddModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            
        }

        [BindProperty]
        public SetTransactionDto Dto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            


            try
            {
                // Map DTO to model
                var result = await _transactionService.AddByhand(Dto);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return RedirectToPage("/Admin/Transaction/Index");
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