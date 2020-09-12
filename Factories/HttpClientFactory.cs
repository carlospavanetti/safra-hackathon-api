using System;
using System.Net.Http;

namespace APISafra.API.Factories
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string baseAddress)
        {
            var client = new HttpClient();
            SetupClientDefaults(baseAddress, client);
            return client;
        }

        protected virtual void SetupClientDefaults(string baseAddress, HttpClient client)
        {
            client.BaseAddress = new Uri(baseAddress);
        }
    }
}