using LimsUI.Models.UIModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimsUI.Gateways.GatewayInterfaces
{
    public interface ISampleGateway
    {
        Task<List<Sample>> GetSamples();
    }
}
