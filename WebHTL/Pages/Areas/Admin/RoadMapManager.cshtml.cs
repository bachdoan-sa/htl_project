using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin
{
    public class RoadMapManagerModel : PageModel
    {
        private readonly IRoadmapService _roadmapService;

        public List<Roadmap> Roadmaps { get; set; } = default!;

        public RoadMapManagerModel(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("./SignIn");
            }
            Roadmaps = await _roadmapService.GetAllRoadmapsAsync();
            return Page();
        }
    }
}
