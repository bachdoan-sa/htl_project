using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Roadmap
{
    public class IndexModel : PageModel
    {
        private readonly IRoadmapService _roadmapService;

        public IndexModel(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }

        public List<RoadmapModel> Roadmaps { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                RedirectToPage("/SignIn");
            }
            Roadmaps = await _roadmapService.GetAllRoadmaps();
        }
    }
}
