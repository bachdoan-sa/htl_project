using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Profile
{
    public class ProfileRoadMapModel : PageModel
    {
        private readonly IRoadmapService _roadmapService;

        public GetRoadmapDetailResDto Roadmap { get; set; }

        public ProfileRoadMapModel(IRoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }

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
                
                return Page();
            }
        }




    }
}
