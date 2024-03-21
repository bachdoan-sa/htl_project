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

        public IActionResult OnGet(string id)
        {
            var userId = GetUser(); var admin = GetAdmin();
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(admin))
            {
                return Redirect("/SignIn");
            }
            if (admin != null)
            {
                return Redirect("/Admin/Index");
            }
            //code here
            Roadmap = _roadmapService.GetRoadmapById(id).Result;
                Section = _sectionService.GetSectionsByRoadmapId(id).Result;
                return Page();
            
        }
        #region private method get user and admin
        private string? GetUser()
        {
            string? id = HttpContext.Session.GetString("customerId");
            if (!string.IsNullOrEmpty(id))
            {
                return id;
            }
            return null;
        }
        private string? GetAdmin()
        {
            string? id = HttpContext.Session.GetString("Admin");
            if (!string.IsNullOrEmpty(id))
            {
                return id;
            }
            return null;
        }
        #endregion
    }
}
