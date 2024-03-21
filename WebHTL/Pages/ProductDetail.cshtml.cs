using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly IRoadmapService _roadmapService;

        public GetRoadmapDetailResDto Roadmap { get; set; }
        [BindProperty]
        public int TotalModules { get; set; }

        public ProductDetailModel(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }

        public async Task OnGet(string id)
        {
            Roadmap = await _roadmapService.GetRoadmapDetailResByIdAsync(id);
            TotalModules = Roadmap.ListCourse.Sum(course => course.CourseModules); 
        }
    }
}
