using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.OrderDetail

{
    public class IndexModel : PageModel
    { 

        private readonly IOrderDetailService _orderDetailService;

        public IndexModel(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        public List<OrderDetailModel> OrderDetails { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            OrderDetails = await _orderDetailService.GetAll();
        }
    }
}
