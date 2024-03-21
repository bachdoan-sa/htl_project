using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.CourseLesson
{
    public class UpdateModel : PageModel
    {
        private readonly ICourseLessonService _courseLessonService;
        private readonly ICourseModuleService _courseModuleService;

        public UpdateModel(ICourseLessonService courseLessonService,
                           ICourseModuleService courseModuleService)
        {
            _courseLessonService = courseLessonService;
            _courseModuleService = courseModuleService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("/SignIn");
            }
            if (id == null)
            {
                return NotFound();
            }

            UpdateLesson = await _courseLessonService.GetById(id);

            if (UpdateLesson == null)
            {
                return NotFound();
            }
            var courseModules = await _courseModuleService.GetAll();
            var courseModulesList = courseModules.ToList();
            ViewData["CourseModules"] = courseModulesList;

            return Page();
        }
        [BindProperty]
        public CourseLessonModel UpdateLesson { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                
                UpdateLesson.LastUpdated = DateTimeOffset.Now;

                var result = await _courseLessonService.Update(UpdateLesson);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return Redirect("/Admin/CourseLesson/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create course lesson.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
