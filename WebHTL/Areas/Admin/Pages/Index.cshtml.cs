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
        public List<AccountModel> MounthlyUsers { get; set; } = new List<AccountModel>();
        public List<dynamic> ChartData { get; set; } = new List<dynamic>();
        public async Task<IActionResult> OnGetAsync()
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
            MounthlyUsers = await _accountService.GetNewUsersForCurrentMonth();
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            // Tạo danh sách để lưu trữ số lượng đơn hàng và người dùng mới cho mỗi ngày
            var chartData = new List<object>();

            // Lặp qua mỗi ngày trong tháng
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var orderCount = MounthlyOrders.Count(order => order.CreatedTime.Date == date);
                var userCount = MounthlyUsers.Count(user => user.CreatedTime.Date == date);

                chartData.Add(new
                {
                    period = date.ToString("yyyy-MM-dd"), // Định dạng ngày theo chuẩn ISO
                    orders = orderCount,
                    users = userCount
                });
            }

            // Gửi dữ liệu đến view thông qua ViewBag hoặc ViewData
            ViewData["ChartData"] = chartData;

            return Page();
        }

    }
}
