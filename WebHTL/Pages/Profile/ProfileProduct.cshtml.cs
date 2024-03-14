using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
    [BindProperties]
    public class ProfileProductModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IDriverService _driverService;
        public ProfileProductModel(IAccountService accountService, IDriverService driverService)
        {
            _accountService = accountService;
            _driverService = driverService;
        }
        public List<DriverModel> Drivers { get; set; } = new List<DriverModel>();
        public IActionResult OnGet()
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
            //-----------------------


            Drivers = _driverService.GetListByUserId(userId).Result;


            //-----------------------
            return Page();
        }
        #region private method get user and admin
        private string? GetUser()
        {
            string? id = HttpContext.Session.GetString("CustomerId");
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
