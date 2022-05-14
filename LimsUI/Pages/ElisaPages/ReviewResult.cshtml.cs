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

        public ReviewResultModel(IProcessGateway processGateway)
        {
            _processGateway = processGateway;
        }

        [BindProperty(SupportsGet = true)]
        public int ElisaId { get; set; }

        public Elisa Elisa { get; set; }

        [BindProperty]
        public Elisa ReviewedResult { get; set; }

        //[BindProperty]
        //public bool ResultReviewed { get; set; }

        public List<StandardData> StandardDatas { get; set; }


        public void OnGet()
        {
            Elisa = HttpContext.Session.GetElisaFromCookie("SendRawDataReturnValues");
            StandardDatas = HttpContext.Session.GetStandardDataFromCookie("SendRawDataReturnValues");
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
