using LimsUI.Models.UIModels;
using LimsUI.Models.ProcessModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimsUI.Gateways.GatewayInterfaces
{
    public interface IProcessGateway
    {
        Task<StartElisaReturnValues> StartElisa(StartElisaBody body);
        Task<Layout> GetLayoutForElisaId(int elisaId);
        Task<SendRawDataReturnValues> SendRawData(SendRawDataBody body);
        Task<ResultReviewedReturnValues> SendResultReviewed(ResultReviewedBody body);
        Task<Elisa> GetResultForElisaId(int elisaId);

    }
}
