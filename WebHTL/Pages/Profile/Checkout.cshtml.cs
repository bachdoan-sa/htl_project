using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Repository.Model;
using Repository.Services;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
    public class CheckoutModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        // Assume other services are injected as needed

        [BindProperty]
        public TransactionModel Transaction { get; set; } = default!;

        private readonly IOrderDetailService _orderDetailService;
        public List<OrderDetailModel> OrderDetails { get; set; } = default!;
        public decimal TotalAmount { get; set; }

        public CheckoutModel(ITransactionService transactionService, IOrderDetailService orderDetailService)
        {
            _transactionService = transactionService;
            _orderDetailService = orderDetailService;
        }

        public async Task<IActionResult> OnGet(string items)
        {
            if (HttpContext.Session.GetString("customerId") == null)
            {
                return RedirectToPage("/SignIn");
            }
            var itemIds = items?.Split(',') ?? new string[0];

            OrderDetails = await _orderDetailService.GetOrderDetailsByIds(itemIds);

            TotalAmount = OrderDetails.Sum(od => od.Quantity * od.Price);

            if (TotalAmount > 0 && OrderDetails.Any())
            {
                return Page();
            }
            else
            {
                TempData["ErrorMessage"] = "Your shopping cart is empty or an error occurred.";
                return RedirectToPage("/Profile/ShoppingCart");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Process the payment based on the selected method
            if (Transaction.PaymentMethod == "Bank")
            {
                // Process bank transfer
            }
            else if (Transaction.PaymentMethod == "Momo")
            {
                // Process Momo payment
            }

            // Redirect to a confirmation page or display a success message
            return RedirectToPage("/PaymentConfirmation");
        }
    }
}
