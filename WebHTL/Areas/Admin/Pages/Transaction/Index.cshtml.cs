using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Transaction
{
    public class IndexModel : PageModel
    {
        private readonly ITransactionService _transactionService;

        public IndexModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public List<TransactionModel> Transactions { get; set; }

        public async Task OnGetAsync()
        {
            Transactions = await _transactionService.GetAll();
        }
    }
}