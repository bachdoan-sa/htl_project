using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.CourseModule
{
    public class CreateModel : PageModel
    {
        private readonly ICourseModuleService _courseModuleService;

        public CreateModel(ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
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
        public CourseModuleModel NewModule { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                NewModule.CreatedTime = DateTimeOffset.Now;
                NewModule.LastUpdated = DateTimeOffset.Now;

                var result = await _courseModuleService.Add(NewModule);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return Redirect("/Admin/CourseModule/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create course module.");
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