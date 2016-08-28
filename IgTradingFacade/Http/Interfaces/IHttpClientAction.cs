﻿namespace IgTradingFacade.Http.Interfaces
{
    public interface IHttpClientAction
    {
        IHttpClientAction ForApplication(string apiKey);

        IHttpClientAction OnVersion(int version);

        IHttpClientActionWithBody Post<TRequest>(TRequest request);
    }
}
