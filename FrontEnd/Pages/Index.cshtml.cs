using ForjaDosAneisFrontend.Models;
using ForjaDosAneisFrontend.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForjaDosAneisFrontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAnelService _anelService;

        public List<Anel> Aneis { get; set; } = new List<Anel>();  // Inicializando a lista

        public IndexModel(IAnelService anelService)
        {
            _anelService = anelService;
        }

        public async Task OnGetAsync()
        {
            Aneis = await _anelService.GetAnéisAsync();
        }
    }
}
