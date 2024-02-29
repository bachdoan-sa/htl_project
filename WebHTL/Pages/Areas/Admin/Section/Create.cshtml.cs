using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Section
{
    public class CreateModel : PageModel
    {
        private readonly ISectionService _sectionService;

        public CreateModel(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [BindProperty]
        public SectionModel NewSection { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                NewSection.CreatedTime = DateTimeOffset.Now;
                NewSection.LastUpdated = DateTimeOffset.Now;

                var result = await _sectionService.Add(NewSection);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return RedirectToPage("/Admin/Section/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create section.");
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