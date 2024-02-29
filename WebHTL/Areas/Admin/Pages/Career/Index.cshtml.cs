using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Career
{
    public class IndexModel : PageModel
    {
        private readonly ICareerService _careerService;

        public IndexModel(ICareerService careerService)
        {
            _careerService = careerService;
        }

        public List<CareerModel> Careers { get; set; }

        public async Task OnGetAsync()
        {
            Careers = await _careerService.GetAll();
        }
    }
}
