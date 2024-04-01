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
        public int MonthChart { get; set; } = DateTime.UtcNow.Month;
        public decimal TotalRevenue { get; set; } = 0;
        public int TotalOrders { get; set; } = 0;
        public int TotalStores { get; set; } = 0;
        public int TotalUsers { get; set; } = 0;
        public List<OrderModel> RecentOrdersWithUsers { get; set; } = new List<OrderModel>();
        public List<OrderModel> MounthlyOrders { get; set; } = new List<OrderModel>();
        public List<AccountModel> MounthlyUsers { get; set; } = new List<AccountModel>();
        public List<dynamic> ChartData { get; set; } = new List<dynamic>();
        public async Task<IActionResult> OnGetAsync(int? mounth)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            TotalRevenue = await _orderService.GetTotalRevenue();
            TotalOrders = await _orderService.GetTotalOrders();
            TotalStores = await _orderService.GetTotalOrderCount();
            TotalUsers = await _accountService.GetAllUserCount();
            RecentOrdersWithUsers = await _orderService.GetRecentOrdersWithUsers(4);
            MounthlyOrders = await _orderService.GetMonthlyOrders(mounth);
            MounthlyUsers = await _accountService.GetNewUsersForCurrentMonth(mounth);
            var startDate = new DateTime(DateTime.Now.Year, mounth ?? DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            // Tạo danh sách để lưu trữ số lượng đơn hàng và người dùng mới cho mỗi ngày
            var chartData = new List<object>();

            // Lặp qua mỗi ngày trong tháng
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var orderCount = MounthlyOrders.Count(order => order.CreatedTime?.Date == date);
                var userCount = MounthlyUsers.Count(user => user.CreatedTime?.Date == date);

                chartData.Add(new
                {
                    period = date.ToString("yyyy-MM-dd"), // Định dạng ngày theo chuẩn ISO
                    orders = orderCount,
                    users = userCount
                });
            }

            // Gửi dữ liệu đến view thông qua ViewBag hoặc ViewData
            ViewData["ChartData"] = chartData;
            // Tính tỷ lệ phần trăm
            var ordersPercentage = ((float)MounthlyOrders.Count / TotalOrders) * 100;
            var usersPercentage = ((float)MounthlyUsers.Count / TotalUsers) * 100;

            // Làm tròn đến hai chữ số thập phân
            ordersPercentage = (float)Math.Round(ordersPercentage, 2);
            usersPercentage = (float)Math.Round(usersPercentage, 2);

            // Gửi dữ liệu đến front-end
            ViewData["OrdersPercentage"] = ordersPercentage;
            ViewData["UsersPercentage"] = usersPercentage;

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return await OnGetAsync(MonthChart);
        }

    }
}
