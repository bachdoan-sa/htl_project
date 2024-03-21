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
        public IActionResult OnGet(string id)
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("/SignIn");
            }
            return Page();
        }
        [BindProperty]
        public CourseLessonModel UpdateLesson { get; set; } = new CourseLessonModel();
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                UpdateLesson.CreatedTime = DateTimeOffset.Now;
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
