using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Services.IServices;

namespace WebAppRazorpage.Pages.Areas.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;

        // Biến để lưu tổng doanh thu
        public decimal TotalRevenue { get; set; }

        public IndexModel(IOrderService orderService)
        {

            _orderService = orderService;
        }

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            TotalRevenue = await _orderService.GetTotalRevenueForCurrentMonth();
        }

    }
}
