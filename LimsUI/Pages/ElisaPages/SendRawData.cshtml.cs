using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LimsUI.Models.ProcessModels.SendRawData;

namespace LimsUI.Pages.ElisaPages
{
    public class SendRawDataModel : PageModel
    {

        [BindProperty]
        public IFormFile SelectedFile { get; set; }

        public List<string> Results { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            ReadSelectedFileToResults();

            SendRawDataBody sendRawDataBody = MakeSendRawDataBody();

        }


        private void ReadSelectedFileToResults()
        {
            Stream stream = SelectedFile.OpenReadStream();
            StreamReader reader = new StreamReader(stream);

            Results = new List<string>();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                Results.Add(line);
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
                correlationKeys = new Correlationkeys
                {
                    elisaId = new Elisaid
                    {
                        type = "Integer",
                        value = elisaIdValue
                    }
                },
                processVariables = new Processvariables
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
            int elisaId = int.Parse(Results[1]);

            return elisaId;
        }

        private string SetStandardsDataValue()
        {
            string standardsDataValue = "[";

            foreach (var result in Results)
            {
                string[] splitString = result.Split(";");

                //splitString.Length > 1 -> tar inte med inledande rader som innehåller elisaId
                //TryParse -> hoppa över rubikrader
                //pos > 72 -> standards har position 73-96 
                if (splitString.Length > 1 && 
                    int.TryParse(splitString[0], out int pos) &&  
                    pos > 72)
                {
                    float conc = float.Parse(splitString[1]);
                    float measValue = float.Parse(splitString[2]);
                    standardsDataValue += $"{{\\\"pos\\\":{pos},\\\"concentration\\\":{SetPointSeparator(conc)},\\\"measValue\\\":{SetPointSeparator(measValue)}}},";
                }
            }

            standardsDataValue = standardsDataValue.Trim(',');
            standardsDataValue += "]";

            return standardsDataValue;
        }


        private string SetSamplesDataValue()
        {
            string samplesDataValue = "[";

            foreach (var result in Results)
            {
                string[] splitString = result.Split(";");

                //splitString.Length > 1 -> tar inte med inledande rader som innehåller elisaId
                //TryParse -> hoppa över rubikrader
                if (splitString.Length > 1 &&
                    int.TryParse(splitString[0], out int pos))
                {
                    //pos > 72 -> samples har position 1-72 
                    if (pos > 72)
                    {
                        break;
                    }

                    int sampleId = int.Parse(splitString[1]);
                    string name = splitString[2];
                    float measValue = float.Parse(splitString[3]);
                    samplesDataValue += $"{{\\\"pos\\\":{pos},\\\"sampleId\\\":{sampleId},\\\"name\\\":\\\"{name}\\\",\\\"measValue\\\":{SetPointSeparator(measValue)}}},";
                    
                }
            }

            samplesDataValue = samplesDataValue.Trim(',');
            samplesDataValue += "]";

            return samplesDataValue;
        }       


        private string SetPointSeparator(float number)
        {
            return number.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
        }
    }
}
