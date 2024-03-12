using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services;
using Repository.Services.IServices;

namespace WebHTL.Pages
{
    public class CoursePageModel : PageModel
    {
        private readonly ICourseModuleService _courseModuleService;

        public CoursePageModel(ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
        }
        public List<CourseModuleModel> CourseModules { get; private set; }

        public async Task<IActionResult> OnGetAsync(string courseId)
        {
            string a = "1";
            CourseModules = await _courseModuleService.GetByCourseId(a);
            return Page();
        }
    }
}