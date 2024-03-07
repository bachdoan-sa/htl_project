using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Repository.Model;
using Repository.Services;
using Repository.Services.IServices;

namespace WebHTL.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IRoadmapService _roadmapService;
        private readonly ISectionService _sectionService;
        public ProductsModel(IRoadmapService roadmapService, ISectionService sectionService)
        {
            _roadmapService = roadmapService;
            _sectionService= sectionService;
        }

        public List<RoadmapModel> Roadmaps { get; set; }
        public List<SectionModel> Sections { get; set; }

        public async Task OnGetAsync()
        {
             Roadmaps = await _roadmapService.GetAllRoadmaps();

                
            
        }
    }
}
