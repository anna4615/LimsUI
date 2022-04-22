using LimsUI.GraphQL.Interfaces;
using LimsUI.GraphQL.SampleClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimsUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISampleConsumer _sampleConsumer;

        public IndexModel(ILogger<IndexModel> logger, ISampleConsumer sampleConsumer)
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
