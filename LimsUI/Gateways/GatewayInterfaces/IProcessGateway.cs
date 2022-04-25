using LimsUI.Models;
using System.Threading.Tasks;

namespace LimsUI.Gateways.GatewayInterfaces
{
    public interface IProcessGateway
    {
        Task<ProcessVariables> StartElisa(StartElisaBody body);
    }
}
