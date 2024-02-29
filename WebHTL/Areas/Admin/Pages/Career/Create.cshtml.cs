using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Career
{
    public class CreateModel : PageModel
    {
        private readonly ICareerService _careerService;

        public CreateModel(ICareerService careerService)
        {
            _careerService = careerService;
        }

        [BindProperty]
        public CareerModel NewCareer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                NewCareer.CreatedTime = DateTimeOffset.Now;
                NewCareer.LastUpdated = DateTimeOffset.Now;

                var result = await _careerService.Add(NewCareer);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return Redirect("/Admin/Career/Index"); 
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create career.");
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
