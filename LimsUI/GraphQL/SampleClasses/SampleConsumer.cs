using GraphQL;
using GraphQL.Client.Abstractions;
using LimsUI.GraphQL.Interfaces;
using LimsUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimsUI.GraphQL.SampleClasses
{
    public class SampleConsumer : ISampleConsumer
    {
        private readonly IGraphQLClient _client;

        public SampleConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<Sample>> GetSamples()
        {

            GraphQLRequest query = new GraphQLRequest
            {
                Query = @"query {
	                        samples{
		                        id
		                        name
		                        concentration
		                        dateAdded
	                        }
                        }"
            };

            //ResponseSampleList är eän klass som bara har en property: List<Sample> Samples,
            //den behövs för att deserialiseringen skall funka (prog kraschar om man sätter listan
            //istället för ResponseSampleList
            GraphQLResponse<ResponseSampleList> response = await _client.SendQueryAsync<ResponseSampleList>(query);

            List<Sample> samples = response.Data.Samples;

            return samples;

        }
    }
}
