using GraphQL;
using GraphQL.Client.Abstractions;
using LimsUI.Gateways.GatewayInterfaces;
using LimsUI.Models.UIModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimsUI.Gateways
{
    public class SampleGateway : ISampleGateway
    {
        private readonly IGraphQLClient _client;

        public SampleGateway(IGraphQLClient client)
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

            //ResponseSampleList är en klass som bara har en property: List<Sample> Samples,
            //den behövs för att deserialiseringen skall funka (prog kraschar om man sätter listan
            //istället för ResponseSampleList
            GraphQLResponse<SampleList> response = await _client.SendQueryAsync<SampleList>(query);

            List<Sample> samples = response.Data.Samples;

            return samples;

        }
    }
}
