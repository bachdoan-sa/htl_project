using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Driver
{
    public class IndexModel : PageModel
    {
        private readonly IDriverService _driverService;

        public IndexModel(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public List<DriverModel> Drivers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            Drivers = await _driverService.GetAll();
        }
    }
}