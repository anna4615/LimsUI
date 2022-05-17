using LimsUI.Gateways.GatewayInterfaces;
using LimsUI.Models.ProcessModels;
using LimsUI.Models.ProcessModels.Variables;
using LimsUI.Models.UIModels;
using LimsUI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


namespace LimsUI.Pages.ElisaPages
{
    public class SendRawDataModel : PageModel
    {
        private readonly IProcessGateway _processGateway;

        public SendRawDataModel(IProcessGateway processGateway)
        {
            _processGateway = processGateway;
        }

        public Elisa Elisa { get; set; }

        public List<StandardData> StandardDatas { get; set; }

        [BindProperty]
        public IFormFile SelectedFile { get; set; }

        public List<string> ResultLines { get; set; }




        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            ReadSelectedFileToResultLines();
            SendRawDataBody sendRawDataBody = MakeSendRawDataBody();
            SendRawDataReturnValues sendRawDataReturnValues = await _processGateway.SendRawData(sendRawDataBody);
            //SendRawDataReturnValues sendRawDataReturnValues = TestData.MakeSendRawDataReturnValuesExample();

            HttpContext.Session.SetSendRawDataReturnValues("SendRawDataReturnValues", sendRawDataReturnValues);


            Elisa = JsonSerializer.Deserialize<Elisa>(sendRawDataReturnValues.variables.elisa.value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
           
            return Redirect($"./ReviewResult/");
        }



        private void ReadSelectedFileToResultLines()
        {
            Stream stream = SelectedFile.OpenReadStream();
            StreamReader reader = new StreamReader(stream);

            ResultLines = new List<string>();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                ResultLines.Add(line);
            }
        }

        private SendRawDataBody MakeSendRawDataBody()
        {
            int elisaIdValue = SetElisaIdValue();
            string samplesDataValue = SetSamplesDataValue();
            string standardsDataValue = SetStandardsDataValue();

            SendRawDataBody sendRawDataBody = new SendRawDataBody
            {
                messageName = "receiveData",
                correlationKeys = new SendRawDataBodyCorrelationkeys
                {
                    elisaId = new ElisaId
                    {
                        type = "Integer",
                        value = elisaIdValue
                    }
                },
                processVariables = new SendRawDataBodyProcessvariables
                {
                    samplesData = new Samplesdata
                    {
                        type = "String",
                        value = samplesDataValue
                    },
                    standardsData = new Standardsdata
                    {
                        type = "String",
                        value = standardsDataValue
                    }
                },
                resultEnabled = true,
                variablesInResultEnabled = true
            };

            return sendRawDataBody;
        }

        private int SetElisaIdValue()
        {
            int elisaId = int.Parse(ResultLines[1]);

            return elisaId;
        }

        private string SetSamplesDataValue()
        {
            string samplesDataValue = "[";

            foreach (var line in ResultLines)
            {
                string[] values = line.Split(";");

                //splitString.Length > 1 -> tar inte med inledande rader som innehåller elisaId, se wwwroot/result_exemple.csv
                //TryParse -> hoppa över rubikrader
                if (values.Length > 1 &&
                    int.TryParse(values[0], out int pos))
                {
                    //pos > 72 -> samples har position 1-72 
                    if (pos > 72)
                    {
                        break;
                    }

                    int sampleId = int.Parse(values[1]);
                    string name = values[2];
                    float measValue = float.Parse(values[3]);
                    samplesDataValue += $"{{\"pos\":{pos},\"sampleId\":{sampleId},\"name\":\"{name}\",\"measValue\":{SetPointSeparator(measValue)}}},";

                }
            }

            samplesDataValue = samplesDataValue.Trim(',');
            samplesDataValue += "]";

            return samplesDataValue;
        }

        private string SetStandardsDataValue()
        {
            string standardsDataValue = "[";

            foreach (var line in ResultLines)
            {
                string[] values = line.Split(";");

                //values.Length > 1 -> tar inte med inledande rader som innehåller elisaId, se wwwroot/result_exemple.csv
                //TryParse -> hoppa över rubikrader
                //pos > 72 -> standards har position 73-96 
                if (values.Length > 1 &&
                    int.TryParse(values[0], out int pos) &&
                    pos > 72)
                {
                    float conc = float.Parse(values[1]);
                    float measValue = float.Parse(values[2]);
                    standardsDataValue += $"{{\"pos\":{pos},\"concentration\":{SetPointSeparator(conc)},\"measValue\":{SetPointSeparator(measValue)}}},";
                }
            }

            standardsDataValue = standardsDataValue.Trim(',');
            standardsDataValue += "]";

            return standardsDataValue;
        }

        private string SetPointSeparator(float number)
        {
            return number.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
        }
    }
}
