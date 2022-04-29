using LimsUI.Models.UIModels;
using LimsUI.Models.ProcessModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using LimsUI.Models.ProcessModels.StartElisa;

namespace LimsUI.Gateways.GatewayInterfaces
{
    public interface IProcessGateway
    {
        Task<ProcessVariables> StartElisa(StartElisaBody body);

        Task<Layout> GetLayoutForElisaId(int elisaId);

    }
}
