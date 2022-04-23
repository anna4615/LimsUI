using LimsUI.GraphQL.SampleClasses;
using LimsUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimsUI.GraphQL.Interfaces
{
    public interface ISampleConsumer
    {
        Task<List<Sample>> GetSamples();
    }
}
