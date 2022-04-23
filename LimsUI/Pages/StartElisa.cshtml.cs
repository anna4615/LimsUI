using LimsUI.GraphQL.Interfaces;
using LimsUI.GraphQL.SampleClasses;
using LimsUI.Models;
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

        public StartElisaModel(ILogger<StartElisaModel> logger, ISampleConsumer sampleConsumer)
        {
            _logger = logger;
            _sampleConsumer = sampleConsumer;
        }

        public List<Sample> Samples { get; set; }

        public async Task<IActionResult> OnGet()
        
        {
            Samples = await _sampleConsumer.GetSamples();

            return Page();
        }
    }
}
