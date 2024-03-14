using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
	public class CheckoutModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IPaymentService _paymentService;

        public CheckoutModel(IOrderDetailService orderDetailService, IPaymentService paymentService)
        {
            _orderDetailService = orderDetailService;
            _paymentService = paymentService;
        }

        [BindProperty]
        public List<OrderDetailModel> OrderDetails { get; set; } = new List<OrderDetailModel>();

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("customerId") == null)
            {
                return RedirectToPage("/SignIn");
            }
            return Page();
        }

        public IActionResult OnPost(string paymentmethod, string selectedItems)
        {
            var selectedItemIds = selectedItems.Split(',')
                                     .Where(id => !string.IsNullOrEmpty(id))
                                     .ToList();
            foreach (var id in selectedItemIds)
            {
                var orderDetail = _orderDetailService.GetById(id).Result;
                OrderDetails.Add(orderDetail);
            }

            switch (paymentmethod)
            {
                case "cash":
                    _paymentService.ProcessCashPayment(OrderDetails);
                    break;
                case "banktransfer":
                    _paymentService.ProcessBankPayment(OrderDetails);
                    break;
                case "momo":
                    _paymentService.ProcessMomoPayment(OrderDetails);
                    break;
                default:
                    ModelState.AddModelError("", "Invalid payment method selected");
                    break;
            }

            if (!ModelState.IsValid)
                return Page(); 

            return RedirectToPage("/Success"); 
        }
    }
}
