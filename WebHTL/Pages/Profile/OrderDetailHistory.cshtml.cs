using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
    public class OrderDetailHistoryModel : PageModel
    {
        private readonly IOrderDetailService _service; 
        public List<OrderDetailModel> OrderDetails { get; set; }

        public OrderDetailHistoryModel(IOrderDetailService service) 
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(string orderId)
        {
            var userId = GetUser(); var admin = GetAdmin();
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(admin))
            {
                return Redirect("/SignIn");
            }
            if (admin != null)
            {
                return Redirect("/Admin/Index");
            }

            // G?i service ?? l?y danh sách chi ti?t ??n hàng d?a trên orderId
            OrderDetails = await _service.GetOrderDetailsByOrderId(orderId);
            return Page();
        }
        #region private method get user and admin
        private string? GetUser()
        {
            string? id = HttpContext.Session.GetString("customerId");
            if (id != null)
            {
                return id;
            }
            return null;
        }
        private string? GetAdmin()
        {
            string? id = HttpContext.Session.GetString("Admin");
            if (id != null)
            {
                return id;
            }
            return null;
        }
        #endregion
    }
}
