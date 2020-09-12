using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APISafra.API.Agents
{
    public class SafraMorningCallsAgent : ISafraMorningCallsAgent
    {
        private class RegistrationToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }

        static string tokenAddress = "https://idcs-902a944ff6854c5fbe94750e48d66be5.identity.oraclecloud.com/oauth2/v1/token";      
        static string safraAddress = "https://af3tqle6wgdocsdirzlfrq7w5m.apigateway.sa-saopaulo-1.oci.customer-oci.com/fiap-sandbox/media/v1/youtube?fromData=2020-07-09&toData=2020-07-14&playlist=morningCalls&channel=safra";
        readonly Factories.IHttpClientFactory httpClientFactory;

        private string accessToken { get; set; }

        public SafraMorningCallsAgent(Factories.IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;

            renewAccessToken().GetAwaiter();
        }

        private async Task renewAccessToken()
        {
            Console.WriteLine("Renewing AccesToken: \"{0}\"", accessToken);

            var tokenClient = httpClientFactory.CreateClient(tokenAddress);
            tokenClient.DefaultRequestHeaders.Accept.Clear();
            tokenClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Basic ZjlkM2NkOTYwMDg3NGFjMjgwM2QwM2NhNzA5Yjc4ZWI6MWEyMDc1ZTMtYjE1ZS00MzI0LTkwMmMtMGYxMmY4ZjA4MDgy");
            tokenClient.DefaultRequestHeaders.TryAddWithoutValidation("cache-control", "no-cache");
            tokenClient.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/x-www-form-urlencoded");
            tokenClient.DefaultRequestHeaders.TryAddWithoutValidation("postman-token", "280d6ac2-0e1c-d7ed-fc20-85de145f3d1c");
            tokenClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var values = new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"},
                {"scope", "urn:opc:resource:consumer::all"}
            };

            var content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = await tokenClient.PostAsync("", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not get access token!");
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            RegistrationToken jsonResult = JsonConvert.DeserializeObject<RegistrationToken>(jsonString);

            accessToken = jsonResult.access_token;

            Console.WriteLine(" ... new AccesToken: \"{0}\"", accessToken);
        }

        private async Task<HttpResponseMessage> makeRequest(string path, int retries)
        {
            if (retries > 3)
            {
                throw new Exception("Could not get access token!");
            }

            var safraClient = httpClientFactory.CreateClient(safraAddress);
            safraClient.DefaultRequestHeaders.Accept.Clear();
            safraClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + accessToken);

            HttpResponseMessage response = await safraClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            if (response.StatusCode.Equals(HttpStatusCode.Unauthorized) ||
                response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                Console.WriteLine("Unauthorized!");

                await renewAccessToken();

                return await makeRequest(path, retries + 1);
            }

            throw new Exception(response.StatusCode.ToString());
        }

        private async Task<string> requestSafraApi()
        {
            HttpResponseMessage response = await makeRequest("", 0);

            return await response.Content.ReadAsStringAsync();
        }

        public string getMorningCalls()
        {
            return requestSafraApi().GetAwaiter().GetResult();
        }
    }
}