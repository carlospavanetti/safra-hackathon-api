using System;
using System.Net.Http;

namespace APISafra.API.Factories
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient(String baseAddress);
    }
}