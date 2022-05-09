using GraphQL;
using GraphQL.Client.Abstractions;
using LimsUI.Gateways.GatewayInterfaces;
using LimsUI.Models.UIModels;
using System.Collections.Generic;
using System.Linq;
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


        public async Task<Elisa> GetResultForElisa(int elisaId)
        {
            GraphQLRequest query = new GraphQLRequest
            {
                Query = $@"query {{
                            elisas(where:{{ id: {{ eq: {elisaId}}}}}){{
		                        id
		                        status
		                        dateFinished
		                        tests{{	
                                    status
			                        sample{{
				                    id
				                    name
				                    concentration				
			                    }}
		                    }}
	                    }}
                    }}"
            };

            GraphQLResponse<ElisaList> response = await _client.SendQueryAsync<ElisaList>(query);

            List<Elisa> results = response.Data.Elisas;

            return results.FirstOrDefault();
        }
    }
}
