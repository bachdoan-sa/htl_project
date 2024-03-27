using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebAppRazorpage.Pages.Areas.Admin
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;

        public IndexModel(IOrderService orderService, IAccountService accountService)
        {

            _orderService = orderService;
            _accountService = accountService;
        }
        public decimal TotalRevenue { get; set; } = 0;
        public int TotalOrders { get; set; } = 0;
        public int TotalStores { get; set; } = 0;
        public int TotalNewUsers { get; set; } = 0;
        public List<OrderModel> RecentOrdersWithUsers { get; set; } = new List<OrderModel>();
        public List<OrderModel> MounthlyOrders { get; set; } = new List<OrderModel>();
        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            TotalRevenue = await _orderService.GetTotalRevenueForCurrentMonth();
            TotalOrders = await _orderService.GetTotalOrdersForCurrentMonth();
            TotalStores = await _orderService.GetTotalOrderCount();
            TotalNewUsers = await _accountService.GetNewUserCountForCurrentMonth();
            RecentOrdersWithUsers = await _orderService.GetRecentOrdersWithUsers(4);
            MounthlyOrders = await _orderService.GetMonthlyOrders();
        }

    }
}
