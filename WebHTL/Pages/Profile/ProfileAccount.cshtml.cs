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
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get;    set; } = string.Empty; 
        public IActionResult OnPostUpdatePassword()
        {
            var id = GetUser();
            var model = _accountService.GetById(id).Result;
            
            if(OldPassword == model.Password)
            {
                if(NewPassword == ConfirmPassword)
                {
                    _accountService.UpdatePassword(model.Id, ConfirmPassword);
                    return OnGet();
                }
            }
            return Redirect("/SignIn");
            

            
        }
        #region private method get user and admin
        private string? GetUser()
        {
            string? id = HttpContext.Session.GetString("customerId");
            if (!string.IsNullOrEmpty(id))
            {
                return id;
            }
            return null;
        }
        private string? GetAdmin()
        {
            string? id = HttpContext.Session.GetString("Admin");
            if (!string.IsNullOrEmpty(id))
            {
                return id;
            }
            return null;
        }
        #endregion
    }
}
