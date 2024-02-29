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

        public List<CourseModuleModel> CourseModules { get; set; }

        public async Task OnGetAsync()
        {
            CourseModules = await _courseModuleService.GetAll();
        }
    }
}