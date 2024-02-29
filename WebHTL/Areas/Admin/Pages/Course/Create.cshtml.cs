using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Course
{
    public class CreateModel : PageModel
    {
        private readonly ICourseService _courseService;

        public CreateModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public CourseModel NewCourse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                NewCourse.CreatedTime = DateTimeOffset.Now;
                NewCourse.LastUpdated = DateTimeOffset.Now;

                var result = await _courseService.Add(NewCourse);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return Redirect("/Admin/Course/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create course.");
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
