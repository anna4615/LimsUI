using GraphQL;
using GraphQL.Client.Abstractions;
using LimsUI.GraphQL.Interfaces;
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

            GraphQLResponse<ResponseSampleCollectionType> response = await _client.SendQueryAsync<ResponseSampleCollectionType>(query);

            List<Sample> samples = response.Data.Samples;

            return samples;

        }
    }
}
