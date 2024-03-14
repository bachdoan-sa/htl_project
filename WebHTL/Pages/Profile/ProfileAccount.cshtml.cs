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
        public async Task<IActionResult> OnPostUpdateAccount()
        {
            var accountModel = new AccountModel();
            accountModel.Id = GetUser();
            accountModel.Phone = Account.Phone;
            accountModel.Birthdate = Account.Birthdate;

            var a = await _accountService.Update(accountModel, true);

            return OnGet();

        }
        public IActionResult OnPostUpdatePassword([FromForm] string oldpassword, string newpassword, string passwordconfirm)
        {
            var id = GetUser();
            var model = _accountService.GetById(id).Result;
            
            if(oldpassword == model.Password)
            {
                if(newpassword == passwordconfirm)
                {
                    _accountService.UpdatePassword(model.Id, newpassword);
                    return OnGet();
                }
            }
            return Redirect("/SignIn");
            

            
        }
        #region private method get user and admin
        private string? GetUser()
        {
            string? id = HttpContext.Session.GetString("customerId");
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
