using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin
{
    public class CourseManagerModel : PageModel
    {
        private readonly ICourseService _courseService;

        public List<Course> Courses { get; set; }

        public CourseManagerModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task OnGetAsync()
        {
            Courses = await _courseService.GetAll();
        }
    }
}
