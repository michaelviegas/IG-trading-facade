namespace Alldigit.IG.TradingFacade.Logic.Http.Interfaces
{
    public interface IHttpClientActionNoBody
    {
        IHttpClientActionNoBodyWithResponse To(string url);
    }
}
