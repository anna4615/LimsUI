using LimsUI.GraphQL.SampleClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimsUI.GraphQL.Interfaces
{
    public interface ISampleConsumer
    {
        Task<List<Sample>> GetSamples();
    }
}
