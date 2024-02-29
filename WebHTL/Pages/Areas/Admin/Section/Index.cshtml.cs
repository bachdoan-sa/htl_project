using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Section
{
    public class IndexModel : PageModel
    {
        private readonly ISectionService _sectionService;

        public IndexModel(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public List<SectionModel> Sections { get; set; }

        public async Task OnGetAsync()
        {
            Sections = await _sectionService.GetAll();
        }
    }
}
