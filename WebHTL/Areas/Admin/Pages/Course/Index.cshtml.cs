using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Course
{
    public class IndexModel : PageModel
    {
        private readonly ICourseService _courseService;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public List<CourseModel> Courses { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            Courses = await _courseService.GetAll();
        }
    }
}