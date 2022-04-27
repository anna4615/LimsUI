using LimsUI.Models;
using LimsUI.Models.StartElisaMutation;
using System.Threading.Tasks;

namespace LimsUI.Gateways.GatewayInterfaces
{
    public interface IProcessGateway
    {
        Task<ProcessVariables> StartElisa(StartElisaBody body);

        Task<Plate> GetPlateVariableForElisaId(int elisaId);

    }
}
