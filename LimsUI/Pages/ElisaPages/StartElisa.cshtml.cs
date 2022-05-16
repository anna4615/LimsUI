using LimsUI.Gateways.GatewayInterfaces;
using LimsUI.Models.ProcessModels;
using LimsUI.Models.ProcessModels.Variables;
using LimsUI.Models.UIModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LimsUI.Pages.ElisaPages
{
    public class StartElisaModel : PageModel
    {
        private readonly ILogger<StartElisaModel> _logger;
        private readonly ISampleGateway _sampleGateway;
        private readonly IProcessGateway _processGateway;

        public StartElisaModel(ILogger<StartElisaModel> logger, ISampleGateway sampleGateway,
            IProcessGateway processGateway)
        {
            _logger = logger;
            _sampleGateway = sampleGateway;
            _processGateway = processGateway;
        }


        public List<Sample> Samples { get; set; }

        [BindProperty]
        public List<int> SelectedIds { get; set; }

        public List<Sample> SelectedSamples { get; set; }

        public int? ElisaId { get; set; }

        public Layout Layout { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Samples = await _sampleGateway.GetSamples();
            //TODO: Spara Samples i cookie

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            //TODO: Felhantering om inga prover är valda
            //TODO: Hämta Samples från cookie
            Samples = await _sampleGateway.GetSamples();

            if (SelectedIds.Any())
            {
                //Samples = await _sampleGateway.GetSamples();

                MakeSelectedSamplesList();
                StartElisaBody body = MakeStartElisaBody();

                StartElisaReturnValues response = await _processGateway.StartElisa(body);

                ElisaId = response.variables.elisaId.value;

                Layout = JsonSerializer.Deserialize<Layout>(response.variables.plate.value.ToString(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }


            return Page();
        }



        private void MakeSelectedSamplesList()
        {
            SelectedSamples = new List<Sample>();

            foreach (var sample in Samples)
            {
                if (SelectedIds.Contains(sample.Id))
                {
                    SelectedSamples.Add(sample);
                }
            }
        }

        private StartElisaBody MakeStartElisaBody()
        {
            StartElisaBody body = new StartElisaBody
            {
                variables = new StartElisaVariables
                {
                    samples = new Samples
                    {
                        type = "String",
                        value = MakeSamplesValue()
                    }
                },
                withVariablesInReturn = true
            };

            return body;
        }


        private string MakeSamplesValue()
        {
            string sampleValue = "";

            foreach (var sample in SelectedSamples)
            {
                //https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting#escaping-braces
                sampleValue += $"{{\"id\":{sample.Id},\"name\":\"{sample.Name}\"}};";
            }

            return sampleValue.Trim(';');
        }
    }
}
