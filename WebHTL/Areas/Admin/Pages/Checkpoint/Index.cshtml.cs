using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Model;
using Repository.Services.IServices;

namespace WebHTL.Pages.Areas.Admin.Checkpoint
{
    public class IndexModel : PageModel
    {
        private readonly ICheckpointService _checkpointService;

        public IndexModel(ICheckpointService checkpointService)
        {
            _checkpointService = checkpointService;
        }

        public List<CheckpointModel> Checkpoints { get; set; }

        public async Task OnGetAsync()
        {
            Checkpoints = await _checkpointService.GetAll();
        }
    }
}