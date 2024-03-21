using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.CourseLesson
{
    public class IndexModel : PageModel
    {
        private readonly ICourseLessonService _courseLessonService;

        public IndexModel(ICourseLessonService courseLessonService)
        {
            _courseLessonService = courseLessonService;
        }

        public List<CourseLessonModel> CourseLessons { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            CourseLessons = await _courseLessonService.GetAll();
        }
    }
}
