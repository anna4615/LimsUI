using LimsUI.Gateways.GatewayInterfaces;
using LimsUI.Models.UIModels;
using LimsUI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LimsUI.Pages.ElisaPages
{
    public class ElisaResultModel : PageModel
    {

        private readonly ISampleGateway _sampleGateway;
        private readonly IProcessGateway _processGateway;

        public ElisaResultModel(ISampleGateway sampleGateway, IProcessGateway processGateway)
        {
            _sampleGateway = sampleGateway;
            _processGateway = processGateway;
        }

        [BindProperty(SupportsGet = true)]
        public int ElisaId { get; set; }

        public Elisa ElisaResult { get; set; }



        public IActionResult OnGet()
        {

            ElisaResult = HttpContext.Session.GetElisaResultReviewedReturnValues("ResultReviewedReturnValues");

            return Page();
        }
    }
}
