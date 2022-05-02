using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace LimsUI.Pages.ElisaPages
{
    public class SendRawDataModel : PageModel
    {

        [BindProperty]
        public IFormFile SelectedFile { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Stream stream = SelectedFile.OpenReadStream();
            StreamReader reader = new StreamReader(stream);

            List<string> results = new List<string>();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                results.Add(line);
            }

            results.RemoveRange(0, 1);

            string standardsData = "[";

            foreach (var result in results)
            {
                string[] splitString = result.Split(";");
                int pos = int.Parse(splitString[0]);
                float conc = float.Parse(splitString[1]);
                float measValue = float.Parse(splitString[2]);
                standardsData += $"{{\"pos\":{pos},\"concentration\":{SetPointSeparator(conc)},\"measValue\":{SetPointSeparator(measValue)}}},";
            }

            standardsData = standardsData.Trim(',');

            standardsData += "]";
        }

        private static string SetPointSeparator(float number)
        {
            return number.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
        }
    }
}
