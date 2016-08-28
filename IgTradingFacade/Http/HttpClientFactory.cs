﻿namespace IgTradingFacade.Http
{
    public static class HttpClientFactory
    {
        public static HttpClientWrapper Create(string baseAddress)
        {
            return new HttpClientWrapper(baseAddress, null);
        }
    }
}
