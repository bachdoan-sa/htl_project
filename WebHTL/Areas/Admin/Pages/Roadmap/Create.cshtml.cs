using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Roadmap
{
    public class CreateModel : PageModel
    {
        private readonly IRoadmapService _roadmapService;

        public CreateModel(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
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
        public RoadmapModel NewRoadmap { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                NewRoadmap.CreatedTime = DateTimeOffset.Now;
                NewRoadmap.LastUpdated = DateTimeOffset.Now;

                var result = await _roadmapService.AddRoadmap(NewRoadmap);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return Redirect("/Admin/Roadmap/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create roadmap.");
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