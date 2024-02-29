using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin
{
    public class RoadMapManagerModel : PageModel
    {
        private readonly IRoadmapService _roadmapService;

      //  public List<Roadmap> Roadmaps { get; set; }

        public RoadMapManagerModel(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }

        public async Task OnGetAsync()
        {
     //       Roadmaps = await _roadmapService.GetAllRoadmapsAsync();
        }
    }
}
