using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
    public class ProfileCourseModel : PageModel
    {
        private readonly ICourseModuleService _courseModuleService;
        private readonly ICourseLessonService _courseLessonService;
        private readonly ICourseService _courseService;


        public ProfileCourseModel(ICourseModuleService courseModuleService, ICourseLessonService courseLessonService, ICourseService courseService)
        {
            _courseModuleService = courseModuleService;
            _courseLessonService = courseLessonService;
            _courseService = courseService;
        }
        [BindProperty]
        public List<CourseModuleModel>? CourseModules { get; set; }
        [BindProperty]
        public CourseLessonModel? Lesson { get; set; }

        [BindProperty]
        public string? CourseLessonId { get; set; }

        public IActionResult OnGet(string? CourseId = "")
        {
            if(string.IsNullOrEmpty(CourseId))
            {
                return Redirect("/Profile/ProfileProduct");
            }
            CourseModules =  _courseModuleService.GetByCourseId(CourseId).Result;
            if(Lesson == null)
            {
                Lesson =  CourseModules[0].CourseLessons.FirstOrDefault();
            }
            return Page();
        }
        public IActionResult OnPost(string? CourseId = "")
        {
            if (CourseLessonId == null)
            {
                return OnGet(CourseId);
            }
            Lesson = _courseLessonService.GetById(CourseLessonId).Result;
            return OnGet(CourseId);
        }

    }
}
