namespace Alldigit.IG.TradingFacade.Logic.Http.Interfaces
{
    public interface IHttpClientActionWithBody
    {
        IHttpClientActionWithBodyAndResponse To(string url);
    }
}
