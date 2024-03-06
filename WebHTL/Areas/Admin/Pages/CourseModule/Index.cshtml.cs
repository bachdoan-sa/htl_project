using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.CourseModule
{
    public class IndexModel : PageModel
    {
        private readonly ICourseModuleService _courseModuleService;

        public IndexModel(ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
        }

        public List<CourseModuleModel> CourseModules { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            CourseModules = await _courseModuleService.GetAll();
        }
    }
}