using LimsUI.GraphQL.Interfaces;
using LimsUI.GraphQL.SampleClasses;
using LimsUI.Models;
using LimsUI.REST;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimsUI.Pages
{
    public class StartElisaModel : PageModel
    {
        private readonly ILogger<StartElisaModel> _logger;
        private readonly ISampleConsumer _sampleConsumer;
        private readonly IRequest _request;

        public StartElisaModel(ILogger<StartElisaModel> logger, ISampleConsumer sampleConsumer,
            IRequest request)
        {
            _logger = logger;
            _sampleConsumer = sampleConsumer;
            _request = request;
        }

        
        public List<Sample> Samples { get; set; }

        [BindProperty]
        public List<int> SelectedIds { get; set; }

        public List<Sample> SelectedSamples { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Samples = await _sampleConsumer.GetSamples();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Samples = await _sampleConsumer.GetSamples();

            SelectedSamples = new List<Sample>();

            foreach (var sample in Samples)
            {
                if (SelectedIds.Contains(sample.Id))
                {
                    SelectedSamples.Add(sample);
                }
            }

            StartElisaBody body = new StartElisaBody
            {
                variables = new Variables
                {
                    samples = new Samples
                    {
                        type = "String",
                        value = "{\"id\":3,\"name\":\"Prov3\"};{\"id\":4,\"name\":\"Prov4\"}"
                    }
                },
                withVariablesInReturn = true
            };

            await _request.StartElisa(body);

            return Page();
        }
    }
}
