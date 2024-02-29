using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Driver
{
    public class CreateModel : PageModel
    {
        private readonly IDriverService _driverService;

        public CreateModel(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [BindProperty]
        public DriverModel NewDriver { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                NewDriver.CreatedTime = DateTimeOffset.Now;
                NewDriver.LastUpdated = DateTimeOffset.Now;

                var result = await _driverService.Add(NewDriver);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return RedirectToPage("/Admin/Driver/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create driver.");
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
