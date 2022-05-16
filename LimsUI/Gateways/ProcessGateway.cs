using LimsUI.Gateways.GatewayInterfaces;
using LimsUI.Models.UIModels;
using LimsUI.Models.ProcessModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace LimsUI.Gateways
{
    public class ProcessGateway : IProcessGateway
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _caseInsensitive;

        public ProcessGateway(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
            _caseInsensitive = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public async Task<StartElisaReturnValues> StartElisa(StartElisaBody body)
        {
            HttpResponseMessage respons = await _client.PostAsJsonAsync(_configuration["StartElisa"], body);
            StartElisaReturnValues returnValue = await respons.Content.ReadFromJsonAsync<StartElisaReturnValues>();

            return returnValue;
        }


        //Använder bisunessKey i anrop för att ta fram processens id som används i anrop där processvariabeln "plate" hämtas,
        //plate innehåller en lista av Well som används för att skapa lista av Well i Layout 
        public async Task<Layout> GetLayoutForElisaId(int elisaId)
        {
        
            string instanceId = await GetProcessInstanceId(elisaId);
            string variable = await GetVariable(instanceId, "plate");
            GetPlateVariableReturnValues plateVariable = JsonSerializer.Deserialize<GetPlateVariableReturnValues>(variable, _caseInsensitive);

            //plateVariable.value är ett objekt som inte direkt kan göras till en UIModels.Layout.
            //Serializerar value till sträng som sedan deserialiseras till UIModels.Layout.
            string plateVariableString = JsonSerializer.Serialize(plateVariable.value);
            Layout layout = JsonSerializer.Deserialize<Layout>(plateVariableString, _caseInsensitive);

            return layout;
        }


        public async Task<SendRawDataReturnValues> SendRawData(SendRawDataBody body)
        {
            HttpResponseMessage respons = await _client.PostAsJsonAsync(_configuration["SendMessage"], body);
            //SendRawDataReturnValues returnValue = await respons.Content.ReadFromJsonAsync<SendRawDataReturnValues>();
            string responseString = await respons.Content.ReadAsStringAsync();
            string trimmedResponse = responseString.Trim('[').Trim(']');

            SendRawDataReturnValues returnValue = JsonSerializer.Deserialize<SendRawDataReturnValues>(trimmedResponse, _caseInsensitive);

            return returnValue;
        }


        public async Task<Elisa> GetResultForElisaId(int elisaId)
        {
            string instanceId = await GetProcessInstanceId(elisaId);
            string variable = await GetVariable(instanceId, "elisa");
            GetElisaVariableReturnValues elisaVariable = JsonSerializer.Deserialize<GetElisaVariableReturnValues>(variable, _caseInsensitive);

            //elisaVariable.value är ett objekt som inte direkt kan göras till en UIModels.Elisa.
            //Serializerar value till sträng som sedan deserialiseras till UIModels.Elisa.
            string elisaVariableString = JsonSerializer.Serialize(elisaVariable.value);
            Elisa elisa = JsonSerializer.Deserialize<Elisa>(elisaVariableString, _caseInsensitive);

            return elisa;
        }

        public async Task<List<StandardData>> GetStandardDatasForElisaId(int elisaId)
        {
            string instanceId = await GetProcessInstanceId(elisaId);
            string variable = await GetVariable(instanceId, "standardsData");
            var stdsVariable = JsonSerializer.Deserialize<Models.ProcessModels.Variables.Standardsdata>(variable, _caseInsensitive);

            //stdsVariable.value är en sträng som kan deserialiseras direkt till List<UIModels.StandardData>
            List<StandardData> standardDatas = JsonSerializer.Deserialize<List<StandardData>>(stdsVariable.value, _caseInsensitive);

            return standardDatas;
        }

        public async Task<ResultReviewedReturnValues> SendResultReviewed(ResultReviewedBody body)
        {
            HttpResponseMessage respons = await _client.PostAsJsonAsync(_configuration["SendMessage"], body);
            //SendRawDataReturnValues returnValue = await respons.Content.ReadFromJsonAsync<SendRawDataReturnValues>();
            string responseString = await respons.Content.ReadAsStringAsync();
            string trimmedResponse = responseString.Trim('[').Trim(']');

            ResultReviewedReturnValues returnValue = JsonSerializer.Deserialize<ResultReviewedReturnValues>(trimmedResponse, _caseInsensitive);

            return returnValue;
        }





        private async Task<string> GetProcessInstanceId(int elisaId)
        {
            //Hämta rätt process mhja BusinessKey, BusinessKey = ElisaId
            HttpResponseMessage respons = await _client.GetAsync(_configuration["GetProcessInstanceFromBusinessKey"] + elisaId);
            string responseString = await respons.Content.ReadAsStringAsync();
            string trimmedResponse = responseString.Trim('[').Trim(']');

            ProcessInstance processInstance = JsonSerializer.Deserialize<ProcessInstance>(trimmedResponse, _caseInsensitive);
            return processInstance.id;
        }



        private async Task<string> GetVariable(string instanceId, string variableName)
        {
            HttpResponseMessage response = await _client.GetAsync(
                _configuration["GetProcessInstanceFromInstanceId"] + instanceId + "/variables/" + variableName);

            string responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }



    }
}
