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
        public List<CourseModuleModel> CourseModules { get; private set; }
        public CourseLessonModel Lesson { get; private set; }

        [BindProperty(Name = "CourseLessonId")]
        public string CourseLessonId { get; set; }

        public async Task<IActionResult> OnGetAsync(string CourseId, string CourseLessonId, string CourseModulesId)
        {
            string a = "1"; // can sua sau nay'
            CourseModules = await _courseModuleService.GetByCourseId(CourseId);


            if (CourseId == null)
            {
                CourseId = (await _courseService.GetAll()).FirstOrDefault()?.Id;
            }

            if (CourseModulesId == null)
            {
                CourseModulesId = (await _courseModuleService.GetByCourseId(CourseId)).FirstOrDefault()?.Id;
            }

            if (CourseLessonId == null)
            {
                CourseLessonId = (await _courseLessonService.GetCourseLessonByCourseModuleId(CourseModulesId))?.Id;
            }

            Lesson = await _courseLessonService.GetById(CourseLessonId);
            return Page();
        }


    }
}
