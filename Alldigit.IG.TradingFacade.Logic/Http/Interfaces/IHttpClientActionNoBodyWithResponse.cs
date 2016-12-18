using System.Threading.Tasks;

namespace Alldigit.IG.TradingFacade.Logic.Http.Interfaces
{
    public interface IHttpClientActionNoBodyWithResponse
    {
        Task<TResponse> For<TResponse>();
    }
}
