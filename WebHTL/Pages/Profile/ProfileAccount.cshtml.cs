using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
    [BindProperties]
    public class ProfileAccountModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IDriverService _driverService;
        public ProfileAccountModel(IAccountService accountService, IDriverService driverService)
        {
            _accountService = accountService;
            _driverService = driverService;
        }
        public AccountModel Account { get; set; } = new AccountModel();
        public int RoadmapOngoing { get; set; } = 0;
        public int RoadmapFinish { get; set; } = 0;
        public IActionResult OnGet()
        {
            var userId = GetUser(); var admin = GetAdmin();
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(admin))
            {
                return Redirect("/SignIn");
            }
            if(admin != null) {
                return Redirect("/Admin/Index");
            }
            //code here
            Account =  _accountService.GetById(userId).Result;
            RoadmapOngoing = _driverService.GetListByUserId(userId).Result.Count;
            RoadmapOngoing = _driverService.GetListByUserId(userId).Result.Where(_=>_.DriverStatus.Equals("Finish")).Count();
            //end code
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
