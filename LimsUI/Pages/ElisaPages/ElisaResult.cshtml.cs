using LimsUI.Gateways.GatewayInterfaces;
using LimsUI.Models.UIModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LimsUI.Pages.ElisaPages
{
    public class ElisaResultModel : PageModel
    {

        private readonly ISampleGateway _sampleGateway;

        public ElisaResultModel(ISampleGateway sampleGateway)
        {
            _sampleGateway = sampleGateway;
        }

        [BindProperty(SupportsGet = true)]
        public int ElisaId { get; set; }

        public Elisa ElisaResult { get; set; }



        public async Task<IActionResult> OnGet()
        {
            ElisaResult = await _sampleGateway.GetResultForElisa(ElisaId);

            return Page();
        }
    }
}
