using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
    public class ProfileRoadMapModel : PageModel
    {
        private readonly ISectionService _sectionService;
        private readonly IRoadmapService _roadmapService;
        public ProfileRoadMapModel(ISectionService sectionService, IRoadmapService roadmapService)
        {
            _sectionService = sectionService;
            _roadmapService = roadmapService;
            
        }

        public List<SectionModel> Section { get; set; } = new List<SectionModel>();
        public RoadmapModel Roadmap { get; set; }

        //public IActionResult OnGet()
        //{
        //    var userId = HttpContext.Session.GetString("customerId");

        //    if (userId == null)
        //    {
        //        return RedirectToPage("/SignIn");
        //    }
        //    return Page();
        //}

        public IActionResult OnGet(string id)
        {
            var userId = 1;

            if (userId == null)
            {
                return RedirectToPage("/SignIn");
            }
            else
            {
                Roadmap = _roadmapService.GetRoadmapById(id).Result;
                Section = _sectionService.GetSectionsByRoadmapId(id).Result;
                return Page();
            }
        }




    }
}
