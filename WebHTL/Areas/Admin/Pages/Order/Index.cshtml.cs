using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Repositories.IRepositories;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Order
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<OrderModel> Orders { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            Orders = await _orderService.GetAll();
        }
    }
}
