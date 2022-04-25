﻿using LimsUI.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LimsUI.REST
{
    public class Request : IRequest
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public Request(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<ProcessVariables> StartElisa(StartElisaBody body)
        {
            HttpResponseMessage respons = await _client.PostAsJsonAsync(_configuration["StartElisa"], body);
            ProcessVariables returnValue = await respons.Content.ReadFromJsonAsync<ProcessVariables>();

            return returnValue;
        }
    }
}
