using LimsUI.Models;
using System.Threading.Tasks;

namespace LimsUI.REST
{
    public interface IRequest
    {
        Task<ProcessElisa> StartElisa(StartElisaBody body);
    }
}
