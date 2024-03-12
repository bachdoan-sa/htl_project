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
        private readonly ICourseLessonService _courseLessonService;

        public CoursePageModel(ICourseModuleService courseModuleService, ICourseLessonService courseLessonService)
        {
            _courseModuleService = courseModuleService;
            _courseLessonService = courseLessonService;
        }
        public List<CourseModuleModel> CourseModules { get; private set; }
        public CourseLessonModel Lesson { get; private set; }

        public async Task<IActionResult> OnGetAsync(string courseId)
        {
            string a = "1";
            CourseModules = await _courseModuleService.GetByCourseId(a);

            if (CourseModules != null && CourseModules.Any())
            {
                var firstModule = CourseModules.FirstOrDefault();
                if (firstModule != null && firstModule.CourseLessons != null && firstModule.CourseLessons.Any())
                {
                    string lessonId = firstModule.CourseLessons.First().Id; // S? d?ng ID c?a bài h?c ??u tiên
                    Lesson = await _courseLessonService.GetCourseLessonByCourseModuleId(lessonId);
                }
            }
            return Page();
        }

        
    }
}