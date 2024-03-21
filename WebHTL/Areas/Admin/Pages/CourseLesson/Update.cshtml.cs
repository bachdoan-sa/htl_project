using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.CourseLesson
{
    public class UpdateModel : PageModel
    {
        private readonly ICourseLessonService _courseLessonService;

        public UpdateModel(ICourseLessonService courseLessonService)
        {
            _courseLessonService = courseLessonService;
        }

        [BindProperty]
        public CourseLessonModel CourseLesson { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("/SignIn");
            }
            CourseLesson = await _courseLessonService.GetById(id);

            if (CourseLesson == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _courseLessonService.Update(CourseLesson);

            return RedirectToPage("./Index"); 
        }
    }
}
