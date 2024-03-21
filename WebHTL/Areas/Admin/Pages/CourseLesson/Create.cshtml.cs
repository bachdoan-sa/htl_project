using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.CourseLesson
{
    public class CreateModel : PageModel
    {
        private readonly ICourseLessonService _courseLessonService;

        public CreateModel(ICourseLessonService courseLessonService)
        {
            _courseLessonService = courseLessonService;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("/SignIn");
            }
            return Page();
        }

        [BindProperty]
        public CourseLessonModel NewLesson { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                NewLesson.CreatedTime = DateTimeOffset.Now;
                NewLesson.LastUpdated = DateTimeOffset.Now;

                var result = await _courseLessonService.Add(NewLesson);

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
