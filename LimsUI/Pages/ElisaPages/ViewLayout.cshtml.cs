using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LimsUI.Gateways.GatewayInterfaces;
using System.Threading.Tasks;
using LimsUI.Models.UIModels;

namespace LimsUI.Pages.ElisaPages
{
    public class ViewLayoutModel : PageModel
    {
        private IProcessGateway _processGateway;

        public ViewLayoutModel(IProcessGateway processGateway)
        {
            _processGateway = processGateway;
        }


        [BindProperty(SupportsGet = true)]
        public int ElisaId { get; set; }

        public Layout Layout { get; set; }


        public async Task<IActionResult> OnGet()
        {            
            Layout = await _processGateway.GetLayoutForElisaId(ElisaId);

            return Page();
        }
    }
}
