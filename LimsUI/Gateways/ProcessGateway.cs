﻿using LimsUI.Gateways.GatewayInterfaces;
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

        public ProcessGateway(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
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

            GetPlateVariableReturnValues plateVariable = await GetPlateVariable(instanceId);

            //Skapar layout från properties i plateVariable
            //Well i plateVariable konverteras till Well som anvämds i klassen Layout
            Layout layout = new Layout
            {
                ElisaId = plateVariable.value.elisaId,
                Wells = ConvertVariableWellsToLayoutWells(plateVariable.value.wells)
            };

            return layout;
        }


        public async Task<SendRawDataReturnValues> SendRawData(SendRawDataBody body)
        {
            HttpResponseMessage respons = await _client.PostAsJsonAsync(_configuration["SendMessage"], body);
            //SendRawDataReturnValues returnValue = await respons.Content.ReadFromJsonAsync<SendRawDataReturnValues>();
            string responseString = await respons.Content.ReadAsStringAsync();
            string trimmedResponse = responseString.Trim('[').Trim(']');

            SendRawDataReturnValues returnValue = JsonSerializer.Deserialize<SendRawDataReturnValues>(trimmedResponse);

            return returnValue;
        }


        private async Task<string> GetProcessInstanceId(int elisaId)
        {
            //Hämta rätt process mhja BusinessKey, BusinessKey = ElisaId
            HttpResponseMessage respons = await _client.GetAsync(_configuration["GetProcessInstanceFromBusinessKey"] + elisaId);
            string responseString = await respons.Content.ReadAsStringAsync();
            string trimmedResponse = responseString.Trim('[').Trim(']');

            ProcessInstance processInstance = JsonSerializer.Deserialize<ProcessInstance>(trimmedResponse);
            return processInstance.id;
        }

        private async Task<GetPlateVariableReturnValues> GetPlateVariable(string instanceId)
        {
            HttpResponseMessage response = await _client.GetAsync(
                _configuration["GetProcessInstanceFromInstanceId"] + instanceId + "/variables/plate");

            string responseString = await response.Content.ReadAsStringAsync();
            GetPlateVariableReturnValues plateVariable = JsonSerializer.Deserialize<GetPlateVariableReturnValues>(responseString);

            return plateVariable;
        }


        private static List<Models.UIModels.Well> ConvertVariableWellsToLayoutWells(Models.ProcessModels.Well[] wells)
        {
            List<Models.UIModels.Well> wellsList = new List<Models.UIModels.Well>();

            for (int i = 0; i < wells.Length; i++)
            {
                wellsList.Add(new Models.UIModels.Well
                {
                    Position = wells[i].pos,
                    WellName = wells[i].wellName,
                    Reagent = wells[i].reagent,
                });
            }

            return wellsList.OrderBy(w => w.Position).ToList();
        }

        public async Task<ResultReviewedReturnValues> SendResultReviewed(ResultReviewedBody body)
        {
            HttpResponseMessage respons = await _client.PostAsJsonAsync(_configuration["SendMessage"], body);
            //SendRawDataReturnValues returnValue = await respons.Content.ReadFromJsonAsync<SendRawDataReturnValues>();
            string responseString = await respons.Content.ReadAsStringAsync();
            string trimmedResponse = responseString.Trim('[').Trim(']');

            ResultReviewedReturnValues returnValue = JsonSerializer.Deserialize<ResultReviewedReturnValues>(trimmedResponse);

            return returnValue;
        }
    }
}
