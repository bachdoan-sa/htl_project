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
    public class ShoppingCartModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        [BindProperty]
        public List<OrderDetailModel> OrderDetails { get; set; } = default!;
        public OrderDetailModel OrderDetail { get; set; } = default!;

        public ShoppingCartModel(IOrderDetailService service)
        {
            _orderDetailService = service;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            OrderDetails = await _orderDetailService.GetAll();

            if (OrderDetails == null || !OrderDetails.Any())
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, OrderDetailModel model)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("", "ID is not provided!");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model is invalid!");
                return Page();
            }
            if (OrderDetails.Any(order => order.OrderId == id))
            {
                await _orderDetailService.Update(model);
            }
            else
            {
                await _orderDetailService.Add(model);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            await _orderDetailService.Delete(id);

            return Page();
        }
    }
}