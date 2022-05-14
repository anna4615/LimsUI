using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LimsUI.Models.ProcessModels;
using LimsUI.Models.ProcessModels.Variables;
using LimsUI.Models.UIModels;
using LimsUI.Gateways.GatewayInterfaces;
using System.Threading.Tasks;
using LimsUI.Utilities;
using System.Text.Json;

namespace LimsUI.Pages.ElisaPages
{
    public class ReviewResultModel : PageModel
    {
        private readonly IProcessGateway _processGateway;
        private readonly ISampleGateway _sampleGateway;

        public ReviewResultModel(IProcessGateway processGateway, ISampleGateway sampleGateway)
        {
            _processGateway = processGateway;
            _sampleGateway = sampleGateway;
        }

        [BindProperty(SupportsGet = true)]
        public int ElisaId { get; set; }

        public Elisa Elisa { get; set; }

        [BindProperty]
        public Elisa ReviewedResult { get; set; }

        public List<StandardData> StandardDatas { get; set; }

        public List<Elisa> Elisas { get; set; }

        public List<int> ElisaIds { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Elisa = HttpContext.Session.GetElisaFromSendRawDataReturnValues("SendRawDataReturnValues");
            StandardDatas = HttpContext.Session.GetStandardDataFromSendRawDataReturnValues("SendRawDataReturnValues");

            if (Elisa == null)
            {
                ElisaIds = await _sampleGateway.GetElisaIdsForStatus("In Review");
                HttpContext.Session.SetElisaIds("Elisas", ElisaIds);
                Elisa = await _processGateway.GetResultForElisaId(84);
            }



            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            ResultReviewedBody resultReviewedBody = MakeResultReviewedBody();
            ResultReviewedReturnValues resultReviewedReturnValues = await _processGateway.SendResultReviewed(resultReviewedBody);

            int elisaId = resultReviewedReturnValues.variables.elisaId.value;

            return Redirect($"/ElisaResult/?elisaId={elisaId}");

        }



        public ResultReviewedBody MakeResultReviewedBody()
        {
            ResultReviewedBody body = new ResultReviewedBody
            {
                messageName = "resultReviewed",
                correlationKeys = new ResultReviewedBodyCorrelationkeys
                {
                    elisaId = new ElisaId
                    {
                        type = "Integer",
                        value = ReviewedResult.Id
                    }
                },
                processVariables = new ResultReviewedBodyProcessvariables
                {
                    experimentOk = new ExperimentOk
                    {
                        type = "Boolean",
                        value = ReviewedResult.Approved
                    },
                    redo = new Redo
                    {
                        type = "Boolean",
                        value = ReviewedResult.Redo
                    }
                },
                resultEnabled = true,
                variablesInResultEnabled = true
            };

            return body;
        }
    }
}
