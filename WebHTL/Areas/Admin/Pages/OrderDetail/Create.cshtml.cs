using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.OrderDetail
{
    public class CreateModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;

        public CreateModel(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [BindProperty]
        public OrderDetailModel NewOrderDetail { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                NewOrderDetail.CreatedTime = DateTimeOffset.Now;
                NewOrderDetail.LastUpdated = DateTimeOffset.Now;

                var result = await _orderDetailService.Add(NewOrderDetail);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return Redirect("/Admin/OrderDetail/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create order detail.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}