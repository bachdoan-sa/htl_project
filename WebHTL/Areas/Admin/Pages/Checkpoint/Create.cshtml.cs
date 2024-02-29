using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Checkpoint
{
    public class CreateModel : PageModel
    {
        private readonly ICheckpointService _checkpointService;

        public CreateModel(ICheckpointService checkpointService)
        {
            _checkpointService = checkpointService;
        }

        [BindProperty]
        public CheckpointModel NewCheckpoint { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Set created and last updated times
                NewCheckpoint.CreatedTime = DateTimeOffset.Now;
                NewCheckpoint.LastUpdated = DateTimeOffset.Now;

                var result = await _checkpointService.Add(NewCheckpoint);

                if (result != null)
                {
                    // Redirect to a success page or another page as needed
                    return Redirect("/Admin/Checkpoint/Index");
                }
                else
                {
                    // Handle error case
                    ModelState.AddModelError(string.Empty, "Failed to create checkpoint.");
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
