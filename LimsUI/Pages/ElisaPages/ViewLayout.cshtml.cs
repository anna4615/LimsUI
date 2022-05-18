using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LimsUI.Gateways.GatewayInterfaces;
using System.Threading.Tasks;
using LimsUI.Models.UIModels;
using System.Collections.Generic;
using LimsUI.Models.ProcessModels;
using System.Linq;

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

        public List<int> ElisaIds { get; set; }


        public async Task<IActionResult> OnGet()
        {
            if (ElisaId != 0)
            {
                Layout = await _processGateway.GetLayoutForElisaId(ElisaId);
            }

            List<ProcessInstance> processes = await _processGateway.GetProcesses();

            ElisaIds = new List<int>();

            foreach (var process in processes)
            {
                ElisaIds.Add(int.Parse(process.businessKey));
            }

            ElisaIds.Sort();

            return Page();
        }
    }
}
