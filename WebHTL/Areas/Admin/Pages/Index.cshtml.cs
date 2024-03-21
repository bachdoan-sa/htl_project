using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebAppRazorpage.Pages.Areas.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;

        public decimal TotalRevenue { get; set; } = default!;
        public int TotalOrders { get; set; } = default!;
        public int TotalStores { get; set; } = default!;
        public int TotalNewUsers { get; set; } = default!;
        public List<OrderModel> RecentOrdersWithUsers { get; private set; }

        public IndexModel(IOrderService orderService, IAccountService accountService)
        {

            _orderService = orderService;
            _accountService = accountService;
        }

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
        }

    }
}
